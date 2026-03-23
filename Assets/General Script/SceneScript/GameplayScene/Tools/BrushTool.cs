using Player;
using UnityEngine;

namespace General_Script.SceneScript.GameplayScene.Tools
{
    public class BrushTool : TaskTool
    {
        public Sprite brushCursor;
        private PlayerCursor cursor => PlayerCursor.Instance;
        
        public override void StateEnter()
        {
            base.StateEnter();
            cursor.onMouseUpdate.AddListener(Using);
            cursor.spriteRenderer.sprite = brushCursor;
        }

        public override void StateExit()
        {
            base.StateExit();
            cursor.onMouseUpdate.RemoveListener(Using);
            cursor.spriteRenderer.sprite = null;
        }

        private void Using()
        {
            
        }
    }
}