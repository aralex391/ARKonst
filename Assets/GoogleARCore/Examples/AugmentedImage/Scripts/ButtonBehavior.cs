using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonBehavior : Behavior
{
    private string buttonText;

    void Start()
    {
        _TextSetter();
    }

    public override void OnSelect()
    {
        _ShowAndroidToastMessage("");
        _Behave();
    }

    private void _Behave()
    {
        Destroy(this.transform.parent.gameObject);
    }

    private void _TextSetter()
    {
        buttonText = "Exit";
        this.GetComponentInChildren<TextMesh>().text = buttonText;
    }
}
