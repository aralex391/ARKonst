using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitButtonBehavior : ButtonBehavior
{
    void Awake()
    {
        _TextSetter("Exit");
    }

    public override void OnSelect()
    {
        Destroy(this.transform.parent.gameObject);
    }
}
