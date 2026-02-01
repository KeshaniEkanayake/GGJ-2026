    using UnityEngine;
    using UnityEngine.InputSystem;

    [RequireComponent(typeof(Rigidbody))]
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private Player player;
        
        public float moveSpeed = 6f;
        public float acceleration = 20f;
        public float rotationSpeedDeg = 720f;
        public Camera mainCamera;

        
        [Header("Shooting")]
        public GameObject projectilePrefab;
        public Transform firePoint;
        public float fireCooldown = 0.2f;

        float nextFireTime;



        PlayerInputActions inputActions;
        InputAction fireAction;

        InputAction dmgAction;


        Rigidbody rb;
        Vector3 currentVelocity;
        
        void Awake()
        {
            rb = GetComponent<Rigidbody>();
            if (mainCamera == null) mainCamera = Camera.main;

            rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
            rb.interpolation = RigidbodyInterpolation.Interpolate;

            inputActions = new PlayerInputActions();

            fireAction = inputActions.Player.Fire;


            dmgAction = inputActions.Player.dmg;
        }

        void OnEnable() => inputActions.Enable();
        void OnDisable() => inputActions.Disable();

        void Update()
        {
            HandleShooting();

            HandleDmg();
        }

        void FixedUpdate()
        {
            HandleMovement();
            HandleRotationToMouse();
        }

        //Player movement controller
        void HandleMovement()
        {
            Vector2 moveInput = inputActions.Player.Move.ReadValue<Vector2>();
            float h = moveInput.x;
            float v = moveInput.y;

            Vector3 camForward = mainCamera.transform.forward;
            Vector3 camRight = mainCamera.transform.right;
            camForward.y = 0;
            camRight.y = 0;
            camForward.Normalize();
            camRight.Normalize();

            Vector3 desiredMove = (camRight * h + camForward * v);
            if (desiredMove.sqrMagnitude > 1f) desiredMove.Normalize();

            Vector3 targetVelocity = desiredMove * moveSpeed;
            currentVelocity = Vector3.MoveTowards(currentVelocity, targetVelocity, acceleration * Time.fixedDeltaTime);
            rb.MovePosition(rb.position + currentVelocity * Time.fixedDeltaTime);
        }

        //Script to manage player rotation towards mouse
        void HandleRotationToMouse()
        {
            Vector2 mousePos = inputActions.Player.Look.ReadValue<Vector2>();
            Ray camRay = mainCamera.ScreenPointToRay(mousePos);
            Plane groundPlane = new Plane(Vector3.up, new Vector3(0f, -0.5f, 0f));

            if (groundPlane.Raycast(camRay, out float enter))
            {
                Vector3 hitPoint = camRay.GetPoint(enter);
                Vector3 direction = hitPoint - rb.position;
                direction.y = 0f;
                if (direction.sqrMagnitude < 0.0001f) return;

                Quaternion targetRot = Quaternion.LookRotation(direction, Vector3.up);
                Quaternion newRot = Quaternion.RotateTowards(rb.rotation, targetRot, rotationSpeedDeg * Time.fixedDeltaTime);
                rb.MoveRotation(newRot);
            }
        }

        //Script to manage left click inputs and instatiate projectiles
        void HandleShooting()
        {
            if (Time.time < nextFireTime)
                return;

            if (fireAction.WasPressedThisFrame())
            {
                Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
                nextFireTime = Time.time + fireCooldown;
            }
        }



        //Temporary test to ensure health bar works, right click to decrease health.
        //Will be removed once enemy's do dmg.
        void HandleDmg()
        {
            if (dmgAction.WasPressedThisFrame())
            {
                Debug.Log("Damage input detected");
                player.TakeDmg();
            }
        }
    }
