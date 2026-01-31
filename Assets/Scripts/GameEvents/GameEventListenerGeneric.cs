using UnityEngine;
using UnityEngine.Events;


public abstract class GameEventListener<T> : MonoBehaviour
{
    [SerializeField]
    GameEvent<T> gameEvent;

    public UnityEvent<T> Response;


    /// <summary>
    /// This function is called when the object becomes enabled and active.
    /// </summary>
    private void OnEnable()
    {
        gameEvent.AddListener(this);
    }

    /// <summary>
    /// This function is called when the behaviour becomes disabled or inactive.
    /// </summary>
    private void OnDisable()
    {
        gameEvent.RemoveListener(this);
    }
}
