using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public Audio[] audios;

    //Keeps tracks of whether or not an instance of the AudioManager exists (since it will persist between scenes)
    private static AudioManager currentInstance;

    // Start is called before the first frame update
    void Start()
    {
        //If the audio manager doesn't exist yet, let this new one be it
        if (currentInstance == null)
        {
            currentInstance = this;
        }
        //Otherwise, destory the new one, we don't need it
        else
        {
            Destroy(gameObject);
        }

        //Prevents the audio manager from being killed when the next scene is loaded
        DontDestroyOnLoad(gameObject);

        //Initializes each audio clip with the parameters we specified in the editor
        foreach (Audio audio in audios)
        {
            audio.source = gameObject.AddComponent<AudioSource>();

            audio.source.clip = audio.clip;
            audio.source.name = audio.name;
            audio.source.volume = audio.volume;
            audio.source.pitch = audio.pitch;
            audio.source.loop = audio.loop;
        }

        //Also, play the theme song on load
        playSound("Hit the Deck");
    }

    public void playSound (string soundName)
    {
        //Looks through the array to find the named audio
        Audio sound = Array.Find(audios, audio => audio.name == soundName);

        //If it wan't found, report it as a warning
        if (sound == null)
        {
            Debug.LogWarning(soundName + " not found!");
            return;
        }

        sound.source.Play();
    }
}
