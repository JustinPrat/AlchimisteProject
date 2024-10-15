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

    private void Awake()
    {
        animator = GetComponent<Animator>();
        animFiole1 = fiole1.GetComponent<Animation>();
        animFiole2 = fiole2.GetComponent<Animation>();
        animFiole3 = fiole3.GetComponent<Animation>();
    }
    private void Start()
    {

    }
    public void OnUse1(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            Debug.Log("Use1");
            animator.SetBool("isPressed1", true);
            //animator.Play("Fiole1");
        }
        if (context.canceled)
        {
            animator.SetBool("isPressed1", false);
        }
    }
    public void OnUse2(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            Debug.Log("Use2");
            animator.SetBool("isPressed2", true);
            //animator.Play("Fiole2");
        }
        if (context.canceled)
        {
            animator.SetBool("isPressed2", false);
        }
    }
    public void OnUse3(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            Debug.Log("Use3");
            animator.SetBool("isPressed3", true);
        }
        if (context.canceled)
        {
            animator.SetBool("isPressed3", false);
        }
    }
}
