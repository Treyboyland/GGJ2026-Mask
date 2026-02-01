using UnityEngine;

public class DisableAfterInvisible : MonoBehaviour
{
    [SerializeField]
    float secondsToWait;

    float elapsed;
    private bool shouldCount;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        elapsed += shouldCount ? Time.deltaTime : 0;
        if (elapsed >= secondsToWait)
        {
            elapsed = 0;
            gameObject.SetActive(false);
        }
    }

    void OnBecameInvisible()
    {
        shouldCount = true;
    }

    void OnBecameVisible()
    {
        elapsed = 0;
        shouldCount = false;
    }
}
