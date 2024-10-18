using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEngine.Events;
using System;

public class ActionEvent : MonoBehaviour
{
    InputAction inputAction;
    PlayerInput input;
    Animation animFiole1;
    Animation animFiole2;
    Animation animFiole3;
    [SerializeField] Animator animator;
    [SerializeField] GameObject fiole1;
    [SerializeField] GameObject fiole2;
    [SerializeField] GameObject fiole3;

    public Action<PotionType> OnChangePotion;
    public Action<IngredientType> OnChangeIngredient;
    public Action<HeatLevel> OnChangeHeat;

    public Action OnValidateRecipe;

    [SerializeField] public RecipeManager recipeManager;
    [SerializeField] public SOCurrentRecipe currentRecipe;


    private void Awake()
    {
        animator = GetComponent<Animator>();
        animFiole1 = fiole1.GetComponent<Animation>();
        animFiole2 = fiole2.GetComponent<Animation>();
        animFiole3 = fiole3.GetComponent<Animation>();
    }

    public void ChangePotion (int type)
    {
        Debug.Log("Type de potion : " + ((PotionType)type).ToString() + " / value : " + type);
        OnChangePotion?.Invoke((PotionType) type);
    }

    public void ChangeIngredient(int type)
    {
        Debug.Log("Type de potion : " + ((IngredientType)type).ToString() + " / value : " + type);
        OnChangeIngredient?.Invoke((IngredientType)type);
    }

    public void ChangeHeat(int type)
    {
        Debug.Log("Type de potion : " + ((HeatLevel)type).ToString() + " / value : " + type);
        OnChangeHeat?.Invoke((HeatLevel)type);
    }

    public void OnValidateButton(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            Debug.Log("Validate");
            OnValidateRecipe?.Invoke();
        }
    }
}
