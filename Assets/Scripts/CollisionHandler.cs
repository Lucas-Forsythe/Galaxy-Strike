using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] GameObject explosionVFX;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void OnParticleCollision(GameObject other)
    {
        Destroy(other);
        Instantiate(explosionVFX, transform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }
}
