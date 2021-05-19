using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXManager : MonoBehaviour
{
    public GameObject soundPrefab;
    private AudioSource[] sounds = new AudioSource[100];

    void Start()
    {
        for (int i = 0; i < sounds.Length; ++i)
        {
            sounds[i] = GameObject.Instantiate(soundPrefab).GetComponent<AudioSource>();
            sounds[i].transform.parent = transform;
        }
    }

    public void PlaySound(AudioClip clip, Vector3 posicion)
    {
        for (int i = 0; i < sounds.Length; ++i)
        {
            if (!sounds[i].isPlaying)
            {
                sounds[i].transform.position = posicion;
                sounds[i].PlayOneShot(clip);
                break;
            }
        }
    }
}
