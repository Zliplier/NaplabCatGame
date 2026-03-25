using Cat.Data;
using General_Script.StateMachine;
using UnityEngine;

namespace Cat.State
{
    public class CatFront : CatState
    {
        public override void StateEnter()
        {
            base.StateEnter();
            Debug.Log("Enter Front State.");
            
            catAnimator.PlaySpriteStateAnimation(CatAnimator.CATDIRECTION_FRONT_ID);
        }
    }
}