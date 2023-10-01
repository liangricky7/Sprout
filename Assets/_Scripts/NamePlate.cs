using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NamePlate : MonoBehaviour
{
    public Image nameSpace;

    private void Update()
    {
        if (ShelfManager.instance.slots[ShelfManager.instance.currentSlot].plant != null)
        {
            nameSpace.enabled = true;
            nameSpace.sprite = ShelfManager.instance.slots[ShelfManager.instance.currentSlot].plant.title;
        }
        else
        {
            nameSpace.enabled = false;
        }
    }

}
