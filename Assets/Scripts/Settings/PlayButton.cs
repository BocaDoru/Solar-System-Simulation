using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayButton : MonoBehaviour
{
    public Scale scale;
    public ShowMoons showMoons;
    public ShowOrbit showOrbit;
    public TimeMultiplier timeMultiplier;
    public void OnButtonClick()
    {
        Initialize.SetScale(scale.scale);
        Initialize.SetShowMoonsValue(showMoons.value);
        Initialize.SetShowOrbitValue(showOrbit.value);
        Initialize.SetTimeMultiplier(timeMultiplier.timeMultiplierValue*3600*24);
        SceneManager.LoadScene("SolarSystem");
    }
}
