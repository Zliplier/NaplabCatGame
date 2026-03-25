using Cat.Task;
using Player;
using UnityEngine;

namespace General_Script.SceneScript.GameplayScene.Tools
{
    public class BrushTool : TaskTool
    {
        public Sprite brushCursor;
        private PlayerCursor cursor => PlayerCursor.Instance;

        public float radius = 0.2f;
        
        public override void StateEnter()
        {
            base.StateEnter();
            cursor.onMouseFixedUpdate.AddListener(Using);
            cursor.SetCursorSprite(brushCursor);
        }

        public override void StateExit()
        {
            base.StateExit();
            cursor.onMouseFixedUpdate.RemoveListener(Using);
            cursor.SetCursorSprite(null);
        }

        private void Using()
        {
            if (Physics.SphereCast(Camera.main.transform.position, radius, cursor.transform.position - Camera.main.transform.position, out RaycastHit hit, Mathf.Infinity,
                    LayerMask.GetMask("Task")))
            {
                if (hit.collider.gameObject.TryGetComponent(out TaskObject task))
                {
                    task.DoTask();
                }
            }
        }
    }
}