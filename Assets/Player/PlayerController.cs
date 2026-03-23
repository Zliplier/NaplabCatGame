using System;
using UnityEngine;
using Zlipacket.CoreZlipacket.Player.Input;
using Zlipacket.CoreZlipacket.Tools;

namespace Player
{
    public class PlayerController : Singleton<PlayerController>
    {
        public SO_InputReader inputReader;
    }
}