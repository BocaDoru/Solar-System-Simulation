using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Initialize : MonoBehaviour
{
    public static float UA = 1.495978707e11f;
    static int scale=10;
    static bool showMoons=true;
    static bool showOrbit=true;
    static int timeMultiplier=10*3600*24;
    public AnimationCurve volumeCurveInput;
    static AnimationCurve volumeCurve;
    static List<CelestialObject> celestialObjects;
    static int maxCameraIndex;
    public void Start()
    {
        volumeCurve = volumeCurveInput;
        SetCelestialObjects();
    }
    public static void SetScale(int scaleInput) { scale = scaleInput; }
    public static int GetScale(){return scale; }
    public static void SetShowMoonsValue(bool showMoonsInput) { showMoons=showMoonsInput; }
    public static bool GetShowMoonsValue() { return showMoons; }
    public static void SetShowOrbitValue(bool showOrbitInput) { showOrbit = showOrbitInput; }
    public static bool GetShowOrbitValue() { return showOrbit; }
    public static void SetTimeMultiplier(int timeMultiplierInput) { timeMultiplier = timeMultiplierInput; }
    public static int GetTimeMultiplier() { return timeMultiplier; }
    static void SetMaxCameraIndex(int max) { maxCameraIndex = max; }
    public static int GetMaxCameraIndex() { return maxCameraIndex; }
    public static List<CelestialObject> GetCelestialObjects() { return celestialObjects; }
    public static void SetCelestialObjects()
    {
        celestialObjects = new List<CelestialObject>();
        celestialObjects.AddRange(FindObjectsOfType<CelestialObject>());
        celestialObjects.Sort(CompareByDistanceFromSun);
        if (!showMoons)
            for (int i = 0; i < celestialObjects.Count; i++)
            {
                if (celestialObjects[i].objectType == CelestialObject.CelestialObjectType.Moon)
                {
                    celestialObjects[i].gameObject.SetActive(false);
                    celestialObjects.RemoveAt(i);
                    i--;
                }
            }
        SetMaxCameraIndex(celestialObjects.Count - 1);
        ScaleCelestialObjects();
    }
    static int CompareByDistanceFromSun(CelestialObject a, CelestialObject b)
    {
        return a.numberOfOrder.CompareTo(b.numberOfOrder);
    }
    static void ScaleCelestialObjects()
    {
        float maxVolum = float.MinValue;
        for (int i = 0; i < celestialObjects.Count; i++)
        {
            if (celestialObjects[i].volum > maxVolum)
                maxVolum = celestialObjects[i].volum;
        }
        for (int i = 0; i < celestialObjects.Count; i++)
        {
            celestialObjects[i].scale = volumeCurve.Evaluate(celestialObjects[i].volum <= 1e16f ? 0 : Mathf.Log10(celestialObjects[i].volum / 1e16f) / Mathf.Log10(maxVolum / 1e16f));
            celestialObjects[i].gameObject.transform.localScale = celestialObjects[i].scale *3* Vector3.one;
        }
    }
}
