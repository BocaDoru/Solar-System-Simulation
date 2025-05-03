using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ShowMoons : MonoBehaviour
{
    public TMP_Text buttonText;
    public TimeMultiplier timeMultiplier;
    public int timeMultiplierValue;
    public bool value=true;
    public void OnButtonClick()
    {
        value = !value;
        if(value)
        {
            buttonText.color = Color.green;
            buttonText.text = "●";
            if(timeMultiplier.timeMultiplierValue>12)
            {
                timeMultiplierValue = timeMultiplier.timeMultiplierValue;
                timeMultiplier.inputField.text = "12";
                timeMultiplier.OnEndEdit();
            }
        }
        else
        {
            buttonText.color = Color.red;
            buttonText.text = "◌";
            timeMultiplier.inputField.text = timeMultiplierValue.ToString();
            timeMultiplier.OnEndEdit();
        }
    }
}
