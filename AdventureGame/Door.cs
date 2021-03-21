using System;
using System.Collections.Generic;
using System.Text;

namespace AdventureGame
{
    class Door
    {
        private char _roomA;
        private char _roomB;
        private string _color;
        private bool _doorOpen;

        public Door(char roomA, char roomB, string color, bool doorOpen = false)
        {
            _roomA = roomA;
            _roomB = roomB;
            _color = color;
            _doorOpen = doorOpen;
        }

        public char[] GetRoomBandA()
        {
            char[] DoorTo = new[] { _roomA, _roomB };
            return DoorTo;
        }

        public string GetDoorColor()
        {
            return _color;
        }

        public bool CheckIfDoorIsOpen()
        {
            return _doorOpen;
        }

        public void UnlockDoor()
        {
            _doorOpen = true;
        }
    }
}
