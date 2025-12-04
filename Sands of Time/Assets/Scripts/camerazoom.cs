using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camerazoom : MonoBehaviour
{
    private Camera cam;
    public float TargetZoom = 3f; // the zoom value I want by manipulating the camera size
    private float ScrollData; // value from mouse scrolling
    public float ZoomSpeed = 3f; // speed of zooming process in or out

    void Start()
    {
        cam = GetComponent<Camera>();
        TargetZoom = cam.orthographicSize; // start with the current camera size
    }

    void Update()
    {
        // Get scroll input: +ve when scrolling up, -ve when scrolling down
        ScrollData = Input.GetAxis("Mouse ScrollWheel");

        // Update the target zoom
        TargetZoom -= ScrollData;

        // Clamp the zoom limits
        TargetZoom = Mathf.Clamp(TargetZoom, 3f, 6f);

        // Smoothly transition between current and target zoom levels
        cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, TargetZoom, Time.deltaTime * ZoomSpeed);
    }
}
