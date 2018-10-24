using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Sound
{
    public string name;
    public AudioClip clip;
    public bool isEffect = true;
}

public class SoundManager : MonoBehaviour
{
    [Header("Volume Settings")]
    [Range(0.0f, 1.0f)]
    public float musicVolume = 1.0f;

    [Range(0.0f, 1.0f)]
    public float effectVolume = 1.0f;

    [Header("Sound Database")]
    public List<Sound> sounds = new List<Sound>();

    private List<AudioSource> _sources = new List<AudioSource>();

    private static SoundManager _instance = null;

    private void Awake()
    {
        _instance = this;

        DontDestroyOnLoad(gameObject);
    }

    private void Update()
    {
        var remove = new List<AudioSource>();

        foreach (var source in _sources)
        {
            if (!source.isPlaying && source.isActiveAndEnabled)
            {
                remove.Add(source);
            }
        }

        foreach (var source in remove)
        {
            _sources.Remove(source);
            Destroy(source);
        }
    }

    public bool LoadSound(string name, string path)
    {
        return LoadSound(name, path, true);
    }

    public bool LoadSound(string name, string path, bool isEffect)
    {
        var newSound = new Sound();
        newSound.name = name;
        newSound.clip = Resources.Load<AudioClip>(path);
        newSound.isEffect = isEffect;

        if (newSound.clip != null)
        {
            sounds.Add(newSound);
            return true;
        }

        return false;
    }

    public AudioSource PlaySound(string name)
    {
        return PlaySound(name, 1.0f, false);
    }

    public AudioSource PlaySound(string name, float volume)
    {
        return PlaySound(name, volume, false);
    }

    public AudioSource PlaySound(string name, float volume, bool loop)
    {
        var sound = sounds.Find(s => s.name == name);

        if (sound != null && sound.clip != null)
        {
            var newSource = gameObject.AddComponent<AudioSource>();
            newSource.clip = sound.clip;
            newSource.loop = loop;
            newSource.volume = (sound.isEffect ? effectVolume : musicVolume) * volume;
            newSource.Play();

            _sources.Add(newSource);

            return newSource;
        }
        else
        {
            Debug.LogError("SOUND MANAGER: Failed to play sound: " + name + " since it doesn't exist or the audio clip is empty!");
        }

        return null;
    }

    //Stop a single sound
    public void StopSound(string name)
    {
        foreach (var source in _sources)
        {
            if (source.name == name)
            {
                source.Stop();
            }
        }
    }

    //Stop ALL sounds
    public void StopAll()
    {
        foreach (var source in _sources)
        {
            source.Stop();
        }
    }

    public static SoundManager Instance
    {
        get
        {
            if (_instance == null)
                _instance = FindObjectOfType<SoundManager>();

            return _instance;
        }
    }
}

