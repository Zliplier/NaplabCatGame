using System;
using UnityEngine;
using UnityEngine.Events;
using Zlipacket.CoreZlipacket.Player.Input;
using Zlipacket.CoreZlipacket.Tools;

namespace Player
{
    public class PlayerCursor : Singleton<PlayerCursor>
    {
        private PlayerController playerController => PlayerController.Instance;
        public SpriteRenderer spriteRenderer;
        
        private bool isMouseDown = false;
        
        public UnityEvent onMouseUp;
        public UnityEvent onMouseDown;
        public UnityEvent onMouseUpdate;
        public UnityEvent onMouseFixedUpdate;
        
        private void Start()
        {
            playerController.inputReader.playerInputMap.leftMouseDownEvent += MouseDown;
            playerController.inputReader.playerInputMap.leftMouseUpEvent += MouseUp;
        }

        private void OnDisable()
        {
            playerController.inputReader.playerInputMap.leftMouseDownEvent -= MouseDown;
            playerController.inputReader.playerInputMap.leftMouseUpEvent -= MouseUp;
        }

        public void SetCursorSprite(Sprite sprite)
        {
            if (spriteRenderer == null) return;
            
            spriteRenderer.sprite = sprite;
        }

        private void MouseDown()
        {
            isMouseDown = true;
            spriteRenderer.gameObject.SetActive(true);
            //Debug.Log("MouseDown");
            onMouseDown?.Invoke();
        }

        private void MouseUp()
        {
            isMouseDown = false;
            spriteRenderer.gameObject.SetActive(false);
            onMouseUp?.Invoke();
            //Debug.Log("MouseUp");
        }

        private void Update()
        {
            if (!isMouseDown)
                return;
            
            //Update Position
            Vector3 mousePosition = new Vector3(playerController.inputReader.uiInputMap.mousePosition.x, playerController.inputReader.uiInputMap.mousePosition.y, 10f);
            transform.position = Camera.main.ScreenToWorldPoint(mousePosition);
            
            onMouseUpdate?.Invoke();
        }

        private void FixedUpdate()
        {
            if (!isMouseDown)
                return;
            
            onMouseFixedUpdate?.Invoke();
        }
    }
}