using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class Manos : MonoBehaviour
{
    public InputActionProperty pinchAnimationAction;
    //public InputActionProperty gripAnimationAction;
    public Animator handAnimator;
    void Start()
    {
        
    }

    
    void Update()
    {
        float triggerValue = pinchAnimationAction.action.ReadValue<float>();
        handAnimator.SetFloat("Blend", triggerValue);

        //float gripValue = gripAnimationAction.action.ReadValue<float>();
        //handAnimator.SetFloat("Grip", gripValue);
    }
}
