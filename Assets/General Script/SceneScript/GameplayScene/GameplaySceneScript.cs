using General_Script.SceneScript.GameplayScene.Tools;
using UnityEngine.UI;
using Zlipacket.CoreZlipacket.Tools;

namespace General_Script.SceneScript.GameplayScene
{
    public class GameplaySceneScript : Singleton<GameplaySceneScript>
    {
        public Button rotateRight;
        public Button rotateLeft;
        
        public ToolSelector toolSelector;
        
        private void Start()
        {
            
        }
    }
}