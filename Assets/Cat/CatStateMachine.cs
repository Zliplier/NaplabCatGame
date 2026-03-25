using System;
using System.Collections.Generic;
using System.Linq;
using Cat.Data;
using Cat.State;
using Cat.Task;
using General_Script.StateMachine;
using UnityEngine;

namespace Cat
{
    public class CatStateMachine : StateMachine<CatDirection>
    {
        public CatAnimator catAnimator;
        public CatTaskManager catTaskManager;

        public List<CatState> GetAllStates() => states.Values.Cast<CatState>().ToList();

        public override void Awake()
        {
            base.Awake();
        }

        public override void Start()
        {
            base.Start();
            
        }
    }
}