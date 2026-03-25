using Cat.Data;
using Cat.Task;
using General_Script.StateMachine;
using UnityEngine;

namespace Cat.State
{
    public abstract class CatState : BaseState<CatDirection>
    {
        protected CatAnimator catAnimator => ((CatStateMachine)stateMachine).catAnimator;
        public StateTask stateTasks;

        public override void StateEnter()
        {
            base.StateEnter();
            //Debug.Log("Enter CatState");

            stateTasks.Show();
        }

        public override void StateExit()
        {
            base.StateExit();
            stateTasks.Hide();
        }
    }
}