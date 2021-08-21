using System;

namespace GC002
{
    class Program
    {
        static void Main(string[] args)
        {
            Test();
            Test2();

            Test3();
            Test4();


            Console.ReadLine();
        }

        private static void Test()
        {
            using (Person p = new Person { Name = "Tom" })
            {
                // переменная p доступна только в блоке using
                Console.WriteLine($"Некоторые действия с объектом Person. Получим его имя: {p.Name}");
            }
            Console.WriteLine("Конец метода Test");
            Console.WriteLine();
        }

        private static void Test2()
        {
            using (Person tom = new Person { Name = "Tom" })
            {
                using (Person bob = new Person { Name = "Bob" })
                {
                    Console.WriteLine($"Person1: {tom.Name}    Person2: {bob.Name}");
                }// вызов метода Dispose для объекта bob
            } // вызов метода Dispose для объекта tom
            Console.WriteLine("Конец метода Test4");
            Console.WriteLine();
        }

        private static void Test3()
        {
            using (Person tom = new Person { Name = "Tom" })
            using (Person bob = new Person { Name = "Bob" })
            {
                Console.WriteLine($"Person1: {tom.Name}    Person2: {bob.Name}");
            } // вызов метода Dispose для объектов bob и tom
            Console.WriteLine("Конец метода Test3");
            Console.WriteLine();
        }

        private static void Test4()
        {
            using Person tom = new Person { Name = "Tom" };
            using Person bob = new Person { Name = "Bob" };

            Console.WriteLine($"Person1: {tom.Name}    Person2: {bob.Name}");

            Console.WriteLine("Конец метода Test4");
            Console.WriteLine();
        } // вызов метода Dispose для объектов bob и tom

    }
    public class Person : IDisposable
    {
        public string Name { get; set; }

        
        public void Dispose()
        {
            Console.WriteLine("Disposed");

            Console.WriteLine(Name);
        }
    }


}