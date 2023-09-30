using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slot : MonoBehaviour
{
    public Plant plant;

    private void Start()
    {
        plant = GetComponentInChildren<Plant>();
    }
    public void AddNewPlant()
    {
        plant = GetComponentInChildren<Plant>();
    }
}
