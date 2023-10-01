using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShelfButtons : MonoBehaviour
{
    public float zoom;
    private float originalZoom;
    private float targetZoom = 2f;
    private float transitionDuration = 0.5f;

    private Vector3 originalPosition;
    private Vector3 targetPosition;

    private Camera cam;

    [SerializeField] private Transform slotTransform;
    [SerializeField] private Slot slot; //assigned only for the shelf buttons 

    private void Start()
    {
        cam = Camera.main;
        zoom = cam.orthographicSize;
        originalZoom = cam.orthographicSize;
        originalPosition = new Vector3(0, 0, -10);
    }

    public void ZoomIn() //attached to shelf canvas
    {
        targetPosition = new Vector3(slotTransform.position.x, slotTransform.position.y, -10);
        ShelfManager.instance.currentSlot = slot.index;
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
        CanvasManager.instance.ZoomedActivate();
    }

    public void ZoomOut()
    {
        ShelfManager.instance.currentSlot = -1;
        StartCoroutine(ZoomOutEnum());
        CanvasManager.instance.ShelfActivate();
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
