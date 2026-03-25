using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Zlipacket.CoreZlipacket.Audio;
using Zlipacket.CoreZlipacket.Scene;
using NotImplementedException = System.NotImplementedException;

namespace Zlipacket.CoreZlipacket.UI
{
    public class ZlipButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler
    {
        [Header("Button")]
        public Image buttonImage;
        public Sprite mouseDownSprite;
        public Sprite mouseUpSprite;
        [Header("Cursor")]
        public Texture2D curserSprite;
        public Texture2D hoverSprite;
        [Header("Audio")]
        public AudioClip clickSound;

        [Header("Animation")]
        public bool animationEnabled = false;
        public Tween tw_Animation = null;
        public bool isTweening => tw_Animation != null;
        private Vector3 initScale;
        public Vector3 scale;
        public float duration = 0.2f;

        private void Awake()
        {
            initScale = transform.localScale;
        }

        public void PlayClickSound()
        {
            if (clickSound != null)
            {
                SoundFXManager.Instance.PlaySoundFX(clickSound, transform);
            }
        }
        
        public void ChangeToScene(string sceneName)
        {
            SceneController.Instance.LoadScene(sceneName);
        }
        
        public void LoadSceneAsync(string sceneName)
        {
            SceneController.Instance.LoadSceneAsync(sceneName);
        }
        
        public void UnloadSceneAsync(string sceneName)
        {
            SceneController.Instance.UnloadSceneAsync(sceneName);
        }
        
        public void Quit()
        {
            Application.Quit();
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            if (animationEnabled)
            {
                if (isTweening)
                {
                    tw_Animation?.Kill();
                    tw_Animation = null;
                }
                
                tw_Animation = transform.DOScale(scale, 0.2f);
                tw_Animation.onComplete += () =>
                {
                    tw_Animation = null;
                };
            }
            
            if (hoverSprite == null) return;
            Vector2 cursorHotSpot = new Vector2(hoverSprite.width / 2, hoverSprite.height / 2);
            Cursor.SetCursor(hoverSprite, cursorHotSpot, CursorMode.Auto);
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            if (animationEnabled)
            {
                tw_Animation = transform.DOScale(initScale, 0.2f);
                tw_Animation.onComplete += () =>
                {
                    tw_Animation = null;
                };
            }
            
            if (curserSprite == null) return;
            Vector2 cursorHotSpot = new Vector2(curserSprite.width / 2, curserSprite.height / 2);
            Cursor.SetCursor(curserSprite, cursorHotSpot, CursorMode.Auto);
        }


        public void OnPointerDown(PointerEventData eventData)
        {
            if (mouseDownSprite != null || buttonImage != null)
                buttonImage.sprite = mouseDownSprite;

            
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            if (mouseUpSprite != null || buttonImage != null)
                buttonImage.sprite = mouseUpSprite;
            
            
        }
    }
}