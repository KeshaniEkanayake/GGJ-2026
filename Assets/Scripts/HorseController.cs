using UnityEngine;

public class HorseController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
        [SerializeField] private Rigidbody rb;
        
        private Vector3 _input;

        [SerializeField] private float _speed = 5;
        [SerializeField] private float _turnSpeed = 360;

        void Start()
        {
            //rb = GetComponent<Rigidbody>();
        }
        
        void Update()
        {
            GatherInput();

            Look();
        }
        void FixedUpdate()
        {
            Move();
        }

        void GatherInput()
        {
            _input = new Vector3(Input.GetAxisRaw("Horizontal"),0,Input.GetAxisRaw("Vertical"));
        }

        void Look()
        {
            if (_input != Vector3.zero){

                var matrix = Matrix4x4.Rotate(Quaternion.Euler(0,45,0));

                var skewedInput = matrix.MultiplyPoint3x4(_input);

                var relative = (transform.position + skewedInput) - transform.position;
                var rot = Quaternion.LookRotation(relative, Vector3.up);

                transform.rotation = Quaternion.RotateTowards(transform.rotation, rot, _turnSpeed * Time.deltaTime);
                }
        }

        void Move() 
        {
            rb.MovePosition(transform.position + transform.forward * _input.normalized.magnitude * _speed * Time.deltaTime);
        }

}
