using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class ActionEvent : MonoBehaviour
{
    InputAction inputAction;
    PlayerInput input;
    Animation fiole1Anim;
    Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    public void OnUse1(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            //float value = context.ReadValue<float>(); 
            //Animation = value
            animator.SetTrigger("Fiole1");

        }
    }
    public void OnUse2(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            float value = context.ReadValue<float>();
            //Animation = value

        }
    }
    public void OnUse3(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            float value = context.ReadValue<float>();
            //Animation = value

        }
    }
}
