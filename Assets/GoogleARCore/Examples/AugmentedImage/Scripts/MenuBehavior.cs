using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuBehavior : Behavior
{
    private static GameObject _activeInstance = null;

    private bool holding;

    private Vector2 originalPosition;

    private bool selected;

    public static GameObject ActiveInstance
    {
        get
        {
            if (_activeInstance == null)
            {
                var menuBehaviors = FindObjectsOfType<MenuBehavior>();
                if (menuBehaviors.Length > 0)
                {
                    _activeInstance = menuBehaviors[0].gameObject;
                }
                else
                {
                    _ShowAndroidToastMessage("No instance of menuBehaviors exists in the scene.");
                }
            }

            return _activeInstance;
        }
        set
        {
            _activeInstance = value;
        }
    }

    public void Start()
    {
        holding = false;
        selected = false;
    }

    public override void OnSelect()
    {
        selected = true;
        _ShowAndroidToastMessage("Selected");
    }

    public void Awake()
    {
        _OnlyOne();
        _Placement();
    }

    public void Update()
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
