using UnityEngine;

public class EnemyDeathParticle : MonoBehaviour
{
    [SerializeField]
    ParticlePool normal;

    [SerializeField]
    ParticlePool critical;

    public void Spawn(EnemyDeathInfo info)
    {
        var pool = info.ColorMatched ? critical : normal;

        var particle = pool.GetObject();
        particle.transform.position = info.Vector3;
        var mainPs = particle.ParticleSystem.main;
        mainPs.startColor = info.Color.Color;
        particle.gameObject.SetActive(true);
    }
}
