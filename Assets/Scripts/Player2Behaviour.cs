using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Behaviour : StateMachineBehaviour
{
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (GamePlay.instance.winner == null)
        {
            UIManager.instance.ToastMessage("Player2");
            GamePlay.instance.Player1.GetComponent<Player>().aimController.SetAllCollidersStatus(false);
            GamePlay.instance.Player2.GetComponent<Player>().aimController.enabled = true;
            GamePlay.instance.Player2.GetComponent<Player>().aimController.PrepearToThrowAI();
        }
        else {

            GamePlay.instance.Player1.GetComponent<Player>().aimController.SetAllCollidersStatus(false);
            GamePlay.instance.Player2.GetComponent<Player>().aimController.enabled = false;
        }
    }



    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    //override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        GamePlay.instance.Player1.GetComponent<Player>().aimController.SetAllCollidersStatus(true);
        GamePlay.instance.Player2.GetComponent<Player>().aimController.enabled = false;
    }

    

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //  {

    // }
}
