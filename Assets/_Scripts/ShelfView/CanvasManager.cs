using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasManager : MonoBehaviour
{
    [SerializeField] private Canvas ShelfCanvas;
    [SerializeField] private Canvas ZoomedCanvas;
    [SerializeField] private Canvas UngrownCanvas;

    public static CanvasManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        } else if (instance != this)
        {
            Destroy(this);
        }

        DontDestroyOnLoad(this);
    }

    private void Start()
    {
        ShelfActivate();
    }

    public void ShelfActivate()
    {
        ShelfCanvas.enabled = true;
        ZoomedCanvas.enabled = false;
    }

    public void ZoomedActivate()
    {
        ShelfCanvas.enabled = false;
        ZoomedCanvas.enabled = true;
    }
}
