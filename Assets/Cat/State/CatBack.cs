using Cat.Data;
using General_Script.StateMachine;
using UnityEngine;

namespace Cat.State
{
    public class CatBack : CatState
    {
        public override void StateEnter()
        {
            base.StateEnter();
            Debug.Log("Enter Back State.");
            
            catAnimator.PlaySpriteStateAnimation(CatAnimator.CATDIRECTION_BACK_ID);
        }
    }
}