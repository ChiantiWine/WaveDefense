using Unity.Mathematics;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] GameObject robotExplosionVFX;
    [SerializeField] int startingHealth = 3;

    int currentHealth;

    GmaeManager gameManager;
    void Awake()
    {
        currentHealth = startingHealth;
    }

    void Start()
    {
        gameManager = FindFirstObjectByType<GmaeManager>();
        gameManager.AdjustEnemiesLeft(1);
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;

        if (currentHealth <= 0)
        {
            gameManager.AdjustEnemiesLeft(-1);
            SelfDestrut();
        }
    }

    public void SelfDestrut()
    {
        Instantiate(robotExplosionVFX, transform.position, quaternion.identity);
        Destroy(this.gameObject);
    }
}
