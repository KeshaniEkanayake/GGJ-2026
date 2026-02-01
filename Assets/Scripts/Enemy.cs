using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _maxHealth = 3;

    private float _currentHealth;
    
    [SerializeField] private  HealthBar _healthbar;

    void Start()
    {
        _currentHealth = _maxHealth;
    }

    void Update()
    {
        
    }

     void OnCollisionEnter(Collision collisionInfo)
    {
        Debug.Log("Collided with: " + collisionInfo.gameObject.name); // Accesses the name of the object collided with

        // You can perform other actions here, such as destroying the object or applying damage
        // Example: Destroy the object this script is on if it hits something tagged "Obstacle"
        if (collisionInfo.gameObject.CompareTag("Bullet"))
        {
        
            //Destroy(gameObject);

            TakeDmg();
        }
    }


    public void TakeDmg()
        {
            _currentHealth -= 1;
            _healthbar.UpdateHealthBar(_maxHealth, _currentHealth);
            if (_currentHealth <= 0)
            {
                //Destroy(gameObject);
                Debug.Log("Enemy Died :(");
            }
        }
}
