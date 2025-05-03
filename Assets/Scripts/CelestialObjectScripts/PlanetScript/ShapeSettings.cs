using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class ShapeSettings : ScriptableObject
{
    public float planetRadius;
    public NoiseLayer[] noiseLayers;
    [System.Serializable]
    public class NoiseLayer
    {
        public bool enable = true;
        public bool useFirstLayerAsMask = true;
        public NoiseSettings noiseSettings;
    }
}
