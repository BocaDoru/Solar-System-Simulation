using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UIElements;

[CustomEditor(typeof(Planet))]
public class PlanetEditor : Editor
{
    Planet planet;
    Editor shapeEditor;
    Editor colourEditor;
    public override void OnInspectorGUI()
    {
        using(var check=new EditorGUI.ChangeCheckScope())
        {
            base.OnInspectorGUI();
            if (check.changed)
                planet.GeneratePlanet();
        }
        if (GUILayout.Button("GeneratePlanet"))
            planet.GeneratePlanet();
        DrowSettingsEditor(planet.shapeSettings,planet.OnShapeSettingsUpdate,ref planet.shapeSettingsFoldout,ref shapeEditor);
        DrowSettingsEditor(planet.colourSettings,planet.OnColourSettingsUpdate,ref planet.colourSettingsFoldout,ref colourEditor);
    }
    void DrowSettingsEditor(Object settings, System.Action onSettingsUpdated,ref bool foldout,ref Editor editor)
    {
        if (settings != null)
        {
            foldout = EditorGUILayout.InspectorTitlebar(foldout, settings);
            using (var check = new EditorGUI.ChangeCheckScope())
            {
                if (foldout)
                {
                    CreateCachedEditor(settings, null, ref editor);
                    editor.OnInspectorGUI();
                    if (check.changed)
                    {
                        if (onSettingsUpdated != null)
                            onSettingsUpdated();
                    }
                }
            }
        }
    }
    private void OnEnable()
    {
        planet = (Planet)target;
    }
}
