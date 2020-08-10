using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : StateMachineBehaviour
{
    public int count;
    public GameObject zombie;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (animator.GetBool("Zombie")) //if character is going to become a zombie, count is set to turn character into a zombie after 200 updates
        {
            count = animator.GetComponent<Health>().zombieChance + 200;
        }
        else //count is set to below 0 otherwise and they stay dead
        {
            count = -1;
        }
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if(animator.GetComponent<Health>().zombieChance == count)
           Zombieify(animator); //character becomes a zombie after 200 updates if they are supposed to
        count--;
    }

    public void Zombieify(Animator animator)
    { 
        //Character turns into a zombie
        //a zombie (of the same look as the character) spawns where the character is and the character is destroyed
        Instantiate(zombie, animator.GetComponent<Transform>().position, animator.GetComponent<Transform>().rotation);
        Destroy(animator.gameObject);
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

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
