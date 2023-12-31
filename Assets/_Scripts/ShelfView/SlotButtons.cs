using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotButtons : MonoBehaviour
{
    public float zoom;
    private float originalZoom;
    private float targetZoom = 2.8f;
    private float transitionDuration = 0.5f;

    private Vector3 originalPosition;
    private Vector3 targetPosition;

    private Camera cam;

    [SerializeField] private Transform slotTransform;
    [SerializeField] private Slot slot; //assigned only for the shelf buttons 
    private Slot[] slots;
    private void Start()
    {
        cam = Camera.main;
        zoom = cam.orthographicSize;
        originalZoom = cam.orthographicSize;
        originalPosition = new Vector3(0, 0, -10);
    }

    public void ZoomIn() //attached to shelf canvas
    {
        if (!PlantManager.instance.inPlantMode)
        {
            targetPosition = new Vector3(slotTransform.position.x, slotTransform.position.y, -10);
            ShelfManager.instance.currentSlot = slot.index;
            StartCoroutine(ZoomInEnum());
        }
    }

    IEnumerator ZoomInEnum()
    {
        slots = ShelfManager.instance.slots;

        if (slots[slot.index].plant != null) //null check
        {
            if (slots[slot.index].plant.growthStage == 2) //if the plant in slot is fully grown, display without questlist
            {
                targetPosition = slots[slot.index].transform.position;
            }
            else //otherwise, move camera target to give space to show questlist
            {
                targetPosition = slots[slot.index].transform.position - new Vector3(0, 1, 0);
            }
        }
        else //if there is no plant in slot, display without questlist
        {
            targetPosition = slots[slot.index].transform.position;
        }

        //pulls up questlist
        if (slots[slot.index].plant != null && slots[slot.index].plant.growthStage != 2)
        {
            Debug.Log("test");
            CanvasManager.instance.UngrownActivate();
        }

        float timeElapsed = 0;
        while (timeElapsed < transitionDuration)
        {
            cam.transform.position = new Vector3(Mathf.Lerp(originalPosition.x, targetPosition.x, timeElapsed / transitionDuration), Mathf.Lerp(originalPosition.y, targetPosition.y, timeElapsed / transitionDuration), -10);
            cam.orthographicSize = Mathf.Lerp(originalZoom, targetZoom, timeElapsed / transitionDuration);
            timeElapsed += Time.deltaTime;
            yield return null;
        }
        CanvasManager.instance.ZoomedActivate();
        ShelfManager.instance.currentSlot = slot.index;
    }

    public void ZoomOut()
    {
        if (!PlantManager.instance.inPlantMode)
        {
            StartCoroutine(ZoomOutEnum());
            CanvasManager.instance.ShelfActivate();
        }
    }

    IEnumerator ZoomOutEnum()
    {
        targetPosition = ShelfManager.instance.slots[ShelfManager.instance.currentSlot].transform.position;

        float timeElapsed = 0;
        while (timeElapsed < transitionDuration)
        {
            cam.transform.position = new Vector3(Mathf.Lerp(targetPosition.x, originalPosition.x, timeElapsed / transitionDuration), Mathf.Lerp(targetPosition.y, originalPosition.y, timeElapsed / transitionDuration), -10);
            cam.orthographicSize = Mathf.Lerp(targetZoom, originalZoom, timeElapsed / transitionDuration);
            timeElapsed += Time.deltaTime;
            yield return null;
        }
        CanvasManager.instance.UngrownDeactivate();
        ShelfManager.instance.currentSlot = -1;
    }

    public void AddPlant()
    {
        if (PlantManager.instance.inPlantMode)
        {
            GameObject plant = Instantiate(PlantManager.instance.stagedPlantPrefab, new Vector3(0, 0, 0), Quaternion.identity);
            plant.transform.parent = slot.transform;
            plant.transform.position = slot.transform.position;
            plant.transform.localScale = new Vector3(0.1737001f, 0.1487517f, 0f);
            slot.AddNewPlant();
            PlantManager.instance.inPlantMode = false;
        }
    }
}
