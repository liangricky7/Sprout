using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShelfButtons : MonoBehaviour
{
    public float zoom;
    private float originalZoom;
    private float targetZoom = 2f;
    private float zoomMultiplier = 3000f;
    private float transitionDuration = 0.5f;
    private float velocity = 5f;

    private Vector3 originalPosition;
    private Vector3 targetPosition;

    private Camera cam;
    private Coroutine coroutine;

    [SerializeField] private Transform slotTransform;
    private void Start()
    {
        cam = Camera.main;
        zoom = cam.orthographicSize;
        originalZoom = cam.orthographicSize;
        originalPosition = new Vector3(0, 0, -10);
    }
    public void ZoomIn()
    {
        targetPosition = new Vector3(slotTransform.position.x, slotTransform.position.y, -10);
        StartCoroutine(ZoomInEnum());
    }

    IEnumerator ZoomInEnum()
    {
        float timeElapsed = 0;
        while (timeElapsed < transitionDuration)
        {
            cam.transform.position = new Vector3(Mathf.Lerp(originalPosition.x, targetPosition.x, timeElapsed / transitionDuration), Mathf.Lerp(originalPosition.y, targetPosition.y, timeElapsed / transitionDuration), -10);
            cam.orthographicSize = Mathf.Lerp(originalZoom, targetZoom, timeElapsed / transitionDuration);
            timeElapsed += Time.deltaTime;
            yield return null;
        }
    }

    public void ZoomOut()
    {
        StartCoroutine(ZoomOutEnum());
    }

    IEnumerator ZoomOutEnum()
    {
        float timeElapsed = 0;
        while (timeElapsed < transitionDuration)
        {
            cam.transform.position = new Vector3(Mathf.Lerp(targetPosition.x, originalPosition.x, timeElapsed / transitionDuration), Mathf.Lerp(originalPosition.y, targetPosition.y, timeElapsed / transitionDuration), -10);
            cam.orthographicSize = Mathf.Lerp(targetZoom, originalZoom, timeElapsed / transitionDuration);
            timeElapsed += Time.deltaTime;
            yield return null;
        }
    }

}
