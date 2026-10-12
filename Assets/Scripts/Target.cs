using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField] GameObject boomVFX;
    void OnTriggerEnter(Collider other) // Unity calls this when a bullet hits
    {
        // Play the explosion effect
        if (boomVFX != null)
        {
            GameObject explosion = Instantiate(boomVFX, transform.position, Quaternion.identity);

            ParticleSystem particles = explosion.GetComponent<ParticleSystem>();

            if (particles != null)
            {
                particles.Play();
            }
        }

        if (other.gameObject.CompareTag("Bullet")) // check if the other object is a bullet
        {
            Debug.Log("Bullet hit target!"); // log the hit
            Destroy(other.gameObject); // remove the bullet
            Destroy(gameObject); // remove this target
        }
    }
}