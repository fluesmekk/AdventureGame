using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace AdventureGame
{
    class Game
    {
        private List<Door> _doors = new List<Door>();
        private List<Room> _rooms = new List<Room>();
        private Player _player;
        private string _currentOptions;

        public void AddDoors(Door[] doors)
        {
            foreach (var door in doors)
            {
                _doors.Add(door);
            }
        }

        public void AddRooms(Room[] rooms)
        {
            foreach (var room in rooms)
            {
                _rooms.Add(room);
            }
        }

        public void AddPlayer(Player player)
        {
            this._player = player;
        }

        public bool HasPlayerWon()
        {
            return _player.GameWon;
        }

        public void ListOptions()
        {
            
            GetCurrentRoomOptions();
            GetEnclosedDoors();
        }

        private void GetEnclosedDoors()
        {
            var currentRoom = _player.GetCurrentRoom();
            foreach (var door in _doors)
            {
                var RoomDoors = door.GetRoomBandA();
                if (RoomDoors[0] == currentRoom)
                {
                    if (door.CheckIfDoorIsOpen())
                    {
                        printDoorOptions(door, RoomDoors);
                    }
                    checkIfUserHasKey(door);
                }

                if (RoomDoors[1] == currentRoom)
                {
                    if (door.CheckIfDoorIsOpen())
                    {
                        printDoorOptions(door, RoomDoors);
                    }
                    checkIfUserHasKey(door);
                }
            }
        }

        private void checkIfUserHasKey(Door door)
        {
            var doorColor = door.GetDoorColor();
            var content = _player.GetContent();
            if (content != null)
            {
                foreach (var key in content)
                {
                    var color = key.Split(" ");
                    if (color[0] == doorColor)
                    {
                        Console.WriteLine($"You can unlock the {door.GetDoorColor()} door");
                    }
                }
            }
            
        }

        private void printDoorOptions(Door door, char[] RoomDoors)
        {
            Console.WriteLine($"You see a {door.GetDoorColor()} door");
            if (door.CheckIfDoorIsOpen())
            {
                Console.WriteLine("The door is open");
            }
            else
            {
                Console.WriteLine("The door is locked");
            }
        }

        private void GetCurrentRoomOptions()
        {
            char currentRoom = _player.GetCurrentRoom();
            CurrentRoom(currentRoom);
            
        }

        private void CurrentRoom(char currentRoom)
        {
            
            foreach (var room in _rooms)
            {
                if (room.getRoomChar() == currentRoom)
                {
                    printRoomOptions(room);
                }
            }
        }

        private void printRoomOptions(Room room)
        {
            Console.WriteLine($"You're in room {room.getRoomChar()}");
            if (room.GetContentInCurrentRoom() != "")
            {
                Console.WriteLine($"You can pick up the {room.GetContentInCurrentRoom()}");
            }

            
        }

        public void HandleCommand(string response)
        {
            if (response == "pick up") PickUp();
            if (response.Contains("unlock")) Unlock(response);
            if (response.Contains("go")) GoThroughDoor(response);
        }

        private void GoThroughDoor(string response)
        {
            var split = response.Split(" ");
            var doorColor = split[1];
            Console.WriteLine(doorColor);
            MoveThroughDoor(doorColor);
        }

        private void MoveThroughDoor(string doorColor)
        {
            foreach (var door in _doors)
            {
                if (door.GetDoorColor() == doorColor)
                {
                    checkDoorAAndB(door);
                }
            }
        }

        private void checkDoorAAndB(Door door)
        {
            var currentRoom = _player.GetCurrentRoom();
            var doorList = door.GetRoomBandA();
            if (doorList[0] == currentRoom) _player.MovePlayer(doorList[1]);
            else _player.MovePlayer(doorList[0]);
            checkIfRoomIsWinningRoom(_player.GetCurrentRoom());
            Console.WriteLine($"Moved to room {_player.GetCurrentRoom()}");
        }

        private void checkIfRoomIsWinningRoom(char getCurrentRoom)
        {
            foreach (var room in _rooms)
            {
                if (room.getRoomChar() == getCurrentRoom)
                {
                    if (room.checkIfWon()) _player.GameWon = true;
                }
            }
        }

        private void Unlock(string response)
        {
            var split = response.Split(" ");
            var doorColor = split[1];
            UnlockDoor(doorColor);
            _player.UseAndRemoveKey($"{doorColor} key");
        }

        private void UnlockDoor(string doorColor)
        {
            foreach (var door in _doors)
            {
                if (doorColor == door.GetDoorColor()) door.UnlockDoor();
            }
        }

        private void PickUp()
        {
            Room room = getRoomObject();
            var content = room.GetContentInCurrentRoom();
            room.RemoveContent();
            _player.AddContent(content);
        }

        private Room getRoomObject()
        {
            char currentRoom = _player.GetCurrentRoom();
            foreach (var room in _rooms)
            {
                if (currentRoom == room.getRoomChar())
                {
                    return room;
                }
            }
            Room noRoom = new Room('X', "");
            return noRoom;
        }

        public void ShowHelpText()
        {
            Console.WriteLine("You have 3 different commands");
            Console.WriteLine("<pick up> picks up the key that the room has");
            Console.WriteLine("<unlock [color] door> unlocks the door with that color");
            Console.WriteLine("<go [color]> goes throug door with [color]\n");
        }
    }
}
