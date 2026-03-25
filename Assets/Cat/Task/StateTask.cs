using System;
using Cat.Task.Brush;
using UnityEngine;
using UnityEngine.Events;

namespace Cat.Task
{
    [Serializable]
    public class StateTask
    {
        public BrushTask brushTask;
        public UnityEvent onTaskCompleted;
        
        public void Initialize()
        {
            brushTask?.Initialize();
            brushTask?.onTaskCompleted.AddListener(OnTaskCompleted);
        }
        
        public void Show()
        {
            brushTask.Show();
        }

        public void Hide()
        {
            brushTask.Hide();
        }

        public void OnTaskCompleted()
        {
            onTaskCompleted?.Invoke();
        }

        public bool CheckStateTaskCompleted()
        {
            if (brushTask.isTaskCompleted)
                return true;
            return false;
        }

        public Vector2Int GetTaskProgress()
        {
            return brushTask.GetTaskProgress();
        }
    }
}