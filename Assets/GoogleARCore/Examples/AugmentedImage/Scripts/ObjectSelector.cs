using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSelector : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        _CheckTap();
    }

    private void _CheckTap()
    {
        if ((Input.touchCount > 0) && (Input.GetTouch(0).phase == TouchPhase.Began))
        {
            Ray raycast = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            RaycastHit raycastHit;
            if (Physics.Raycast(raycast, out raycastHit))
            {
                GameObject hitObject = raycastHit.collider.gameObject;
                hitObject.GetComponent<Behavior>().OnSelect();
            }
        }
    }
}
