using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ShowOrbit : MonoBehaviour
{
    public TMP_Text buttonText;
    public bool value = true;
    public void OnButtonClick()
    {
        value = !value;
        if(value)
        {
            buttonText.text = "○";
            buttonText.color = Color.green;
        }
        else
        {
            buttonText.text = "◌";
            buttonText.color = Color.red;
        }
    }
}
