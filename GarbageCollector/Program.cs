using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarbageCollector
{
    class Program
    {
        static void Main(string[] args)
        {
            Test();

            GC.Collect();
            Console.ReadLine();
        }

        private static void Test()
        {
            Country country = new Country();
            country.x = 10;
            country.y = 15;
        }

        private static void Test2()
        {
            Person p = null;
            try
            {
                p = new Person();
            }
            finally
            {
                if (p != null)
                {
                    p.Dispose();
                }
            }
        }
    }
    public class Person : IDisposable
    {
        public string Name { get; set; }
        public void Dispose()
        {
            Console.Beep();
            Console.WriteLine("Disposed");
        }
    }

    public class SomeClass : IDisposable
    {
        private bool disposed = false;

        // реализация интерфейса IDisposable.
        public void Dispose()
        {
            Dispose(true);
            // подавляем финализацию
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    // Освобождаем управляемые ресурсы
                }
                // освобождаем неуправляемые объекты
                disposed = true;
            }
        }

        // Деструктор
        ~SomeClass()
        {
            Dispose(false);
        }
    }

    public class Derived 
    {
        private bool IsDisposed = false;

        protected  void Dispose(bool disposing)
        {
            if (IsDisposed) return;
            if (disposing)
            {
                // Освобождение управляемых ресурсов
            }
            IsDisposed = true;
            // Обращение к методу Dispose базового класса
            Dispose(disposing);
        }
    }




    class Country
    {
        public int x;
        public int y;
    }
}