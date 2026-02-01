using UnityEngine;

public class OneShotAudioPool : ObjectPool<OneShotAudio>
{
    static OneShotAudioPool _instance;

    public static OneShotAudioPool Pool { get => _instance; set => _instance = value; }

    void Awake()
    {
        if (_instance != null && this != _instance)
        {
            Destroy(gameObject);
            return;
        }

        _instance = this;
    }
}
