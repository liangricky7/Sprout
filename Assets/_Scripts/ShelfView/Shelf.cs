using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shelf : MonoBehaviour
{
    public Slot[] slots;
    // Start is called before the first frame update
    void Start()
    {
        slots = GetComponentsInChildren<Slot>();
        ShelfManager.instance.slots = this.slots;
    }
}
