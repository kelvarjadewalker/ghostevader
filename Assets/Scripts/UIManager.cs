using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI livesText;


    private void Awake()
    {
        const int initialValue = 0;

        SetLivesText(initialValue);
        SetScoreText(initialValue);
    }

    public void SetLivesText(int lives)
    {
        livesText.SetText($"x{lives}");
    }
    
    public void SetScoreText(int score)
    {
        scoreText.SetText($"{score}");
    }
}
