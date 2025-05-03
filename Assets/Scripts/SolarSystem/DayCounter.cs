using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DayCounter : MonoBehaviour
{
    public float days = 0;
    public TMP_Text daysCounter;
    public void FixedUpdate()
    {
        days += Time.fixedDeltaTime * Initialize.GetTimeMultiplier() / (3600 * 24);
        daysCounter.text = "Day:" + ((int)days).ToString();
    }
}
