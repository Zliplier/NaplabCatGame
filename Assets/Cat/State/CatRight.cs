using Cat.Data;
using General_Script.StateMachine;
using UnityEngine;

namespace Cat.State
{
    public class CatRight : CatState
    {
        public override void StateEnter()
        {
            base.StateEnter();
            Debug.Log("Enter Right State.");
            
            catAnimator.PlaySpriteStateAnimation(CatAnimator.CATDIRECTION_RIGHT_ID);
        }
    }
}