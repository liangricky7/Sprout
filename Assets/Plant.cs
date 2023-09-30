using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Plant : MonoBehaviour
{
    public string name;
    public int stepCount;
    public Quest[] questList;
    public Sprite sprite;
}
