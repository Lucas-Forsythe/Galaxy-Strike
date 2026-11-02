
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] GameObject explosionVFX;

    private void OnParticleCollision(GameObject other)
    {
        if (other.CompareTag("Enemy"))
        {
            Debug.Log("ENEMY HIT!");
            Instantiate(explosionVFX, other.transform.position, Quaternion.identity);
            Destroy(other);
        }
        Debug.Log("PARTICLE COLLISION DETECTED with: " + other.name);
    }
}

/*

            Instantiate(explosionVFX, other.transform.position, Quaternion.identity);
            Destroy(other);
        }
    }
}

/*
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
*/