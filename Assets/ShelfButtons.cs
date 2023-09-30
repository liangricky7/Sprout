using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShelfButtons : MonoBehaviour
{
    public float zoom;
    private float originalZoom;
    private float targetZoom = 2f;
    private float zoomMultiplier = 100f;
    private float velocity = 0f;
    private float smoothTime = 0.25f;

    private Camera cam;
        
    private void Start()
    {
        cam = Camera.main;
        zoom = cam.orthographicSize;
        originalZoom = cam.orthographicSize;
    }
    public void ZoomIn()
    {
        zoom -= zoomMultiplier;
        zoom = Mathf.Clamp(zoom, targetZoom, originalZoom);
        cam.orthographicSize = Mathf.SmoothDamp(cam.orthographicSize, zoom, ref velocity, smoothTime);
    }

    public void ZoomOut()
    {

    }

   
}
