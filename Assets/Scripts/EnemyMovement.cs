using UnityEngine;


public class EnemyMovement : MonoBehaviour
{

    // Variables
    Rigidbody rb;
    public float movementSpeed = 5f; //Enemy's movement speed
    public float rotationSpeed = 5f; //Enemy's rotation speed
    private Vector3 startPos;//Enemy's starting position
    private GameObject player; //Player's transform
    public float stopFollowRadius = 2f; //Distance at which the Enemy stops following the Player


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Obtain the enemy's starting position
        startPos = transform.position;

        player =  GameObject.Find("PlayerObject");
        if(player != null)
        {
            Debug.Log("Player Found");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(player != null)
        {
            float distance = Vector3.Distance(transform.position, player.transform.position);

            if(distance > stopFollowRadius)
            {
                // Face the Player
                Vector3 direction = (player.transform.position - transform.position).normalized;
                Quaternion lookRotation = Quaternion.LookRotation(direction);
                transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * rotationSpeed);

                // Move towards Player
                transform.position += direction * movementSpeed * Time.deltaTime;
            }
            else
            {
                attack();
            }
            
        }
        
    }

    void attack()
    {
        //swing arm
    }

    // Enemy should immediately follow the player
    // Enemies spawn from the ground and immediately go to attack the player
    // They take multiple hits to die
    // More enemies spawn as time passes. If possible, make them faster with time.
    // Enemies attack physically with their hands or with an object
}
