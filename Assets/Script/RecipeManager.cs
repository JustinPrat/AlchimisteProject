using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecipeManager : MonoBehaviour
{
    
    public SOCurrentRecipe currentRecipe;
    public SORecipe targetRecipe;
    [SerializeField] List<SORecipe> recipes = new List<SORecipe>();
    private int currentRecipeIndex = 0;

    ActionEvent actionEvent;

    private Rect currentRecipeWindowRect = new Rect(10, 10, 250, 150);
    private Rect targetRecipeWindowRect = new Rect(270, 10, 250, 150);


    private void Start()
    {
        if (recipes.Count > 0)
        {
            targetRecipe = recipes[0];
        }
    }
    public bool ComparePlayerResult(PotionType playerPotion, IngredientType playerIngredient, HeatLevel playerHeat)
    {
        if (playerPotion == actionEvent.playerPotion && playerIngredient == actionEvent.ingredientType && playerHeat == actionEvent.heatLevel)
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
    public void CompareLowCostResult(PotionType playerPotion)
    {
        if (playerPotion == actionEvent.playerPotion)
        {
            Debug.Log("Recette correcte !");
            SetNextRecipe();
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
            Debug.Log("Bien joué chacal t'a fini le jeu");
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
            //GUILayout.Label("Potion Type: " + actionEvent.playerPotion);
            //GUILayout.Label("Ingredient Type: " + actionEvent.ingredientType);
            //GUILayout.Label("Heat Level: " + actionEvent.heatLevel);
        }
        else
        {
            GUILayout.Label("Aucune recette actuelle.");
        }

        GUI.DragWindow();
    }

    private void DisplayTargetRecipeWindow(int windowID)
    {
        if (targetRecipe != null)
        {
            GUILayout.Label("Potion Type: " + targetRecipe.potionType);
            GUILayout.Label("Ingredient Type: " + targetRecipe.ingredientType);
            GUILayout.Label("Heat Level: " + targetRecipe.heatLevel);
        }
        else
        {
            GUILayout.Label("Aucune recette cible.");
        }

        GUI.DragWindow();
    }
}
