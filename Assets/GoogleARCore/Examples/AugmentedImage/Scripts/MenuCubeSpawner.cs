using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuCubeSpawner : MonoBehaviour
{
    public GameObject MenuCube;

    void Start()
    {
        Instantiate(MenuCube);
    }
}
