using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ButtonBehavior : MenuBehavior
{
    abstract public override void OnSelect();

    protected void _TextSetter(string buttonText)
    {
        this.GetComponentInChildren<TextMesh>().text = buttonText;
    }
}
