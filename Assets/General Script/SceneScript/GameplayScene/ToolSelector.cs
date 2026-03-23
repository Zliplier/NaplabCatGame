using System;
using General_Script.SceneScript.GameplayScene.Tools;
using General_Script.StateMachine;

namespace General_Script.SceneScript.GameplayScene
{
    public class ToolSelector : StateMachine<ToolType>
    {
        private void OnDisable()
        {
            ChangeToState(ToolType.None);
        }
    }

    [Serializable]
    public enum ToolType
    {
        None, 
        Brush
    }
}