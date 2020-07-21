using UnityEngine.Audio;
using UnityEngine;

/// <summary>
/// Classe utilizada pela <see cref="MusicBox"/> para identificar audios
/// </summary>
[System.Serializable]
public class Sound
{
    public AudioClip audio;

    public string audioName;

    [Range(0f, 1f)]
    public float audioVolume;
    [Range(.1f,3f)]
    public float audioPitch;
    public bool audioloop;
    
    [HideInInspector]
    public AudioSource source;

}
