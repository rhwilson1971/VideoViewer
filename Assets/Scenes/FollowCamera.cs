using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    Camera camera;
    bool mouseDown = false;
    float mouseX;
    float mouseY;

    // Start is called before the first frame update
    public void Start()
    {
        camera = GetComponent<Camera>();
    }

    // Update is called once per frame
    public void Update()
    {
        if (Input.GetMouseButtonDown(0) && !mouseDown)
        {
            mouseDown = true;

            mouseX = Input.mousePosition.x;
            mouseY = Input.mousePosition.y;
        }
        else if (Input.GetMouseButtonUp(0) && mouseDown)
        {
            mouseDown = false;
        }
    }

    public void LateUpdate()
    {
        if (!mouseDown) return;
      
        float mouseXStop = Input.mousePosition.x;
        float mouseYStop = Input.mousePosition.y;
        float deltaX = mouseXStop - mouseX;
        float deltaY = mouseYStop - mouseY;
        float centerXNew = Screen.width / 2 + deltaX;
        float centerYNew = Screen.height / 2 + deltaY;

        Vector3 Gaze = camera.ScreenToWorldPoint(new Vector3(centerXNew, centerYNew, camera.nearClipPlane));
        transform.LookAt(Gaze);
        mouseX = mouseXStop;
        mouseY = mouseYStop;
    }
}
