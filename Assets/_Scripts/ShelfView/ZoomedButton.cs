using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ZoomedButton : MonoBehaviour
{
    private Camera cam;
    private Image image;

    [SerializeField]
    private bool LeftButton; //determines if this script is attached to the left arrow button or right

    [SerializeField]
    private int currentSlotIndex;
    private Slot[] slots;

    private Vector3 originalPosition;
    private Vector3 targetPosition;

    private float transitionDuration = 0.5f;

    private void Start()
    {
        image = GetComponent<Image>();
        cam = Camera.main;
        //Debug.Log(ShelfManager.instance.slots.Length);
    }

    private void Update()
    {
        if (LeftButton)
        {
            if (ShelfManager.instance.currentSlot == 0)
            {
                image.enabled = false;
            } else
            {
                image.enabled = true;
            }
        } else
        {
            if (ShelfManager.instance.currentSlot == 5)
            {
                image.enabled = false;
            }
            else
            {
                image.enabled = true;
            }
        }
    }

    public void LeftArrow()
    {
        this.slots = ShelfManager.instance.slots; //cant call it in start due to async so this is next best

        if (ShelfManager.instance.currentSlot - 1 >= 0)
        {
            currentSlotIndex = ShelfManager.instance.currentSlot;


            //sets original position
            if (slots[currentSlotIndex].plant != null) //null check
            {
                if (slots[currentSlotIndex].plant.growthStage == 2) //if the plant in slot is fully grown, display without questlist
                {
                    originalPosition = slots[currentSlotIndex].transform.position;
                }
                else //otherwise, move camera target to give space to show questlist
                {
                    originalPosition = slots[currentSlotIndex].transform.position - new Vector3(0, 1, 0);
                }
            }
            else //if there is no plant in slot, display without questlist
            {
                originalPosition = slots[currentSlotIndex].transform.position;
            }
            //originalPosition = slots[currentSlotIndex].transform.position;


            //sets target position
            if (slots[currentSlotIndex - 1].plant != null) //null check
            {
                if (slots[currentSlotIndex - 1].plant.growthStage == 2) //if the plant in slot is fully grown, display without questlist
                {
                    targetPosition = slots[currentSlotIndex - 1].transform.position;
                }
                else //otherwise, move camera target to give space to show questlist
                {
                    targetPosition = slots[currentSlotIndex - 1].transform.position - new Vector3(0, 1, 0);
                }
            }
            else //if there is no plant in slot, display without questlist
            {
                targetPosition = slots[currentSlotIndex - 1].transform.position;
            }



            //switch slots
            StartCoroutine(Scroll());

            currentSlotIndex -= 1;
            ShelfManager.instance.currentSlot = currentSlotIndex;
        }
    }

    public void RightArrow()
    {
        this.slots = ShelfManager.instance.slots; //cant call it in start due to async so this is next best

        if (ShelfManager.instance.currentSlot + 1 <= 5)
        {
            currentSlotIndex = ShelfManager.instance.currentSlot;


            //sets original position
            if (slots[currentSlotIndex].plant != null) //null check
            {
                if (slots[currentSlotIndex].plant.growthStage == 2) //if the plant in slot is fully grown, display without questlist
                {
                    originalPosition = slots[currentSlotIndex].transform.position;
                }
                else //otherwise, move camera target to give space to show questlist
                {
                    originalPosition = slots[currentSlotIndex].transform.position - new Vector3(0, 1, 0);
                }
            }
            else //if there is no plant in slot, display without questlist
            {
                originalPosition = slots[currentSlotIndex].transform.position;
            }
            //originalPosition = slots[currentSlotIndex].transform.position;


            //sets target position
            if (slots[currentSlotIndex + 1].plant != null) //null check
            {
                if (slots[currentSlotIndex + 1].plant.growthStage == 2) //if the plant in slot is fully grown, display without questlist
                {
                    targetPosition = slots[currentSlotIndex + 1].transform.position;
                }
                else //otherwise, move camera target to give space to show questlist
                {
                    targetPosition = slots[currentSlotIndex + 1].transform.position - new Vector3(0, 1, 0);
                }
            }
            else //if there is no plant in slot, display without questlist
            {
                targetPosition = slots[currentSlotIndex + 1].transform.position;
            }

            //switch slots
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
