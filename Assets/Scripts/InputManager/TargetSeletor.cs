using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetSeletor : MonoBehaviour
{
    public SwitchCamera switchCamera;
    List<CelestialObject> celestialObjects;
    public int ordIndex;
    public void Start()
    {
        celestialObjects = Initialize.GetCelestialObjects();
    }
    public void OnClickEvent()
    {
        switchCamera.cameraTargetIndex = ordIndex;
        switchCamera.target = celestialObjects[ordIndex].gameObject;
        switchCamera.targ.text = "Targ:" + switchCamera.target.name;
        switchCamera.UpdateScale(switchCamera.target.transform.position.magnitude, celestialObjects[switchCamera.cameraObserverIndex].transform.position.magnitude);
        switchCamera.Update();
    }
}
