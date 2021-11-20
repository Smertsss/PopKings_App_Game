
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundControll : MonoBehaviour
{
    [SerializeField] private AudioSource myFx;
    public bool popcorn;
    [SerializeField]
    private AudioClip Click;
    void Start()
    {
        if (popcorn == true)
        {
            myFx.pitch = Random.Range(0.8f, 1.8f);
        }
    }
   
    public void ClickSound()
    {
        myFx.PlayOneShot(Click);
    }
}
