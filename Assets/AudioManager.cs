using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header ("-----Audio Source------")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;

    [Header("-----Audio Clip------")]
    public AudioClip background;
    public AudioClip click;
    public AudioClip coin;
    public AudioClip police_car;
    public AudioClip earthquake;

    private void Start()
    {

        musicSource.clip = background;
        musicSource.loop = true;
        musicSource.Play();
     }

    public void PlaySFX(AudioClip clip) 
    {
        SFXSource.PlayOneShot(clip);
    }
    public void StopSFX()
    {
        SFXSource.Stop();
    }

}
