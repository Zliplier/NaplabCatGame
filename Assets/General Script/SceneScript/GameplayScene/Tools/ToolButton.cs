using System;
using Cat.Task;
using UnityEngine;
using UnityEngine.UI;

namespace General_Script.SceneScript.GameplayScene.Tools
{
    public class ToolButton : MonoBehaviour
    {
        private Button button;
        public ToolType toolType;
        public Image toolIcon;
        public bool debug = false;

        private ToolSelector toolSelector => GameplaySceneScript.Instance.toolSelector;

        private void Awake()
        {
            button = GetComponent<Button>();
        }

        private void Start()
        {
            button.onClick.AddListener(Click);
        }

        private void Click()
        {
            if (CatTaskManager.Instance.isAllTasksCompleted) return;
            
            if (toolSelector.currentState.stateKey != toolType)
                Select();
            else
                UnSelect();
        }

        private void Select()
        {
            toolSelector.ChangeToState(toolType);
            toolIcon.gameObject.SetActive(false);
            if (debug)
                Debug.Log($"Tool {toolType} selected.");
        }

        private void UnSelect()
        {
            toolSelector.ChangeToState(ToolType.None);
            toolIcon.gameObject.SetActive(true);
            if (debug)
                Debug.Log($"Tool {toolType} unselected.");
        }
    }
}