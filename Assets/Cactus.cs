using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cactus: Plant
{
    SpriteRenderer render;
    private void Awake()
    {
        render = GetComponent<SpriteRenderer>();
    }
    void Start()
    {

    }

    void Update()
    {
        if (stepCount >= stepsNeeded) 
        {
            growthStage = 2;
        } else if (stepCount >= (stepsNeeded / 2))
        {
            growthStage = 1;
        }
        render.sprite = sprites[growthStage];

    }
}
