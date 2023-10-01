using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlantModeButtons : MonoBehaviour
{
    public Image seedPacketSlot;
    public Image title;

    public Sprite[] seedPackets;
    public Sprite[] titles;

    public Image Left;
    public Image Right;

    private int index = 0;

    private void Update()
    {
        if (index - 1 >= 0)
        {
            Left.enabled = true;
        }
        else
        {
            Left.enabled = false;
        }

        if (index + 1 < seedPackets.Length)
        {
            Right.enabled = true;
        }
        else
        {
            Right.enabled = false;
        }
        seedPackets = PlantManager.instance.seedPackets;
        titles = PlantManager.instance.titles;
    }

    public void LeftArrow()
    {
        index--;
        title.sprite = titles[index];
        seedPacketSlot.sprite = seedPackets[index];
    }

    public void RightArrow()
    {
        index++;
        title.sprite = titles[index];
        seedPacketSlot.sprite = seedPackets[index];

    }

    public void Select()
    {
        PlantManager.instance.stagedPlantPrefab = PlantManager.instance.plantPrefabs[index];
        index = 0;
        CanvasManager.instance.AddPlantPanel.SetActive(false);
        PlantManager.instance.inPlantMode = true;
    }
}
