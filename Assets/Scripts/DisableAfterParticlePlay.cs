using System;
using System.Collections;
using UnityEngine;

public class DisableAfterParticlePlay : MonoBehaviour
{
    [SerializeField]
    ParticleSystem ps;

    public ParticleSystem ParticleSystem { get => ps; }

    void OnEnable()
    {
        if (gameObject.activeInHierarchy)
        {
            StartCoroutine(PlayThenDisable());
        }
    }

    private IEnumerator PlayThenDisable()
    {
        ps.Play();
        while (ps.isPlaying || ps.isEmitting || ps.particleCount != 0)
        {
            yield return null;
        }
        gameObject.SetActive(false);
    }
}
