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

    public Action<PotionType> OnSTARTChangePotion;
    public Action<IngredientType> OnSTARTChangeIngredient;
    public Action<HeatLevel> OnSTARTChangeHeat;

    public Action<PotionType> OnENDChangePotion;
    public Action<IngredientType> OnENDChangeIngredient;
    public Action<HeatLevel> OnENDChangeHeat;

    public Action OnValidateRecipe;

    [SerializeField] public RecipeManager recipeManager;
    [SerializeField] public SOCurrentRecipe currentRecipe;
<<<<<<< Updated upstream
    Fire fire;
=======
    [SerializeField] public float cooldownTime;
>>>>>>> Stashed changes

    private bool canChangePotion = true;
    private bool canChangeIngredient = true;
    private bool canChangeHeat = true;

    private void Awake()
    {
        animator = GetComponent<Animator>();

        OnENDChangeIngredient += EndOfIngredientChange;
    }

    private void EndOfIngredientChange (IngredientType type)
    {
        canChangeIngredient = true;
    }

    private void EndOfPotionChange (PotionType type)
    {
        canChangePotion = true;
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
<<<<<<< Updated upstream
        OnChangeHeat?.Invoke((HeatLevel)type);
        fire.AddFire();
=======
        if (canChangeHeat)
        {
            canChangeHeat = false;
            OnSTARTChangeHeat?.Invoke((HeatLevel)type);
            OnENDChangeHeat?.Invoke((HeatLevel)type);
        }
>>>>>>> Stashed changes
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
        yield return new WaitForSeconds(cooldownTime);
        toDoAfter?.Invoke();
    }
}
