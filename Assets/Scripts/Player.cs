using UnityEngine;


public class Player : MonoBehaviour
{
    // Editor Fields
    [SerializeField] private float moveSpeed = 5f;

    private GameManager _gameManagerScript;
    private AudioManager _audioManagerScript;
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
        _audioManagerScript = FindAnyObjectByType<AudioManager>();
        
        if (_gameInputScript == null)
        {
            Debug.LogError("Game Input  is null!");
        }
        
        if (_gameManagerScript == null)
        {
            Debug.LogError("Game Manager is null!");
        }
        
        if (_audioManagerScript == null)
        {
            Debug.LogError("Audio Manager is null!");
        }
    }

    private void FixedUpdate()
    {
        _playerRigidbody.linearVelocity = _gameInputScript.MoveInput * moveSpeed;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        /*  This is a C style comment that ignores everything inside
        // One way to check but is less performant and relies on string comparisons
        if (other.gameObject.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);
            _gameManagerScript.PlayerHasDied();
            Destroy(gameObject);

        } 
        */

        if (other.TryGetComponent<Enemy>(out _))
        {
            Destroy(other.gameObject);
            _gameManagerScript.PlayerHasDied();
            _audioManagerScript.PlayerDeathSound();
            Destroy(gameObject);
        }
        else if (other.gameObject.TryGetComponent<Pickup>(out var pickupScript))
        {
            Destroy(other.gameObject);
            _audioManagerScript.PlayerPickupSound();
            
            // The var keyword will set points to an integer because PointsPerPickup() returns an integer
            var points = pickupScript.PointsPerPickup();
            
            
            _gameManagerScript.IncrementScore(points);
        }
    }
}
