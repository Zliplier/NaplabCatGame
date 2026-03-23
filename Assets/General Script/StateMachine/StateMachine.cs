using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zlipacket.CoreZlipacket.Tools;

namespace General_Script.StateMachine
{
    public abstract class StateMachine<Key> : MonoBehaviour where Key : Enum
    {
        [HideInInspector] public BaseState<Key> currentState;
        public SerializableDictionary<Key, BaseState<Key>> states;

        private void Start()
        {
            ChangeToState(Enum.GetValues(typeof(Key)).Cast<Key>().ToArray()[0]);
        }

        public virtual void Update()
        {
            currentState?.StateUpdate();
        }

        public virtual void FixedUpdate()
        {
            currentState?.StateFixedUpdate();
        }

        public virtual void ChangeToState(Key key)
        {
            currentState?.StateExit();
            currentState = states[key];
            currentState.StateEnter();
        }
    }
}