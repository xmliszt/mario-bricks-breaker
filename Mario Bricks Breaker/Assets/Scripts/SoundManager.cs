using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource source;
    public AudioClip sparkSound;
    public AudioClip explosionSound;
    public AudioClip shootSound;

    public void PlaySpark()
    {
        source.PlayOneShot(sparkSound);
    }

    public void PlayExplosion()
    {
        source.PlayOneShot(explosionSound);
    }

    public void PlayShoot()
    {
        source.PlayOneShot(shootSound);
    }
}
