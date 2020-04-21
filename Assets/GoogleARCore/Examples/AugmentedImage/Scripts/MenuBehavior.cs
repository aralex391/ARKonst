using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuBehavior : MonoBehaviour
{

    public void Awake()
    {
        Transform cameraPos = Camera.main.transform;
        float distance = 0.5f;
        this.transform.position = cameraPos.position + cameraPos.forward * distance;
    }
}
