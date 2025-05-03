using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour
{
    List<CelestialObject> celestialObjects;
    const float G = 6.67428e-11f;
    public void Start()
    {
        celestialObjects = Initialize.GetCelestialObjects();
    }
    public void FixedUpdate()
    {
        for(int i=0;i<celestialObjects.Count;i++)
        {
            Vector3 Fg = new Vector3(0, 0, 0);
            for (int j=0;j<celestialObjects.Count;j++)
            {
                if (i!=j)
                {
                    Vector3 R = (celestialObjects[j].transform.position-celestialObjects[i].transform.position) / Initialize.GetScale() * Initialize.UA;
                    float r = R.sqrMagnitude;
                    Fg += G * celestialObjects[i].mass * celestialObjects[j].mass / r * R.normalized;
                }
            }
            celestialObjects[i].a = Fg / celestialObjects[i].mass;
        }
    }
}