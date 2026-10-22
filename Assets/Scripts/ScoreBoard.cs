using UnityEngine;
using TMPro;

public class ScoreBoard : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreText;

    int score = 0;

    public void IncreaseScore(int amount)
    {
        score += amount;
        scoreText.text = "Score: " + score.ToString();
    }
}
