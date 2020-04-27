using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySoundButtonBehavior : ButtonBehavior
{
    AudioSource source;

    private bool SoundSwitch = false;

    void Awake()
    {
        _TextSetter("Play");

        source = this.gameObject.GetComponent<AudioSource>();

        source.clip = Resources.Load("Sound/newBeginning", typeof(AudioClip)) as AudioClip;
    }

    public override void OnSelect()
    {
        _PlaySound();
    }

    private void _PlaySound()
    {
        if (SoundSwitch == false)
        {
            source.Play();

            SoundSwitch = true;

            _TextSetter("Stop");
        }
        else
        {
            source.Stop();

            SoundSwitch = false;

            _TextSetter("Play");
        }
    }
}
