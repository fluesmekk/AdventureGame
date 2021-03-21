using System;

namespace AdventureGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();

            Room Room1 = new Room('A', "red key", true);
            Room Room2 = new Room('B', "green key");
            Room Room3 = new Room('C', "white key");
            Room Room4 = new Room('D', "blue key");
            Room Room5 = new Room('E', "grey key");
            Room Room6 = new Room('F', "", false, true);
            Room[] rooms = new Room[] { Room1, Room2, Room3, Room4, Room5, Room6};

            Door Door1 = new Door('B', 'A', "red");
            Door Door2 = new Door('D', 'A', "green");
            Door Door3 = new Door('C', 'B', "grey");
            Door Door4 = new Door('E', 'B', "blue");
            Door Door5 = new Door('F', 'E', "white");
            Door[] doors = new Door[] { Door1, Door2, Door3, Door4, Door5 };

            Player player = new Player();
            game.AddRooms(rooms);
            game.AddDoors(doors);
            game.AddPlayer(player);

            game.ShowHelpText();
            while (!game.HasPlayerWon())
            {
                game.ListOptions();
                var response = Console.ReadLine();
                game.HandleCommand(response);
                Console.Clear();
                
            }

            Console.WriteLine("You won!!!11!");
        }
    }
}
