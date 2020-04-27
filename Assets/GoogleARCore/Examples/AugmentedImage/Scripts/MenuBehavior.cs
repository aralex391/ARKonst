using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuBehavior : Behavior
{
    private static GameObject _activeInstance = null;

    private bool holding;

    private Vector2 originalPosition;

    private bool selected;

    new static protected string ImageName;

    public static GameObject ActiveInstance
    {
        get
        {
            if (_activeInstance == null)
            {
                var menus = GameObject.FindGameObjectsWithTag("Menu");
                if (menus.Length > 0)
                {
                    _activeInstance = menus[0].gameObject;
                }
                else
                {
                    _ShowAndroidToastMessage("No instance of menu exists in the scene.");
                }
            }

            return _activeInstance;
        }
        set
        {
            _activeInstance = value;
        }
    }

    void Awake()
    {
        holding = false;
        selected = false;

        _OnlyOne();
        _Placement();
    }

    public override void OnSelect()
    {
        selected = true;
    }

    public override void SetName(string name)
    {
        ImageName = name;
    }

    void Update()
    {
        if (selected)
        {
            if (holding)
            {
                _Rotate();
            }

            // One finger
            if (Input.touchCount == 1)
            {

                // Tap on Object
                if (Input.GetTouch(0).phase == TouchPhase.Began)
                {
                    originalPosition = Input.GetTouch(0).position;
                    holding = true;
                }

                // Release
                if (Input.GetTouch(0).phase == TouchPhase.Ended)
                {
                    holding = false;
                }
            }
        }
    }

    private void _OnlyOne()
    {
        if (ActiveInstance != this.gameObject)
        {
            Destroy(ActiveInstance);
            ActiveInstance = this.gameObject;
        }
    }

    private void _Placement()
    {
        Transform cameraPos = Camera.main.transform;
        float distance = 0.5f;
        this.transform.position = cameraPos.position + cameraPos.forward * distance;
    }

    private void _Rotate()
    {
        float difference = originalPosition.x - Input.GetTouch(0).position.x;
        transform.Rotate(0f, 1.0f * difference * Time.deltaTime, 0f);
    }
}
