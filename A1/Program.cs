using System;
using System.Threading;

namespace A1 {
    class Program {
        static int sum = 0;
        static object _lock = new object();

        static void Main(string[] args) {
            Thread[] threads = new Thread[10];

            for(int i = 0; i < 10; i+=2) {
                threads[i] = new Thread(AddOne);
                threads[i+1] = new Thread(SubTwo);
            }

            for(int i = 0; i < 10; i++) {
                threads[i].Start();
            }

            for(int i = 0; i < 10; i++) {
                threads[i].Join();
            }

            Console.WriteLine(sum);
        }

        public static void AddOne() {
            lock(_lock) { 
                sum+=2; 
            }
        }

        public static void SubTwo() {
            lock(_lock) {
                sum--;
            }
        }
    }
}
