using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _maxHealth = 3;


    private float _currentHealth;
    
    [SerializeField] private  HealthBar _healthbar;
    
    void Start()
    {
        _currentHealth = _maxHealth;
    }


    public void TakeDmg()
    {
        _currentHealth -= 1;
        _healthbar.UpdateHealthBar(_maxHealth, _currentHealth);
        if (_currentHealth <= 0)
        {
            //Destroy(gameObject);
            Debug.Log("Player Died :(");
        }

    }
}
