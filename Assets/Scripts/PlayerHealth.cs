using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField]
    private int health = 100;

    [SerializeField]
    private Slider healthSlider;

    public void TakeDamage(int damage)
    {
        if (health >= 0)
        {
            health -= damage;
            healthSlider.value = health;
        }
        else
            Destroy(gameObject);
    }

}
