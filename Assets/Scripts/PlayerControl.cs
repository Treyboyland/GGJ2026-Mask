using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControl : MonoBehaviour
{
    [SerializeField]
    GameEvent onQuit;

    [SerializeField]
    GameEvent onReset;


    [SerializeField]
    GameEventBool onFire;

    [SerializeField]
    GameEventVector2 onMove;



    public void HandleMove(InputAction.CallbackContext context)
    {
        onMove.Invoke(context.ReadValue<Vector2>());
    }

    public void HandleFire(InputAction.CallbackContext context)
    {
        onFire.Invoke(context.ReadValueAsButton());
    }

    public void HandleReset(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            onReset.Invoke();
        }
    }

    public void HandleQuit(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            onQuit.Invoke();
        }
    }
}
