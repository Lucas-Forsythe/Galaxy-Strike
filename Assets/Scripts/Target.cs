using UnityEngine;
using UnityEngine.SceneManagement;

public class Target : MonoBehaviour
{
    [Header("Target Settings")]
    [SerializeField] int hitPoints = 1;
    [SerializeField] int scoreValue = 100;

    [Header("Effects")]
    [SerializeField] GameObject boomVFX;

    [Header("References")]
    [SerializeField] ScoreManager scoreManager;

    int startingHitPoints;
    bool defeated = false;

    void Awake()
    {
        startingHitPoints = hitPoints;
    }

    void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Bullet"))
        {
            return;
        }

        // Remove the bullet that hit this target.
        Destroy(other.gameObject);

        TakeHit(1);
    }

    public void TakeHit(int damage)
    {
        if (defeated)
        {
            return;
        }

        hitPoints -= damage;

        Debug.Log(gameObject.name + " hit! HP remaining: " + hitPoints);

        if (hitPoints <= 0)
        {
            DefeatTarget();
        }
    }

    void DefeatTarget()
    {
        defeated = true;

        // Play the explosion only when the target is defeated.
        if (boomVFX != null)
        {
            Instantiate(boomVFX, transform.position, Quaternion.identity);
        }

        // Add this target's points to the scoreboard.
        if (scoreManager != null)
        {
            scoreManager.AddScore(scoreValue);
        }
        
        else
        {
            Debug.LogWarning("ScoreManager is not assigned to " + gameObject.name);
        }

        // Disable the target instead of destroying it.
        gameObject.SetActive(false);
    }

    public void ResetTarget()
    {
        hitPoints = startingHitPoints;
        defeated = false;
        gameObject.SetActive(true);
    }
}
