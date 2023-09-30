using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShelfButtons : MonoBehaviour
{
    public float zoom;
    private float originalZoom;
    private float targetZoom = 1f;
    private float zoomMultiplier = 3000f;
    private float velocity = 5f;
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
        StartCoroutine(ZoomInEnum());
    }

    IEnumerator ZoomInEnum()
    {
        while (zoom > targetZoom)
        {
            cam.orthographicSize = Mathf.Lerp(originalZoom, targetZoom, 1f);
            yield return null;
        }
    }

    public void ZoomOut()
    {

    }

   
}
