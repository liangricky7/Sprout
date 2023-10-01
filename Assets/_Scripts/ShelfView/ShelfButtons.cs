using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShelfButtons : MonoBehaviour
{
    public void AddPlant()
    {
        PlantManager.instance.EnterPlantMode();
    }
}
