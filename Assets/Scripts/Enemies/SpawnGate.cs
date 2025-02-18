using System.Collections;
using UnityEngine;

public class SpawnGate : MonoBehaviour
{
    [SerializeField] float spawnTime = 5f;
    [SerializeField] GameObject robotPrepab;
    [SerializeField] Transform spawnPoint;

    PlayerHealth player;
    void Start()
    {
        player = FindFirstObjectByType<PlayerHealth>();
        StartCoroutine(SpawnRoutine());
    }

    IEnumerator SpawnRoutine()
    {
        while (player)
        {
            Instantiate(robotPrepab, spawnPoint.position, transform.rotation);
            yield return new WaitForSeconds(spawnTime);
        }
            
    }
}
