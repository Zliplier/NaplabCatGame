using System;
using UnityEngine;
using UnityEngine.UI;

namespace General_Script.SceneScript.GameplayScene.Tools
{
    public class ToolButton : MonoBehaviour
    {
        private Button button;
        public ToolType toolType;
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
            if (toolSelector.currentState.stateKey != toolType)
                Select();
            else
                UnSelect();
        }

        private void Select()
        {
            toolSelector.ChangeToState(toolType);
            if (debug)
                Debug.Log($"Tool {toolType} selected.");
        }

        private void UnSelect()
        {
            toolSelector.ChangeToState(ToolType.None);
            if (debug)
                Debug.Log($"Tool {toolType} unselected.");
        }
    }
}