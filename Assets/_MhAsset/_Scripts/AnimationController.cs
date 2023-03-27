using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using MyBox;
using StarterAssets;

public class AnimationController : StateMachineBehaviour
{
    public ThirdPersonController player;
    Animator animator;

    [Separator("Events at Enter Animation")]
    [HideInInspector]public bool EventEnter;
    [ConditionalField(nameof(EventEnter))] public boolParameter[] arrayParameterEnter;


    [Separator("Events at Exit Animation")]
    [HideInInspector]public bool EventExit;
    [ConditionalField(nameof(EventExit))] public boolParameter[] arrayParameterExit;

    private void OnEnable()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<ThirdPersonController>();
        animator = player._animator;

    }


    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.applyRootMotion = true;
        
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.applyRootMotion = false;
      
        for (int i=0; i< arrayParameterExit.Length; i++)
        {
            animator.SetBool(arrayParameterExit[i].name, arrayParameterExit[i].status);
        }
        
    }

    


}

[Serializable]
public struct boolParameter
{
    public string name;
    public bool status;
}