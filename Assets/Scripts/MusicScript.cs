using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicScript : MonoBehaviour
{
    [SerializeField]
    private AudioClip background;
    [SerializeField]
    private AudioClip start;
    [SerializeField]
    private AudioClip victory;
    [SerializeField]
    private AudioClip lose;

    private AudioSource music;
    void Start()
    {
        music = GetComponent<AudioSource>();
        music.clip = start;
        music.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (!music.isPlaying)
        {
            music.clip = background;
            music.Play();
        }
    }
}
