using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private Camera cam;

    private float zoomStep = 10;
    private float minCamSize = 9f;
    private float maxCamSize = 33f;

    private Vector3 dragOrigin;

    private void PanCamera()
    {
        if(Input.GetMouseButtonDown(1))
        {
            dragOrigin = cam.ScreenToViewportPoint(Input.mousePosition);
        }
        if(Input.GetMouseButton(1))
        {
            Vector3 difference = dragOrigin - cam.ScreenToViewportPoint(Input.mousePosition);
            cam.transform.position += difference;

        }
    }
    private void Zoom()
    {
        cam.orthographicSize -=Input.GetAxis("Mouse ScrollWheel") * zoomStep;
        cam.orthographicSize = Mathf.Clamp(cam.orthographicSize, minCamSize, maxCamSize);
    }
    private void Update()
    {
        Zoom();
        PanCamera();
    }
}
