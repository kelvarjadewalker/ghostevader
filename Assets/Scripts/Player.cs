using UnityEngine;


public class Player : MonoBehaviour
{
    // Editor Field
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private GameInput gameInputScript;
    
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

        if (gameInputScript == null)
        {
            Debug.LogError("Game Input  is null!");
        }
        
    }

    private void FixedUpdate()
    {
        _playerRigidbody.linearVelocity = gameInputScript.MoveInput * moveSpeed;
    }
}
