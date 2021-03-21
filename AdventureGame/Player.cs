using System;
using System.Collections.Generic;
using System.Text;

namespace AdventureGame
{
    class Player
    {
        public bool GameWon = false;
        private List<string> _content = new List<string>();
        private char _currentRoom = 'A';

        public char GetCurrentRoom()
        {
            return _currentRoom;
        }

        public void MovePlayer(char CurrentRoom)
        {
            _currentRoom = CurrentRoom;
        }

        public List<string> GetContent()
        {
            return _content;
        }

        public void AddContent(string key)
        {
            Console.WriteLine(key);
            _content.Add(key);
        }

        public void UseAndRemoveKey(string key)
        {
            _content.Remove(key);
            Console.WriteLine("Used key");
        }
    }
}
