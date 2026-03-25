using System;
using System.Linq;
using Cat.Data;
using Cat.Task;
using General_Script.SceneScript;
using General_Script.SceneScript.GameplayScene;
using Player;
using UnityEngine;

namespace Cat
{
    public class Cat : MonoBehaviour
    {
        public SO_CatConfig config;
        public CatStateMachine stateMachine;

        private void Start()
        {
            GameplaySceneScript.Instance.rotateRight.onClick.AddListener(RotateRight);
            GameplaySceneScript.Instance.rotateLeft.onClick.AddListener(RotateLeft);
        }

        private void OnDisable()
        {
            GameplaySceneScript.Instance.rotateRight.onClick.RemoveListener(RotateRight);
            GameplaySceneScript.Instance.rotateLeft.onClick.RemoveListener(RotateLeft);
        }

        public void RotateRight() => Rotate(true);
        public void RotateLeft() => Rotate(false);

        public void Rotate(bool isRight)
        {
            if (CatTaskManager.Instance.isAllTasksCompleted) return;
            
            int nextState = (int)stateMachine.states.SingleOrDefault(state => state.Value == stateMachine.currentState).Key +
                            (isRight ? 1 : -1);

            int enumLength =  Enum.GetValues(typeof(CatDirection)).Length;
            if (nextState < 0)
                nextState = enumLength - 1;
            else if (nextState > enumLength - 1)
                nextState = 0;
            
            stateMachine.ChangeToState((CatDirection)nextState);
        }
    }
}
