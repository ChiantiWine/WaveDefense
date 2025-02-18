using UnityEngine;

public abstract class Pickup : MonoBehaviour
{
    const string PLAYER_STRING = "Player";
    [SerializeField] float rotationSpeed = 100f;

    void Update()
     {
         transform.Rotate(0f, rotationSpeed * Time.deltaTime, 0f, Space.World);
     }
     
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(PLAYER_STRING))
        {
            ActiveWeapon activeWeapon = other.GetComponentInChildren<ActiveWeapon>();
            OnPickup(activeWeapon);
            Destroy(this.gameObject);
        }
    }

    protected abstract void OnPickup(ActiveWeapon activeWeapon);

    

}
