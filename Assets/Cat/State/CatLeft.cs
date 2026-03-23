using Cat.Data;
using General_Script.StateMachine;
using UnityEngine;

namespace Cat.State
{
    public class CatLeft : CatState
    {
        public override void StateEnter()
        {
            base.StateEnter();
            Debug.Log("Enter Left State.");
            
            catAnimator.PlaySpriteAnimation(CatAnimator.CATDIRECTION_LEFT_ID);
        }
    }
}