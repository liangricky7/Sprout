using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    [SerializeField] private int width, height;

    [SerializeField] private Slot slotPrefab;

    private void Start()
    {
        GenerateGrid();
    }

    void GenerateGrid()
    {
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                var spawnedSlot = Instantiate(slotPrefab, new Vector3(x, y), Quaternion.identity);
                spawnedSlot.name = $"Tile {x} {y}";
            }
        }
    }
}
