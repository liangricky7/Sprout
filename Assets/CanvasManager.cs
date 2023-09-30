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
}
