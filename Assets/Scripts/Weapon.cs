using StarterAssets;
using Unity.Mathematics;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    StarterAssetsInputs starterAssetsInputs;
    [SerializeField] ParticleSystem muzzleFlash;
    [SerializeField] GameObject hitVFXPrefab;
    [SerializeField] Animator animator;
    [SerializeField] int damagerAmount = 1;

    const string SHOOT_STRING = "Shoot";
    void Awake()
    {
        starterAssetsInputs = GetComponentInParent<StarterAssetsInputs>();
    }
    void Start()
    {
        
    }

    void Update()
    {
        HandleShoot();
    }

    void HandleShoot()
    {
        if (!starterAssetsInputs.shoot) return;

        muzzleFlash.Play();
        animator.Play(SHOOT_STRING, 0, 0f);
        starterAssetsInputs.ShootInput(false);

        RaycastHit hit;

                
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, Mathf.Infinity))
        {
            Instantiate(hitVFXPrefab, hit.point, quaternion.identity);
            EnemyHealth enemyHealth = hit.collider.GetComponent<EnemyHealth>();
            enemyHealth?.TakeDamage(damagerAmount); // ? null 조건부 연산자
        }

       
    }

}
