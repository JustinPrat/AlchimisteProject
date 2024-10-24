using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEngine.Events;
using System;

public class ActionEvent : MonoBehaviour
{
    public Action<PotionType> OnSTARTChangePotion;
    public Action<IngredientType> OnSTARTChangeIngredient;
    public Action<HeatLevel> OnSTARTChangeHeat;

    public Action<PotionType> OnENDChangePotion;
    public Action<IngredientType> OnENDChangeIngredient;
    public Action<HeatLevel> OnENDChangeHeat;

    public Action OnValidateRecipe;

    [SerializeField] public RecipeManager recipeManager;
    [SerializeField] public SOCurrentRecipe currentRecipe;

    [SerializeField] public float heatCooldownTime;

    private bool canChangePotion = true;
    private bool canChangeIngredient = true;
    private bool canChangeHeat = true;

    private void Awake()
    {
        OnENDChangeIngredient += EndOfIngredientChange;
        OnENDChangePotion += EndOfPotionChange;
    }

    private void OnDestroy()
    {
        OnENDChangeIngredient -= EndOfIngredientChange;
        OnENDChangePotion -= EndOfPotionChange;
    }

    private void EndOfIngredientChange (IngredientType type)
    {
        canChangeIngredient = true;
    }

    private void EndOfPotionChange (PotionType type)
    {
        canChangePotion = true;
    }

    private void EndOfHeatChange()
    {
        canChangeHeat = true;
    }

    public void ChangePotion (int type)
    {
        Debug.Log("Type de potion : " + ((PotionType)type).ToString() + " / value : " + type);
        if (canChangePotion)
        {
            canChangePotion = false;
            OnSTARTChangePotion?.Invoke((PotionType)type);
            //StartCoroutine(CooldownBetweenPress(() => canChangePotion = true));
        }
    }

    public void ChangeIngredient(int type)
    {
        Debug.Log("Type de potion : " + ((IngredientType)type).ToString() + " / value : " + type);
        if (canChangeIngredient)
        {
            canChangeIngredient = false;
            OnSTARTChangeIngredient?.Invoke((IngredientType)type);
        }
    }

    public void ChangeHeat(int type)
    {
        Debug.Log("Type de potion : " + ((HeatLevel)type).ToString() + " / value : " + type);

        if (canChangeHeat)
        {
            canChangeHeat = false;
            OnSTARTChangeHeat?.Invoke((HeatLevel)type);
            StartCoroutine(CooldownBetweenPress(EndOfHeatChange));
        }
    }

    public void OnValidateButton(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            Debug.Log("Validate");
            OnValidateRecipe?.Invoke();
        }
    }

    public IEnumerator CooldownBetweenPress (Action toDoAfter)
    {
        yield return new WaitForSeconds(heatCooldownTime);
        toDoAfter?.Invoke();
    }
}
