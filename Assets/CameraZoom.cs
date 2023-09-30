using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoom : MonoBehaviour
{
    private float zoom;
    private float zoomMultiplier = 4f;
    private float minZoom = 2f;
    private float maxZoom = 8f;
    private float velocity = 0f;
    private float smoothTime = 0.25f;

    private Camera cam;

    private void Awake()
    {
        cam = Camera.main;
    }
    // Start is called before the first frame update
    void Start()
    {
        zoom = cam.orthographicSize;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
