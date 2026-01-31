using System.Collections;
using UnityEngine;

public class DisableAfterTime : MonoBehaviour
{
    [SerializeField]
    float seconds;

    public float Seconds { get => seconds; set => seconds = value; }

    void OnEnable()
    {
        if (gameObject.activeInHierarchy)
        {
            StartCoroutine(WaitThenDisable());
        }
    }

    IEnumerator WaitThenDisable()
    {
        yield return new WaitForSeconds(seconds);
        gameObject.SetActive(false);
    }
}
