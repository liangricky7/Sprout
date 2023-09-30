using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasManager : MonoBehaviour
{
    [SerializeField] private Canvas ShelfCanvas;
    [SerializeField] private Canvas UngrownCanvas;
    [SerializeField] private Canvas GrownCanvas;

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
        UngrownCanvas.enabled = false;
        GrownCanvas.enabled = false;
    }

    public void UngrownActivate()
    {
        ShelfCanvas.enabled = false;
        UngrownCanvas.enabled = true;
        GrownCanvas.enabled = false;
    }

    public void GrownActivate()
    {
        ShelfCanvas.enabled = false;
        UngrownCanvas.enabled = false;
        GrownCanvas.enabled = true;
    }
}
