using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuBehavior : Behavior
{

    private bool holding;

    private Vector2 originalPosition;

    void Start()
    {
        holding = false;
    }

    public override void OnSelect()
    {
        _ShowAndroidToastMessage("Potates");
    }

    public void Awake()
    {
        Transform cameraPos = Camera.main.transform;
        float distance = 0.5f;
        this.transform.position = cameraPos.position + cameraPos.forward * distance;
    }

    void Update()
    {

        if (holding)
        {
            Rotate();
        }

        // One finger
        if (Input.touchCount == 1)
        {

            // Tap on Object
            if (Input.GetTouch(0).phase == TouchPhase.Began)
            {
                originalPosition = Input.GetTouch(0).position;
                Ray ray = Camera.main.ScreenPointToRay(originalPosition);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit, 100f))
                {
                    if (hit.transform == transform)
                    {
                        holding = true;
                    }
                }
            }

            // Release
            if (Input.GetTouch(0).phase == TouchPhase.Ended)
            {
                holding = false;
            }
        }
    }

    void Rotate()
    {
        float difference = originalPosition.x - Input.GetTouch(0).position.x;
        transform.Rotate(0f, 1.0f * difference * Time.deltaTime, 0f);
    }
}
