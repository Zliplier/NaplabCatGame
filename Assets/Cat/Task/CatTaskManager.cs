using System;
using System.Linq;
using Cat.Data;
using Cat.State;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using Zlipacket.CoreZlipacket.Scene;
using Zlipacket.CoreZlipacket.Tools;

namespace Cat.Task
{
    public class CatTaskManager : Singleton<CatTaskManager>
    {
        public CatStateMachine stateMachine;
        public CatAnimator animator;
        public UnityEvent onAllTasksCompleted;
        public TextMeshProUGUI taskProgressText;
        
        public bool isAllTasksCompleted = false;
        
        public override void Awake()
        {
            base.Awake();
            
            foreach (CatState state in stateMachine.states.Values.Cast<CatState>())
            {
                state.stateTasks.Initialize();
                state.stateTasks.onTaskCompleted.AddListener(OnTaskCompleted);
            }
        }

        public void Start()
        {
            UpdateTaskProgressText();
        }

        private void OnTaskCompleted()
        {
            UpdateTaskProgressText();
            
            if (CheckAllTaskCompleted())
            {
                onAllTasksCompleted?.Invoke();
                Debug.Log("All tasks completed");
                isAllTasksCompleted = true;
            }
        }

        private bool CheckAllTaskCompleted()
        {
            foreach (CatState state in stateMachine.states.Values.Cast<CatState>())
            {
                if (!state.stateTasks.CheckStateTaskCompleted())
                    return false;
            }
            
            return true;
        }

        private Vector2Int GetTaskProgress()
        {
            Vector2Int progress = Vector2Int.zero;

            foreach (CatState state in stateMachine.states.Values.Cast<CatState>())
            {
                Vector2Int stateProgress = state.stateTasks.GetTaskProgress();
                
                progress += stateProgress;
            }
            return progress;
        }

        public void UpdateTaskProgressText()
        {
            Vector2Int taskProgress = GetTaskProgress();
            
            if (taskProgressText != null)
                taskProgressText.text = $"Task: \n{taskProgress.x.ToString()}/{taskProgress.y.ToString()}";
        }

        public void Endgame()
        {
            stateMachine.ChangeToState(CatDirection.Front);
            animator.PlaySpriteAnimationOnce(CatAnimator.CATDIRECTION_FRONT_ID, "FrontPawLick", 1f);
            
            Invoke(nameof(ShowEndScene), 1f);
        }

        public void ShowEndScene()
        {
            SceneController.Instance.LoadSceneAsync("EndgameScene");
        }
    }
}