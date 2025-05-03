using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectMenuInput : MonoBehaviour
{
    public GameObject obsScr, targScr, obsTxt, targTxt;
    public bool setActive = false;
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            setActive = !setActive;
            obsScr.SetActive(setActive);
            obsTxt.SetActive(setActive);
            targScr.SetActive(setActive);
            targTxt.SetActive(setActive);
        }
    }
}
