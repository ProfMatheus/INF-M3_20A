using UnityEngine.Audio;
using UnityEngine;

/// <summary>
/// Classe utilizada pela <see cref="MusicBox"/> para identificar audios
/// </summary>
[System.Serializable]
public class Sound
{
    /// <summary>
    /// Variável que identifica o audio utilizado para tocar a música.
    /// </summary>
    public AudioClip audio;

    /// <summary>
    /// Variável utilizada para referenciar o nome do audio. 
    /// </summary>
    public string audioName;

    /// <summary>
    /// Variável que define o volume do audio. Utiliza o atributo <see cref="RangeAttribute"/> para limitar o valor.
    /// </summary>
    [Range(0f, 1f)]
    public float audioVolume;
    /// <summary>
    /// Variável que define o pitch do audio. Utiliza o atributo <see cref="RangeAttribute"/> para limitar o valor.
    /// </summary>
    [Range(.1f,3f)]
    public float audioPitch;
    /// <summary>
    /// Booleana que define se o <see cref="audio"/> estará em loop ou não.
    /// </summary>
    public bool audioloop;
    
    /// <summary>
    /// Variável que define o arquivo de som que serpa utilizado, deve ser atribuido pelo Inspector.
    /// </summary>
    [HideInInspector]
    public AudioSource source;

}
