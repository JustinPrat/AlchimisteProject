using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEngine.Events;

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

    [SerializeField] public UnityEvent _onUse1;
    [SerializeField] public UnityEvent _onUse2;
    [SerializeField] public UnityEvent _onUse3;
    [SerializeField] public UnityEvent _onValidate;

    [SerializeField] public RecipeManager recipeManager;
    [SerializeField] public SOCurrentRecipe currentRecipe;
    [HideInInspector] public PotionType playerPotion;
    [HideInInspector] public IngredientType ingredientType;
    [HideInInspector] public HeatLevel heatLevel;
    


    private void Awake()
    {
        animator = GetComponent<Animator>();
        animFiole1 = fiole1.GetComponent<Animation>();
        animFiole2 = fiole2.GetComponent<Animation>();
        animFiole3 = fiole3.GetComponent<Animation>();
    }
    private void Start()
    {
        ingredientType = IngredientType.A;
        heatLevel = HeatLevel.Chaud;
    }
    public void OnUse1(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            Debug.Log("Use1");
            playerPotion = PotionType.Rouge;
            //animator.SetBool("isPressed1", true);
            //animator.Play("Fiole1");
        }
    } 
    public void OnUse2(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            Debug.Log("Use2");
            playerPotion = PotionType.Bleu;
            //animator.SetBool("isPressed2", true);
            //animator.Play("Fiole2");
        }
    }
    public void OnUse3(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            Debug.Log("Use3");
            playerPotion = PotionType.Vert;
            //animator.SetBool("isPressed3", true);
        }
    }
    public void OnValidate(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            Debug.Log("Validate");

            //heatLevel == valeur script de Dan
            //bool isRecipeCorrect = recipeManager.ComparePlayerResult(playerPotion, ingredientType, heatLevel);
            recipeManager.CompareLowCostResult(playerPotion);
/*            if (isRecipeCorrect)
            {
                Debug.Log("Recette validée !");
            }
            else
            {
                Debug.Log("La recette est incorrecte.");
            }*/
        }
    }
}
