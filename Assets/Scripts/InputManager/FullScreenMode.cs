using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FullScreenMode : MonoBehaviour
{
    public static bool fullScreenMode=true;
    public void Start()
    {
        Screen.fullScreen = fullScreenMode;
    }
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.F11))
        {
            fullScreenMode = !fullScreenMode;
            Screen.fullScreen = fullScreenMode;
        }
    }
}