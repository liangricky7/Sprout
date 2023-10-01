using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ZoomedButton : MonoBehaviour
{
    private Camera cam;

    private Slot[] slots;
    [SerializeField]
    private int currentSlotIndex;

    private Vector3 originalPosition;
    private Vector3 targetPosition;

    private float transitionDuration = 0.5f;

    private void Start()
    {
        cam = Camera.main;
        //Debug.Log(ShelfManager.instance.slots.Length);
    }

    public void LeftArrow()
    {
        this.slots = ShelfManager.instance.slots; //cant call it in start due to async so this is next best
        Debug.Log("attempted");

        if (ShelfManager.instance.currentSlot - 1 >= 0)
        {
            currentSlotIndex = ShelfManager.instance.currentSlot;
            originalPosition = slots[currentSlotIndex].transform.position;
            targetPosition = slots[currentSlotIndex - 1].transform.position;
            StartCoroutine(Scroll());
            currentSlotIndex -= 1;
            ShelfManager.instance.currentSlot = currentSlotIndex;
        }
    }

    public void RightArrow()
    {
        this.slots = ShelfManager.instance.slots; //cant call it in start due to async so this is next best

        currentSlotIndex = ShelfManager.instance.currentSlot;
        if (currentSlotIndex + 1 <= 5)
        {
            originalPosition = slots[currentSlotIndex].transform.position;
            targetPosition = slots[currentSlotIndex + 1].transform.position;
            StartCoroutine(Scroll());
            currentSlotIndex += 1;
            ShelfManager.instance.currentSlot = currentSlotIndex;

        }
    }

    IEnumerator Scroll()
    {
        float timeElapsed = 0;
        while (timeElapsed < transitionDuration)
        {
            cam.transform.position = new Vector3(Mathf.Lerp(originalPosition.x, targetPosition.x, timeElapsed / transitionDuration), Mathf.Lerp(originalPosition.y, targetPosition.y, timeElapsed / transitionDuration), -10);
            timeElapsed += Time.deltaTime;
            yield return null;
        }
    }
}
