using UnityEngine;
using UnityEngine.Events;

namespace Cat.Task
{
    public abstract class TaskObject : MonoBehaviour
    {
        public bool isActive = false;
        public bool isCompleted = false;

        [Header("Events")]
        public UnityEvent onTaskCompleted;
        
        public virtual void Initialize()
        {
            isActive = true;
        }
        
        public abstract void DoTask();

        public virtual void TaskCompleted()
        {
            isCompleted = true;
            onTaskCompleted?.Invoke();
        }
    }
}