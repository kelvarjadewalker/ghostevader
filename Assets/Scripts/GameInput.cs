using UnityEngine;
using UnityEngine.InputSystem;

public class GameInput : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    
    // Public properties
   public Vector2 MoveInput { get; private set; } 

   // External Functions
   public void OnMove(InputAction.CallbackContext context)
   {
      MoveInput = context.ReadValue<Vector2>();
   }
   
   public void OnPause(InputAction.CallbackContext context)
   {
       if (context.performed)
       {
           gameManager.TogglePause();
       }
   }
   
}
