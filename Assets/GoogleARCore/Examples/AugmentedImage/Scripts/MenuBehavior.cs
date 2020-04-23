using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuBehavior : Behavior
{
    private static GameObject _activeInstance = null;

    private bool holding;

    private Vector2 originalPosition;

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
                    _ShowAndroidToastMessage("No instance of ManipulationSystem exists in the scene.");
                }
            }

            return _activeInstance;
        }
        set
        {
            _activeInstance = value;
        }
    }

    void Start()
    {
        holding = false;
    }

    public override void OnSelect()
    {
        //SELECT SYSTEM NOT IN EXISTENCE
        _ShowAndroidToastMessage("Potates");
    }

    public void Awake()
    {
        OnlyOne();
        Placement();
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

    public void OnlyOne()
    {
        // Come up with a better solution if you have one
        //var menuBehaviors = FindObjectsOfType<MenuBehavior>();
        if (ActiveInstance != this.gameObject)
        {
            _ShowAndroidToastMessage("Delete me daddy!");
            Destroy(ActiveInstance);
            ActiveInstance = this.gameObject;

           /* for (int i = 0; i < menuBehaviors.Length; i++)
            {
                if (menuBehaviors[i].gameObject != this.gameObject)
                {
                    Destroy(menuBehaviors[i].gameObject);
                }
            }*/
        }
    }

    public void Placement()
    {
        Transform cameraPos = Camera.main.transform;
        float distance = 0.5f;
        this.transform.position = cameraPos.position + cameraPos.forward * distance;
    }

    void Rotate()
    {
        float difference = originalPosition.x - Input.GetTouch(0).position.x;
        transform.Rotate(0f, 1.0f * difference * Time.deltaTime, 0f);
    }
}
