using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
    // Public Properties
    public int CurrentScore { get; private set; } 
    public int NumberOfLives { get; private set; } 
    
    // Editor Fields
    [Header("Game")] 
    [SerializeField] private int numberOfLives = 3;
    [SerializeField] private float timeBetweenRounds = 3;
    [SerializeField] private UIManager uiManager;
    
    [Header("Player")]
    [SerializeField] private Player playerPrefab;

    [Header("Spawners")] 
    [SerializeField] private ObjectSpawner enemySpawnerScript;
    [SerializeField] private ObjectSpawner pickupSpawnerScript;


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
        CurrentScore = 0;
        NumberOfLives = numberOfLives;
        uiManager.SetLivesText(NumberOfLives);
        uiManager.SetScoreText(CurrentScore);
        StartRound();
    }

    private void StartRound()
    {
        _playerScript = Instantiate(playerPrefab, Vector2.zero, Quaternion.identity);
        enemySpawnerScript.StartSpawner();
        pickupSpawnerScript.StartSpawner();
        Debug.Log($"Player has {NumberOfLives} lives");
    }
    
    // Internal Functions
    private IEnumerator DelayedStartRound()
    {
        yield return new WaitForSeconds(timeBetweenRounds);
        StartRound();
    }
    
    // External Functions
    public void IncrementScore(int points)
    {
        CurrentScore += points;
        uiManager.SetScoreText(CurrentScore);
    }
    
    
    public void PlayerHasDied()
    {
        Debug.Log("Player Has Died");
        enemySpawnerScript.StopSpawner();
        pickupSpawnerScript.StopSpawner();
        NumberOfLives--;
        uiManager.SetLivesText(NumberOfLives);

        if (NumberOfLives > 0)
        {
            StartCoroutine(DelayedStartRound());
        }
        else
        {
            Debug.Log("Game Over !!!");
        }

    }

}
