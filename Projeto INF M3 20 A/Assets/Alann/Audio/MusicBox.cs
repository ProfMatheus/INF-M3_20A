using UnityEngine.Audio;
using UnityEngine;
using System;

public class MusicBox : MonoBehaviour
{
    /// <summary>
    /// Variável que referencia a própria classe <see cref="MusicBox"/>
    /// </summary>
    public static MusicBox instance { get; private set; }

    /// <summary>
    /// Variável que guarda um array com todos os itens do tipo <see cref="Sound"/> num array
    /// </summary>
    public Sound[] sounds;

    public Sound currentSound;

    /// <summary>
    /// Este método é chamado antes do Start. Sendo iniciado antes de qualquer coisa.
    /// </summary>
    private void Awake()
    {
        // Casso o objeto "instance" não exista, ele é criado e definido como a própria classe, caso contrario o novo objeto é deletado.
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            DestroyObject(gameObject);
        }

        // Cria um AudioSource para cada arquivo de musica no array "sounds"
        foreach( Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.audio;
            s.source.volume = s.audioVolume;
            s.source.pitch = s.audioPitch;
            s.source.loop = s.audioloop;

        }
    }

    void Start()
    {
        currentSound = null;
        //Play("CatchUpSally");
    }

    /// <summary>
    /// Começa a tocar o <see cref="Sound"/> com o nome definido pelo parâmetro.
    /// </summary>
    /// <param name="name"></param>
    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.audioName == name);
        s.source.Play();
        currentSound = s;
    }

    /// <summary>
    /// Método que pausa a musica que esta sendo tocada.
    /// </summary>
    public void Stop()
    {
        if (currentSound != null)
            currentSound.source.Stop();
        else
            return;
    }


}
