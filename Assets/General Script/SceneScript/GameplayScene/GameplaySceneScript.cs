using System;
using General_Script.SceneScript.GameplayScene.Tools;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zlipacket.CoreZlipacket.Audio;
using Zlipacket.CoreZlipacket.Tools;

namespace General_Script.SceneScript.GameplayScene
{
    public class GameplaySceneScript : Singleton<GameplaySceneScript>
    {
        public Button rotateRight;
        public Button rotateLeft;
        
        public ToolSelector toolSelector;

        public AudioClip gameplayBgm;
        
        private void Start()
        {
            if (gameplayBgm != null)
                MusicManager.Instance.PlayMusicWithCallback(gameplayBgm, nameof(gameplayBgm.name));
        }

        /*private void OnDestroy()
        {
            if (gameplayBgm != null)
                MusicManager.Instance.StopMusicByCallback(nameof(gameplayBgm));
        }*/
    }
}