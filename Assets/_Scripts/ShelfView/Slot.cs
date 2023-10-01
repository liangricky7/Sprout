using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slot : MonoBehaviour
{
    public Plant plant;
    public int index;

    private void Start()
    {
        plant = GetComponentInChildren<Plant>();
        index = transform.GetSiblingIndex();
    }
    public void AddNewPlant()
    {
        plant = GetComponentInChildren<Plant>();
    }
}
