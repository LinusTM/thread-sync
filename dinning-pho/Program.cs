using System;
using System.Threading;

namespace dinning_pho {
    class Program {
        static bool[] forks = new bool[5];
        static object _lock = new object();

        static void Main(string[] args) {
            Thread[] philosophers = new Thread[5];

            for(int i = 0; i < 5; i++) {
                int whichPhil = i;

                // Capturing index with lambda function, passing it to philEating
                philosophers[i] = new Thread(()=> philEating(whichPhil));
            }
            
            for(int i = 0; i < 5; i++) {
                philosophers[i].Start();
            }
        }

        static void philEating(int whichPhil) {
            Random random = new Random();

            while(true) {
                lock(_lock) {
                    fork1 = (whichPhil+1) % forks.Length;
                    fork2 = whichPhil;
                    
                    // Wait until forks is available
                    while(forks[fork1] || forks[fork2]) {
                        Monitor.Wait(forks);
                    }
                    
                    // Proclaim he is eating
                    Console.WriteLine($"Phil {whichPhil} is eating");
                    
                    // Pick up forks 
                    forks[fork1] = true;
                    forks[fork2] = true;
                    
                    // Eat
                    Thread.Sleep(random.Next(1000, 2000));
                    
                    // Put down forks
                    forks[fork1] = false;
                    forks[fork2] = false;
                }
            }
        }
    }
}
