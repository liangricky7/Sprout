using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlotButtonUI : MonoBehaviour
{
    public Image addPlantImage;
    public Slot slot;

    private void Update()
    {
        if (PlantManager.instance.inPlantMode)
        {
            if (slot.plant != null)
            {
                var tempColor = addPlantImage.color;
                tempColor.a = 0f;
                addPlantImage.color = tempColor;
            } else
            {
                var tempColor = addPlantImage.color;
                tempColor.a = 1f;
                addPlantImage.color = tempColor;
            }
        } else
        {
            var tempColor = addPlantImage.color;
            tempColor.a = 0f;
            addPlantImage.color = tempColor;
        }
    }
}
