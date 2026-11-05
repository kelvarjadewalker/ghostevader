using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    // Editor Fields
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI livesText;

    // Unity Events
    private void Awake()
    {
        const int initialValue = 0;

        SetLivesText(initialValue);
        SetScoreText(initialValue);
    }

    // External Functions
    public void SetLivesText(int lives)
    {
        livesText.SetText($"x{lives}");
    }
    
    public void SetScoreText(int score)
    {
        scoreText.SetText($"{score}");
    }
}
