
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] GameObject explosionVFX;
    GameSceneManager gameSceneManager;

    private void Start()
    {
        gameSceneManager = FindObjectOfType<GameSceneManager>();
    } 
    private void OnParticleCollision(GameObject other)
    {
        if (other.CompareTag("Ground"))
        {
            return;
        }
        else
        {
            gameSceneManager.ReloadLevel();
            Instantiate(explosionVFX, transform.position, transform.rotation);
            Destroy(gameObject);
        }
        
    }
}