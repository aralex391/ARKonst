using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockBehavior : Behavior
{
    public String ImageName;

    [SerializeField]
    private GameObject MenuCube;

    AudioSource source;

    private bool SoundSwitch = false;

    public void Awake()
    {
        source = this.gameObject.GetComponent<AudioSource>();

        source.clip = Resources.Load("Sound/newBeginning", typeof(AudioClip)) as AudioClip;
    }

    public override void OnSelect()
    {
        //_PlaySound();

        _Behave();

        _ShowAndroidToastMessage(ImageName);
    }

    private void _Behave()
    {
        Instantiate(MenuCube);
    }

    private void _PlaySound()
    {
        if (SoundSwitch == false)
        {
            source.Play();

            SoundSwitch = true;
        } else
        {
            source.Stop();

            SoundSwitch = false;
        }        
    }
}
