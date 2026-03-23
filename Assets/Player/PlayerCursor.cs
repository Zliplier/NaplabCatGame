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

        private void MouseDown()
        {
            isMouseDown = true;
            spriteRenderer.enabled = true;
            //Debug.Log("MouseDown");
            onMouseDown?.Invoke();
        }

        private void MouseUp()
        {
            isMouseDown = false;
            spriteRenderer.enabled = false;
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
    }
}