using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasManager : MonoBehaviour
{
    [SerializeField] private Canvas ShelfCanvas;
    [SerializeField] private Canvas ZoomedCanvas;
    [SerializeField] private Canvas UngrownCanvas;
    [SerializeField] public GameObject AddPlantPanel;

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

    //private void Update()
    //{
    //    GameObject[] CanvasObjects = GameObject.FindGameObjectsWithTag("Canvas");
    //    GameObject ShelfC, ZoomC, UngrownC, PlantPanel;

    //    foreach (var i in CanvasObjects)
    //    {
    //        if ((i.name).Equals("ShelfCanvas")) {
    //            ShelfCanvas = i.GetComponent<Canvas>();
    //        }
    //        if ((i.name).Equals("ShelfCanvas"))
    //        {
    //            ShelfCanvas = i.GetComponent<Canvas>();
    //        }
    //        if ((i.name).Equals("ShelfCanvas"))
    //        {
    //            UngrownCanvas = i.GetComponent<Canvas>();
    //        }
    //        if ((i.name).Equals("ShelfCanva"))
    //        {
    //            AddPlantPanel = i;
    //        }
    //    }

    //}

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

    public void UngrownActivate()
    {
        UngrownCanvas.enabled = true;
    }

    public void UngrownDeactivate()
    {
        UngrownCanvas.enabled = false;
    }
}
