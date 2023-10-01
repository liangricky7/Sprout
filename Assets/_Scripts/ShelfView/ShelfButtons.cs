using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShelfButtons : MonoBehaviour
{
    public void AddPlant()
    {
        CanvasManager.instance.AddPlantPanel.SetActive(true); 
    }
}
