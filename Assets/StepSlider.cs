using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StepSlider : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] private TextMeshProUGUI sliderText;
    private int maxValue;
    private int previousIndex = -1;

    // Start is called before the first frame update
    void Start()
    {
        slider.onValueChanged.AddListener((v) =>
        {
            sliderText.text = v.ToString() + "/" + ShelfManager.instance.slots[ShelfManager.instance.currentSlot].plant.stepsNeeded;
        });
    }
    public void ResetValue()
    {
        slider.value = 0;
    }

    // Update is called once per frame
    void Update()
    {
        ShelfManager.instance.slots[ShelfManager.instance.currentSlot].plant.stepCount = (int)slider.value;
        if (ShelfManager.instance.currentSlot != previousIndex)
        {
            ResetValue();
        }

        previousIndex = ShelfManager.instance.currentSlot;
    }
}
