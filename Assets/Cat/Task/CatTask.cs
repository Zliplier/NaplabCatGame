using UnityEngine;
using UnityEngine.Events;

namespace Cat.Task
{
    public abstract class CatTask : MonoBehaviour
    {
        public bool isTaskCompleted => CheckTaskCompleted();
        public UnityEvent onTaskCompleted;
        public abstract void Initialize();
        
        public abstract void Show();
        public abstract void Hide();

        public virtual void OnTaskCompleted()
        {
            onTaskCompleted?.Invoke();
        }
        
        public abstract bool CheckTaskCompleted();
    }
}