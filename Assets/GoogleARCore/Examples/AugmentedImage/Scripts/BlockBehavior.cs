using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockBehavior : MonoBehaviour
{
    public String ImageName;

    public void OnSelect()
    {
        _PlaySound();

        //_ShowAndroidToastMessage(ImageName);
    }

    private void _PlaySound()
    {
        //AudioClip audio = Resources.Load("Sound/newBeginning", typeof(AudioClip)) as AudioClip;

        AudioSource source = this.gameObject.GetComponent<AudioSource>();

        source.clip = Resources.Load("Sound/newBeginning", typeof(AudioClip)) as AudioClip;
            
        source.Play();
    }

    private void _ShowAndroidToastMessage(String message)
    {
        AndroidJavaClass unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        AndroidJavaObject unityActivity =
            unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");

        if (unityActivity != null)
        {
            AndroidJavaClass toastClass = new AndroidJavaClass("android.widget.Toast");
            unityActivity.Call("runOnUiThread", new AndroidJavaRunnable(() =>
            {
                AndroidJavaObject toastObject =
                    toastClass.CallStatic<AndroidJavaObject>(
                        "makeText", unityActivity, message, 0);
                toastObject.Call("show");
            }));
        }
    }
}
