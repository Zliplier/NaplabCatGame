using UnityEngine;
using UnityEngine.Events;
using UnityEngine.VFX;

namespace Cat.Task.Brush
{
    public class BrushObject : TaskObject
    {
        public SphereCollider brushCollider;
        public VisualEffect vfx;

        [Header("Config")]
        public Vector2 brushAngle;

        private float completionLevel;

        public override void Initialize()
        {
            base.Initialize();
            completionLevel = 0;
        }

        public override void DoTask()
        {
            if (isCompleted)
                return;
            
            //Debug.Log($"Do Task Complete Level: {completionLevel}");
            
            if (completionLevel < 1)
            {
                completionLevel += 1 / (60 * 0.5f);
                float scale = Mathf.Clamp(1f - completionLevel, 0.4f, 1f);
                vfx.transform.localScale = new Vector3(scale, scale, scale);
            }
            else
            {
                completionLevel = 1;
                TaskCompleted();
            }
        }

        public override void TaskCompleted()
        {
            base.TaskCompleted();
            gameObject.SetActive(false);
        }
    }
}