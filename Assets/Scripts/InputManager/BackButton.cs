using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackButton : MonoBehaviour
{
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            OnClick();
    }
    public void OnClick()
    {
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Settings"))
            Application.Quit(0);
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("SolarSystem"))
            SceneManager.LoadScene("Settings");
    }
}