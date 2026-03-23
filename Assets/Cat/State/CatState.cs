using Cat.Data;
using General_Script.StateMachine;
using UnityEngine;

namespace Cat.State
{
    public abstract class CatState : BaseState<CatDirection>
    {
        protected CatAnimator catAnimator => ((CatStateMachine)stateMachine).catAnimator;

        public override void StateEnter()
        {
            base.StateEnter();
            //Debug.Log("Enter CatState");
        }
    }
}