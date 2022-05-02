using System;
using System.Threading;

namespace A2_3 {
    class Program {
        static int sum = 0;
        static object _lock = new object();
        
        static void Main(string[] args) {
            Thread printPound = new Thread(PrintPound);
            Thread printAs = new Thread(PrintAs);
            
            printPound.Start();
            printAs.Start();
        }

        public static void PrintPound() {
            while(true) {
                lock (_lock) {
                    for(int i = 0; i < 60; i++) {
                        Console.Write("#");
                    }
                    Console.Write($" {Add()} \n");
                }
            }
        }
        
        public static void PrintAs() {
            while(true) {
                lock (_lock) {
                    for(int i = 0; i < 60; i++) {
                        Console.Write("*");
                    }
                    Console.Write($" {Add()}\n");
                }
            }
        }
        
        public static int Add() {
            return sum+=60; 
        }
    }
}
