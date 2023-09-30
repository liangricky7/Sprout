using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Plant : MonoBehaviour
{
    public string name;
    public int stepCount;
    public int growthStage; //0 for infant, 1 for juvenile, 2 for grown
    public Quest[] questList;
    public Sprite[] sprites;
}
