using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainFace
{
    ShapeGenerator shapeGenerator;
    Mesh mesh;
    int rezolution;
    Vector3 localUp;
    Vector3 axisA;
    Vector3 axisB;

    public TerrainFace(ShapeGenerator shapeGenerator,Mesh mesh, int rezolution, Vector3 localUp)
    {
        this.shapeGenerator = shapeGenerator;
        this.mesh = mesh;
        this.rezolution = rezolution;
        this.localUp = localUp;
        axisA = new Vector3(localUp.y, localUp.z, localUp.x);
        axisB = Vector3.Cross(localUp, axisA);
    }
    public void ConstructMesh()
    {
        Vector3[] vertices = new Vector3[rezolution * rezolution];
        int[] triangles = new int[(rezolution - 1) * (rezolution - 1) * 6];
        int triIndex = 0;
        Vector2[] uv = (mesh.uv.Length==vertices.Length)?mesh.uv:new Vector2[vertices.Length];
        for (int y = 0; y < rezolution; y++)
        {
            for (int x = 0; x < rezolution; x++)
            {
                int i = x + y * rezolution;
                Vector2 percent = new Vector2(x, y) / (rezolution - 1);
                Vector3 pointOnUnitCube = localUp + (percent.x - .5f)*2 * axisA + (percent.y - .5f)*2 * axisB;
                Vector3 pointOnUnitSphere = pointOnUnitCube.normalized;
                float unscaledElevation = shapeGenerator.CalculateUnscaledElevation(pointOnUnitSphere);
                vertices[i] = pointOnUnitSphere * shapeGenerator.GetScaledElevation(unscaledElevation);
                uv[i].y = unscaledElevation;
                if (x != rezolution - 1 && y != rezolution - 1)
                {
                    triangles[triIndex] = i;
                    triangles[triIndex + 1] = i + rezolution + 1;
                    triangles[triIndex + 2] = i + rezolution;

                    triangles[triIndex + 3] = i;
                    triangles[triIndex + 4] = i + 1;
                    triangles[triIndex + 5] = i + rezolution + 1;
                    triIndex += 6;
                }
            }
        }
        mesh.Clear();
        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.RecalculateNormals();
        mesh.uv = uv;
    }
    public void UpdateUVs(ColourGenerator colourGenerator)
    {
        Vector2[] uv = mesh.uv;
        for (int y = 0; y < rezolution; y++)
        {
            for (int x = 0; x < rezolution; x++)
            {
                int i = x + y * rezolution;
                Vector2 percent = new Vector2(x, y) / (rezolution - 1);
                Vector3 pointOnUnitCube = localUp + (percent.x - .5f) * 2 * axisA + (percent.y - .5f) * 2 * axisB;
                Vector3 pointOnUnitSphere = pointOnUnitCube.normalized;
                uv[i].x = colourGenerator.BiomePercentFromPoint(pointOnUnitSphere);
            }
        }
        mesh.uv = uv;
    }
}
