using UnityEditor.ShaderGraph;
using UnityEngine;
using UnityEngine.UIElements;

public class Explosion : MonoBehaviour
{
    [SerializeField] float radius = 1.5f;
    [SerializeField] int damage = 3;

    void Start()
    {
        Explode();
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);
    }


    void Explode()
    {
        // 범위 안으로 들어오면 캐릭터 데미지 입음.
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, radius);

        foreach (Collider hitCollider in hitColliders)
        {
            PlayerHealth playerHealth = hitCollider.GetComponent<PlayerHealth>();

            if (!playerHealth) continue;
            
            playerHealth.TakeDamage(damage);
            
            break;
        }
    }

}
