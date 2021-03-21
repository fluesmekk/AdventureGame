using System;
using System.Collections.Generic;
using System.Text;

namespace AdventureGame
{
    class Room
    {
        private char _name;
        private string _content;
        private bool _startingRoom;
        private bool _winRoom;

        public Room(char name, string content = "", bool startingRoom = false, bool winRoom = false)
        {
            _name = name;
            _content = content;
            _startingRoom = startingRoom;
            _winRoom = winRoom;
        }

        public string GetContentInCurrentRoom()
        {
            return _content;
        }

        public char getRoomChar()
        {
            return _name;
        }

        public void RemoveContent()
        {
            _content = "";
        }

        public bool checkIfWon()
        {
            return _winRoom;
        }
    }
}
