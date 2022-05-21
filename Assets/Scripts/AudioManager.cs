using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    public AudioClip win, correct, error, button;
    public AudioSource audio;

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    
    public void WinFx()
    {
        audio.clip = win;
        audio.Play();
    }
    public void Correct()
    {
        audio.clip = correct;
        audio.Play();
    }
    public void Error()
    {
        audio.clip = error;
        audio.Play();
    }
    public void ButtonFx()
    {
        audio.clip = button;
        audio.Play();
    }
}
