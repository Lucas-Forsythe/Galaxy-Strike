using TMPro;
using UnityEngine;

public class SubtitleHandler : MonoBehaviour
{
    [SerializeField] string[] subtitleText;
    [SerializeField] TMP_Text text;

    int currentIndex = 0;

    public void NextLine()
    {
        text.text = subtitleText[currentIndex];
        currentIndex++;
    }
}