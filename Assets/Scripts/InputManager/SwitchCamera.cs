using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SwitchCamera : MonoBehaviour
{
    public Camera mainCamera;
    public int cameraObserverIndex = 0;
    public int cameraTargetIndex = 0;
    public int maxCameraIndex;
    public List<CelestialObject> celestialObjects;
    public GameObject observer;
    public GameObject target;
    public TMP_Text obs;
    public TMP_Text targ;
    public bool update = false;
    public int updateCount = 0;
    int oldTimeMultiplier;
    int oldScale;
    private void Start()
    {
        celestialObjects = Initialize.GetCelestialObjects();
        maxCameraIndex = Initialize.GetMaxCameraIndex();
        oldTimeMultiplier = Initialize.GetTimeMultiplier();
        oldScale = Initialize.GetScale();
    }
    public void Update()
    {
        if (update && updateCount < 10)
        {
            updateCount++;
        }
        else if (updateCount == 10)
        {
            for (int i = 0; i < celestialObjects.Count; i++)
                if (celestialObjects[i].showTrail)
                    celestialObjects[i].trail.time = celestialObjects[i].trailTime;
            update = false;
            updateCount = 0;
        }
        int input = 0;
        input = Input.GetKeyDown(KeyCode.RightArrow) ? 1 : input;
        input = Input.GetKeyDown(KeyCode.LeftArrow) ? 2 : input;
        input = Input.GetKeyDown(KeyCode.UpArrow) ? 3 : input;
        input = Input.GetKeyDown(KeyCode.DownArrow) ? 4 : input;
        switch(input)
        {
            case 1:
                celestialObjects[cameraObserverIndex].trail.time = celestialObjects[cameraObserverIndex].trailTime;
                celestialObjects[cameraObserverIndex].showTrail = true;
                cameraObserverIndex++;
                if (cameraObserverIndex > maxCameraIndex)
                    cameraObserverIndex = 0;
                break;
            case 2:
                celestialObjects[cameraObserverIndex].trail.time = celestialObjects[cameraObserverIndex].trailTime;
                cameraObserverIndex--;
                if (cameraObserverIndex < 0)
                    cameraObserverIndex = maxCameraIndex;
                break;
            case 3:
                cameraTargetIndex++;
                if (cameraTargetIndex > maxCameraIndex)
                    cameraTargetIndex = 0;
                break;
            case 4:
                cameraTargetIndex--;
                if (cameraTargetIndex < 0)
                    cameraTargetIndex = maxCameraIndex;
                break;
        }
        if(input!=0)
        {
            observer = celestialObjects[cameraObserverIndex].gameObject;
            celestialObjects[cameraObserverIndex].trail.time = 0;
            celestialObjects[cameraObserverIndex].showTrail = false;
            obs.text = "Obs:" + observer.name;
            target = celestialObjects[cameraTargetIndex].gameObject;
            targ.text = "Targ:" + target.name;
            UpdateScale(observer.transform.position.magnitude, target.transform.position.magnitude);
        }
        mainCamera.transform.position = observer.transform.position + new Vector3(0, 0, (cameraObserverIndex == cameraTargetIndex) ? (celestialObjects[cameraObserverIndex].objectType == CelestialObject.CelestialObjectType.Sun ? 100 : 50) - observer.transform.position.z : 0);
        transform.LookAt(target.transform.position, Vector3.forward);
    }
    public void UpdateScale(float r1, float r2)
    {
        if (Mathf.Abs(r1 - r2) < 0.5 && Mathf.Abs(r1 - r2) > 0.0005 && Initialize.GetScale() != 1000)
        {
            UpdateCelestialObjects(1000, 3600 * 12);
            update = true;
        }
        if (Mathf.Abs(r1 - r2) > 500 && Initialize.GetScale() != oldScale)
        {
            UpdateCelestialObjects(oldScale, oldTimeMultiplier);
            update = true;
        }
        if (Mathf.Abs(r1 - r2) < 0.0005 && Mathf.Abs(r1 - r2) !=0 && Initialize.GetScale() != 10000)
        {
            UpdateCelestialObjects(10000, 3600);
            update = true;
        }

    }
    void UpdateCelestialObjects(int newScale, int newTimeMultiplier)
    {
        Initialize.SetTimeMultiplier(newTimeMultiplier);
        for (int i = 0; i < celestialObjects.Count; i++)
        {
            celestialObjects[i].trail.time = 0;
            celestialObjects[i].transform.position *= (float)newScale / Initialize.GetScale();
            celestialObjects[i].trailTime = celestialObjects[i].T * 3600f * 24f / newTimeMultiplier;
        }
        Initialize.SetScale(newScale);
    }
}
