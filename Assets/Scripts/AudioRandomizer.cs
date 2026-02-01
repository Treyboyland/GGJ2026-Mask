using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "RandomAudio", menuName = "Audio/Randomizer")]
public class AudioRandomizer : ScriptableObject
{
    [SerializeField]
    List<AudioClip> clips;

    [SerializeField]
    Vector2 pitchRange;

    [SerializeField]
    Vector2 volumeRange;

    public void PlaySound()
    {
        var sound = OneShotAudioPool.Pool.GetObject();
        var index = UnityEngine.Random.Range(0, clips.Count);
        var pitch = UnityEngine.Random.Range(pitchRange.x, pitchRange.y);
        var volume = UnityEngine.Random.Range(volumeRange.x, volumeRange.y);
        sound.Source.clip = clips[index];
        sound.Source.volume = volume;
        sound.Source.pitch = pitch;
        sound.gameObject.SetActive(true);
    }
}
