using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    [SerializeField]
    private List<AudioSource> audioSources;

    public AudioSource GetAudioSource(int index)
    {
        if (audioSources != null && index < audioSources.Count && index >= 0)
            return audioSources[index];

        return null;
    }

}
