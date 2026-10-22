using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject explosionVFX;
    [SerializeField] int hitPoints = 1;
    [SerializeField] int pointsForDestroying = 100;
    private ScoreBoard scoreBoard;
    private void Start()
    {
        scoreBoard = Object.FindFirstObjectByType<ScoreBoard>();
    }
    private void OnParticleCollision(GameObject other)
    {
        hitPoints--;
        if (hitPoints <= 0)
        {
            scoreBoard.IncreaseScore(pointsForDestroying);
            Destroy(other);
            Instantiate(explosionVFX, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }
}
