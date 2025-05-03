using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Scale : MonoBehaviour
{
    public TMP_InputField inputField;
    public int scale=10;
    int[] intArray;
    public void OnValueChanged()
    {
        intArray = inputField.text.ToIntArray();
        for (int i = 0; i < intArray.Length; i++)
            if (intArray[i] < '0' || intArray[i] > '9' || intArray.Length > 2)
            {
                inputField.text = "";
                break;
            }
    }
    public void OnEndEdit()
    {
        scale = 0;
        for (int i = 0; i < intArray.Length; i++)
            scale = scale * 10 + intArray[i] - '0';
        if (scale > 30)
        {
            scale = 30;
            inputField.text = "30";
        }
        if (scale < 1)
        {
            scale = 1;
            inputField.text = "1";
        }
    }
}
