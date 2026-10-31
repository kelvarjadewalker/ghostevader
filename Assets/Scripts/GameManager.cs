using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Public Properties
    public int CurrentScore { get; private set; } 
    public int NumberOfLives { get; private set; } 
    
    // Editor Fields
    [Header("Player")]
    [SerializeField] private Player playerPrefab;

    // Internal Fields
    private Player _playerScript;


    // Unity Events
    private void Start()
    {
        StartGame();
    }
    
    // Internal Functions

    private void StartGame()
    {
        // Add any startup code
        StartRound();
    }

    private void StartRound()
    {
        _playerScript = Instantiate(playerPrefab, Vector2.zero, Quaternion.identity);
    }
    
    // Public Functions
    public void PlayerHasDied()
    {
        Debug.Log("Player Has Died");
    }

}
