

using UnityEngine;
using UnityEngine.UI;
public class HealthBar : MonoBehaviour
{   
    [SerializeField] private Image _healthbarSprite;

    [Header("Target to follow")]
    public Transform target;

    public Vector3 offset; 

    public void UpdateHealthBar(float maxHealth, float currentHealth)
    {
        _healthbarSprite.fillAmount = currentHealth / maxHealth;
    }


    void Update()
    {
        //lock health bar to player
        transform.position = target.position + offset; 

        //rotate health bar
        transform.rotation = Quaternion.Euler(0f, 45f, 0f);
    }
}   
