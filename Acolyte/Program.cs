using BileFountain;
using System;

namespace Acolyte {
    class Program {
        static void Main(string[] args) {
            Profanerizer generator = new Profanerizer();
            while (true) {
                string result = generator.Profane();
                Console.WriteLine(result);
                ConsoleKeyInfo key = Console.ReadKey();
                if (key.KeyChar == (char)27)
                    break;
            }
        }
    }
}
