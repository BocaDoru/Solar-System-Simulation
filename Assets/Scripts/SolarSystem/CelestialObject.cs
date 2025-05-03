using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CelestialObject : MonoBehaviour
{
    public int numberOfOrder;
    public enum CelestialObjectType { Sun, Planet, Moon };
    public CelestialObjectType objectType;
    public float mass;
    public float volum;
    public float scale=1f;
    public Vector3 positionInSystem;
    public Vector3 v0;
    public float T;
    public Vector3 a;
    public Vector3 v;
    public Vector3 currentPosition;
    public CelestialObject Sun;
    public TrailRenderer trail;
    public float trailTime;
    public bool showTrail = true;
    private void Start()
    {
        trail.gameObject.SetActive(false);
        positionInSystem *= 1000 / Initialize.UA * Initialize.GetScale();
        transform.position = positionInSystem;
        v0 *= 1000;
        v = v0;
        trailTime = T * 3600 * 24/ Initialize.GetTimeMultiplier();
        trail.time = Initialize.GetShowOrbitValue() ? trailTime : 0;
        showTrail = Initialize.GetShowOrbitValue();
        switch (objectType)
        {
            case CelestialObjectType.Sun:
                trail.startWidth = 0.1f;
                break;
            case CelestialObjectType.Planet:
                trail.startWidth = 0.1f;
                break;
            case CelestialObjectType.Moon:
                trail.startWidth = 0.01f;
                break;
        }
        trail.material = gameObject.GetComponent<Renderer>().material;
        trail.gameObject.SetActive(true);
    }
    private void FixedUpdate()
    {
        v += a * Time.fixedDeltaTime * Initialize.GetTimeMultiplier();
        transform.position += Time.fixedDeltaTime * Initialize.GetTimeMultiplier() * v * Initialize.GetScale() / Initialize.UA;
        currentPosition = transform.position / Initialize.GetScale() * Initialize.UA;
    }
}