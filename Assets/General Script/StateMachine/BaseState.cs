using System;
using UnityEngine;

namespace General_Script.StateMachine
{
    public abstract class BaseState<Key> : MonoBehaviour where Key : Enum
    {
        public Key stateKey;
        [HideInInspector] public StateMachine<Key> stateMachine;

        public virtual void Start()
        {
            stateMachine = GetComponent<StateMachine<Key>>();
        }

        public virtual void StateEnter()
        {
            
        }

        public virtual void StateUpdate()
        {
            
        }

        public virtual void StateFixedUpdate()
        {
            
        }

        public virtual void StateExit()
        {
            
        }
    }
}