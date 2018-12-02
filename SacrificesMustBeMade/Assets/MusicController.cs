using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class MusicController : MonoBehaviour {

    public AudioClip tutorial;
    public AudioClip[] buttons;
    public AudioClip whispers;
    public AudioMixer mixer;


    AudioSource button;
    AudioSource whisper;
    AudioSource tut;

    void Start()
    {
        button = gameObject.AddComponent<AudioSource>();
        whisper = gameObject.AddComponent<AudioSource>();
        tut = gameObject.AddComponent<AudioSource>();

        button.outputAudioMixerGroup = mixer.FindMatchingGroups("Button")[0];
        tut.outputAudioMixerGroup = mixer.FindMatchingGroups("Tutorial")[0];
        whisper.outputAudioMixerGroup = mixer.FindMatchingGroups("Whispers")[0];
        whisper.loop = true;

        tut.clip = tutorial;
        tut.Play();
    }

    public void TutorialEnd()
    {
        tut.Stop();
        whisper.clip = whispers;
        whisper.Play();
    }

    //public void ButtonClick()
    //{
    //    button.clip = buttons[Random.Range(0, buttons.Length)];
    //    button.loop = false;
    //    button.Play();
    //}

    public void ButtonClick()
    {
        button.clip = buttons[Random.Range(0, buttons.Length)];
        button.loop = false;
        button.Play();
    }
}
