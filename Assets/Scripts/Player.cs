using UnityEngine;


public class Player : MonoBehaviour
{
    // Editor Field
    [SerializeField] private float moveSpeed = 5f;

    private GameManager _gameManagerScript;
    private GameInput _gameInputScript;
    
    // Internal Fields
    private Rigidbody2D _playerRigidbody;

    // Unity Events
    private void Awake()
    {
        _playerRigidbody = GetComponent<Rigidbody2D>();
        
        if (_playerRigidbody == null)
        {
            Debug.LogError("Player Rigidbody2D is null!");
        }
        
    }

    private void Start()
    {
        _gameInputScript = FindAnyObjectByType<GameInput>();
        _gameManagerScript = FindAnyObjectByType<GameManager>();
        
        if (_gameInputScript == null)
        {
            Debug.LogError("Game Input  is null!");
        }
        
        if (_gameManagerScript == null)
        {
            Debug.LogError("Game Manager is null!");
        }
    }

    private void FixedUpdate()
    {
        _playerRigidbody.linearVelocity = _gameInputScript.MoveInput * moveSpeed;
    }
}
