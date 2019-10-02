using System;
using System.Linq;

namespace Hackathon
{
    class Program {
        static void Main(string[] args) {
            System.Console.WriteLine("Tell me your name");
            string name = System.Console.ReadLine();
            System.Console.WriteLine($"WASSAP MAH {name}. Let's go");
            Board game = new Board();
            game.Display();
            System.Console.WriteLine("Take your action");
            string action;
            while (!game.GameOver()) {
                action = System.Console.ReadKey(true).Key.ToString();
                while (!ValidateKey(action.ToUpper())) {
                    System.Console.WriteLine("Wrong Action");
                    action = System.Console.ReadKey(true).Key.ToString();
                }
                game.ReceiveInput(action.ToUpper());
                System.Console.WriteLine($"{name} What's your next move!!!!");            System.Console.WriteLine("");
                System.Console.WriteLine("");System.Console.WriteLine("");
                System.Console.WriteLine("");
            }
            System.Console.WriteLine($"{name}!! STAPHHH");

        }
        static private bool ValidateKey (string key) {
            string[] keys = {"A", "S", "W", "D"};
            if (keys.Contains(key)) {
                return true;
            }
            return false;
    }}
}
