using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ObserverSelector : MonoBehaviour
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
        celestialObjects[switchCamera.cameraObserverIndex].trail.time = celestialObjects[switchCamera.cameraObserverIndex].trailTime;
        celestialObjects[switchCamera.cameraObserverIndex].showTrail = true;
        switchCamera.cameraObserverIndex = ordIndex;
        switchCamera.observer = celestialObjects[ordIndex].gameObject;
        switchCamera.obs.text = "Obs:" + switchCamera.observer.name;
        celestialObjects[switchCamera.cameraObserverIndex].trail.time = 0;
        celestialObjects[switchCamera.cameraObserverIndex].showTrail = false;
        switchCamera.UpdateScale(switchCamera.observer.transform.position.magnitude, celestialObjects[switchCamera.cameraTargetIndex].transform.position.magnitude);
        switchCamera.Update();
    }
}
