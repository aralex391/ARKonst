using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BlockBehavior : Behavior
{
    [SerializeField]
    private GameObject MenuCube;

    public override void SetName(string name)
    {
        base.SetName(name);
        _TextGetter();
    }

    public override void OnSelect()
    {
        var obj = (GameObject)Instantiate(MenuCube);
        obj.GetComponent<MenuBehavior>().SetName(ImageName);
    }

    private void _TextGetter()
    {
        TextAsset info = Resources.Load("Text/" + ImageName) as TextAsset;

        this.transform.parent.GetComponentInChildren<TextMeshPro>().text = info.ToString();
    }
}
