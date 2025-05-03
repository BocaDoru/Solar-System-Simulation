using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TimeMultiplier : MonoBehaviour
{
    public TMP_InputField inputField;
    public Slider slider;
    public ShowMoons showMoons;
    int[] intArray;
    public int timeMultiplierValue = 1;
    public void OnValueChangedInputField()
    {
        intArray = inputField.text.ToIntArray();
        for (int i = 0; i < intArray.Length; i++)
            if (intArray[i] < '0' || intArray[i] > '9'|| intArray.Length > 2)
            {
                inputField.text = "";
                break;
            }
    }
    public void OnValueChangedSlider()
    {
        inputField.text = slider.value.ToString();
        OnEndEdit();
    }
    public void OnEndEdit()
    {
        timeMultiplierValue = 0;
        intArray = inputField.text.ToIntArray();
        for (int i = 0; i < intArray.Length; i++)
            timeMultiplierValue = timeMultiplierValue * 10 + intArray[i] - '0';
        if(showMoons.value&&timeMultiplierValue>12)
        {
            timeMultiplierValue = 12;
            inputField.text = "12";
        }
        else
            showMoons.timeMultiplierValue = timeMultiplierValue;
        if (timeMultiplierValue > 50)
        {
            timeMultiplierValue = 50;
            inputField.text = "50";
        }
        if(timeMultiplierValue<1)
        {
            timeMultiplierValue = 1;
            inputField.text = "1";
        }
        slider.value = timeMultiplierValue;
    }
}
