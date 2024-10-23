using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class RecipeManager : MonoBehaviour
{
    public SORecipe targetRecipe;
    public Recipe currentRecipe = new Recipe();

    [SerializeField] private List<SORecipe> recipes = new List<SORecipe>();
    [SerializeField] private ActionEvent actionEvent;

    [SerializeField] private VisualEffect visualEffectBubble;
    [SerializeField] private VisualEffect visualEffectDrop;

    private Rect currentRecipeWindowRect = new Rect(10, 10, 250, 150);
    private Rect targetRecipeWindowRect = new Rect(270, 10, 250, 150);

    private int currentRecipeIndex = 0;

    [SerializeField, GradientUsage(true)] private List<Gradient> gradientsBubble;
    [SerializeField, GradientUsage(true)] private List<Gradient> gradientsDrop;

    private float fireValuePercent;
    [SerializeField] private float firePace;
    [SerializeField] private float fireIncrease;
    [SerializeField] private float fireThresholdHot;

    private void Update()
    {
        fireValuePercent -= Time.deltaTime * firePace;
        fireValuePercent = Mathf.Clamp(fireValuePercent, 0, 100);

        HeatLevel heat = fireValuePercent >= fireThresholdHot ? HeatLevel.Chaud : HeatLevel.Froid;
        actionEvent.OnENDChangeHeat?.Invoke(heat);
    }

    private void Start()
    {
        targetRecipe.Recipe = new Recipe();

        if (recipes.Count > 0)
        {
            targetRecipe = recipes[0];
        }

        actionEvent.OnENDChangePotion += SetElement;
        actionEvent.OnENDChangeIngredient += SetElement;
        actionEvent.OnENDChangeHeat += SetElement;
        actionEvent.OnValidateRecipe += TryValidate;
        actionEvent.OnSTARTChangeHeat += IncreaseValue;

        visualEffectBubble.SetGradient("MainColorGradient", gradientsBubble[(int)currentRecipe.potionType]);
        visualEffectDrop.SetGradient("MainGradient", gradientsDrop[(int)currentRecipe.potionType]);
    }

    private void OnDestroy()
    {
        actionEvent.OnENDChangePotion -= SetElement;
        actionEvent.OnENDChangeIngredient -= SetElement;
        actionEvent.OnENDChangeHeat -= SetElement;
        actionEvent.OnValidateRecipe -= TryValidate;
    }

    private void IncreaseValue (HeatLevel heatLevel)
    {
        fireValuePercent += fireIncrease;
        fireValuePercent = Mathf.Clamp(fireValuePercent, 0, 100);
    }

    public void SetElement (PotionType type)
    {
        currentRecipe.potionType = type;
        visualEffectBubble.SetGradient("MainColorGradient", gradientsBubble[(int)type]);
        visualEffectDrop.SetGradient("MainGradient", gradientsDrop[(int)currentRecipe.potionType]);
    }

    public void SetElement(IngredientType type)
    {
        currentRecipe.ingredientType = type;
    }

    public void SetElement(HeatLevel type)
    {
        currentRecipe.heatLevel = type;
    }

    private void TryValidate ()
    {
        ComparePlayerResult(targetRecipe.Recipe.potionType, targetRecipe.Recipe.ingredientType, targetRecipe.Recipe.heatLevel);
    }

    public bool ComparePlayerResult(PotionType playerPotion, IngredientType playerIngredient, HeatLevel playerHeat)
    {
        if (playerPotion == currentRecipe.potionType && playerIngredient == currentRecipe.ingredientType && playerHeat == currentRecipe.heatLevel)
        {
            Debug.Log("Recette correcte !");
            SetNextRecipe();
            return true;
        }
        else
        {
            Debug.Log("Recette incorrecte.");
            return false;
        }
    }

    private void SetNextRecipe()
    {
        currentRecipeIndex++;
        if (currentRecipeIndex < recipes.Count)
        {
            targetRecipe = recipes[currentRecipeIndex];
        }
        else
        {
            Debug.Log("Bien jou� chacal t'a fini le jeu");
        }
    }


    private void OnGUI()
    {
        currentRecipeWindowRect = GUI.Window(0, currentRecipeWindowRect, DisplayCurrentRecipeWindow, "Current Recipe");
        targetRecipeWindowRect = GUI.Window(1, targetRecipeWindowRect, DisplayTargetRecipeWindow, "Target Recipe");
    }

    private void DisplayCurrentRecipeWindow(int windowID)
    {
        if (currentRecipe != null)
        {
            GUILayout.Label("Potion: " + currentRecipe.potionType);
            GUILayout.Label("Ingredient: " + currentRecipe.ingredientType);
            GUILayout.Label("Heat: " + currentRecipe.heatLevel);
        }
        else
        {
            GUILayout.Label("null");
        }

        GUI.DragWindow();
    }

    private void DisplayTargetRecipeWindow(int windowID)
    {
        if (targetRecipe != null)
        {
            GUILayout.Label("Potion: " + targetRecipe.Recipe.potionType);
            GUILayout.Label("Ingredient: " + targetRecipe.Recipe.ingredientType);
            GUILayout.Label("Heat: " + targetRecipe.Recipe.heatLevel);
        }
        else
        {
            GUILayout.Label("null");
        }

        GUI.DragWindow();
    }
}

[Serializable]
public class Recipe
{
    public PotionType potionType;
    public IngredientType ingredientType;
    public HeatLevel heatLevel;
}