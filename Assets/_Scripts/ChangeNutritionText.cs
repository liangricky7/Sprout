using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeNutritionText : MonoBehaviour
{
    public string nutritionList;
    public GameObject inputField;
    public GameObject textDisplay;

    public void addFood()
    {
        nutritionList = inputField.GetComponent<Text>().text;
        textDisplay.GetComponent<Text>().text = nutritionList;
    }
}
