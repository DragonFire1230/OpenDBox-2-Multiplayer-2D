using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickAndDrag : MonoBehaviour
{
    public GameObject cameraObj;
    public GameObject selectedObject;
    public KeyCode lcX;
    public KeyCode lcY;
    public KeyCode lcZ;
    Vector3 offset;

    void Update()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // Camera
        if (Input.GetKey(lcY)) {
            cameraObj.transform.position = new Vector3(cameraObj.transform.position.x, cameraObj.transform.position.y + Input.mouseScrollDelta.y / 2, -10);
        }
        if (Input.GetKey(lcX)) {
            cameraObj.transform.position = new Vector3(cameraObj.transform.position.x + Input.mouseScrollDelta.y / 2, cameraObj.transform.position.y, -10);
        }
        if (Input.GetKey(lcZ)) {
            GetComponent<Camera>().orthographicSize = GetComponent<Camera>().orthographicSize - Input.mouseScrollDelta.y;
        }

        // Object
        if (Input.GetMouseButtonDown(0))
        {
            Collider2D targetObject = Physics2D.OverlapPoint(mousePosition);
            if (targetObject)
            {
                selectedObject = targetObject.transform.gameObject;
                offset = selectedObject.transform.position - mousePosition;
            }
        }
        if (selectedObject)
        {
            selectedObject.transform.position = mousePosition + offset;
        }
        if (Input.GetMouseButtonUp(0) && selectedObject)
        {
            selectedObject = null;
        }
    }
}