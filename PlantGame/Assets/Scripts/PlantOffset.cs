using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 잎마다 애니메이션 속도를 랜덤하게 설정
public class PlantOffset : StateMachineBehaviour
{
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.speed = Random.Range(0.2f, 1.8f);
    }
}
