using UnityEngine;
using Zlipacket.CoreZlipacket.Audio;
using Zlipacket.CoreZlipacket.Tools;

namespace General_Script.SceneScript.TitleScene
{
    public class TitleSceneScript : Singleton<TitleSceneScript>
    {
        public AudioClip titleBgm;
        
        private void Start()
        {
            if (titleBgm != null)
                MusicManager.Instance.PlayMusicWithCallback(titleBgm, nameof(titleBgm.name));
        }

        /*private void OnDestroy()
        {
            if (titleBgm != null)
                MusicManager.Instance.StopMusicByCallback(nameof(titleBgm));
        }*/
    }
}