using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantObject : Plant
{
    SpriteRenderer render;

    private void Awake()
    {
        render = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (stepCount >= stepsNeeded) 
        {
            growthStage = 2;
        } else if (stepCount >= (stepsNeeded / 2))
        {
            growthStage = 1;
        } else if (stepCount == 0)
        {
            growthStage = 0;
        }
        render.sprite = sprites[growthStage];

    }
}
