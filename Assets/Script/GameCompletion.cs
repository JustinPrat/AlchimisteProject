using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class IngredientsTool : EditorWindow
{
    private string FolderPath = "Assets/ScriptableObjects/";

    private Vector2 _windowSize;

    [MenuItem("Pasteur/ExperienceTool")]
    private static void Init()
    {
        IngredientsTool window = GetWindowWithRect<IngredientsTool>(new Rect(0, 0, 1000, 600), false);
        window.Show();
    }

        private void OnGUI()
    {
        LoadPaths();
        OnGUIUpdate();
    }
}
