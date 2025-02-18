using Unity.Mathematics;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] GameObject robotExplosionVFX;
    [SerializeField] int startingHealth = 3;

    int currentHealth;

    void Awake()
    {
        currentHealth = startingHealth;
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;

        if (currentHealth <= 0)
        {
            SelfDestrut();
        }
    }

    public void SelfDestrut()
    {
        Instantiate(robotExplosionVFX, transform.position, quaternion.identity);
        Destroy(this.gameObject);
    }
}
