using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlantManager : MonoBehaviour
{
    public GameObject[] plantPrefabs;
    public Sprite[] seedPackets;
    public Sprite[] titles;

    public Plant selectedPlant;
    public GameObject stagedPlantPrefab;
    public bool inPlantMode;

    public static PlantManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(this);
        }

        DontDestroyOnLoad(this);
        inPlantMode = false;
    }

    public void EnterPlantMode()
    {
        inPlantMode = true;
    }
    public void ExitPlantMode()
    {
        inPlantMode = false;
    }
}
