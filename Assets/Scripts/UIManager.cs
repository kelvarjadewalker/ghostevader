using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    // Editor Fields
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI highScoreText;
    [SerializeField] private TextMeshProUGUI livesText;
    [SerializeField] private GameObject pauseGamePanel;
    

    // Unity Events
    private void Awake()
    {
        const int initialValue = 0;

        SetLivesText(initialValue);
        SetScoreText(initialValue);
        DisplayPauseGamePanel(false);
    }
    


    // External Functions
    public void DisplayPauseGamePanel(bool show)
    {
        pauseGamePanel.SetActive(show);
    }
    public void SetLivesText(int lives)
    {
        livesText.SetText($"x{lives}");
    }
    
    public void SetScoreText(int score)
    {
        scoreText.SetText($"{score}");
    }
    
    public void SetHighScoreText(int highScore)
    {
        highScoreText.SetText($"{highScore}");
    }
}
