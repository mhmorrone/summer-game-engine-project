using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.AccessControl;
using UnityEngine;

public class NPC_Hurt : StateMachineBehaviour
{
    int FightFlightFreeze;
    Actions action;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        FightFlightFreeze = UnityEngine.Random.Range(-1, 1);
        action = animator.GetComponent<Actions>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    //override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if(FightFlightFreeze == -1)
        {
            animator.SetTrigger("Attack");
            action.Fight();
        } else if(FightFlightFreeze == 0)
        {
            action.Flight();
        }
        else
        {
            action.Freeze();
        }
    }

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
