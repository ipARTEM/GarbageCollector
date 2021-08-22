using System;

namespace GC003
{
    class Program
    {
        static void Main(string[] args)
        {
            unsafe
            {
                int* x; // определение указателя
                int y = 10; // определяем переменную

                x = &y; // указатель x теперь указывает на адрес переменной y
                Console.WriteLine(*x); // 10

                y = y + 20;
                Console.WriteLine(*x);// 30

                *x = 50;
                Console.WriteLine(y); // переменная y=50

                Console.WriteLine("****************");

                int* x2; // определение указателя
                int y2 = 10; // определяем переменную

                x2 = &y2; // указатель x теперь указывает на адрес переменной y

                // получим адрес переменной y
                ulong addr = (ulong)x2;
                Console.WriteLine("Адрес переменной y: {0}", addr);

                Console.WriteLine("****************");

                int* x3; // определение указателя
                int y3 = 10; // определяем переменную

                x3 = &y3; // указатель x теперь указывает на адрес переменной y
                int** z3 = &x3; // указатель z теперь указывает на адрес, который указывает и указатель x
                **z3 = **z3 + 40; // изменение указателя z повлечет изменение переменной y
                Console.WriteLine(y3); // переменная y=50
                Console.WriteLine(**z3); // переменная **z=50

                Console.WriteLine("****************");

                Person person;
                person.age = 29;
                person.height = 176;
                Person* p = &person;
                p->age = 30;
                Console.WriteLine(p->age);

                // разыменовывание указателя
                (*p).height = 180;
                Console.WriteLine((*p).height);

                Console.WriteLine("****************");

                const int size = 7;
                int* factorial = stackalloc int[size]; // выделяем память в стеке под семь объектов int
                int* p5 = factorial;

                *(p5++) = 1; // присваиваем первой ячейке значение 1 и
                            // увеличиваем указатель на 1
                for (int i = 2; i <= size; i++, p5++)
                {
                    // считаем факториал числа
                    *p5 = p5[-1] * i;
                }
                for (int i = 1; i <= size; ++i)
                {
                    Console.WriteLine(factorial[i - 1]);
                }

                Console.WriteLine("****************");

                Person8 person8 = new Person8();
                person8.age = 28;
                person8.height = 178;
                // блок фиксации указателя
                //fixed (int* p8 = &person8.age)
                //{
                //    if (*p8 < 30)
                //    {
                //        *p8 = 30;
                //    }
                //}
                Console.WriteLine(person8.age); // 30

                Console.WriteLine("****************");

                int[] nums = { 0, 1, 2, 3, 7, 88 };
                string str = "Привет мир";
                fixed (int* p9 = nums)
                {
                    int third = *(p9 + 2);     // получим третий элемент
                    Console.WriteLine(third); // 2
                }
                fixed (char* p9 = str)
                {
                    char forth = *(p9 + 3);     // получим четвертый элемент
                    Console.Write(forth); // в
                    char forth2 = *(p9 + 4);     
                    Console.Write(forth2); 
                    char forth3 = *(p9 + 5);     
                    Console.Write(forth3); 
                }

            }

            

            Console.ReadLine();

        }

        public struct Person
        {
            public int age;
            public int height;
        }

        public struct Person8
        {
            public int age;
            public int height;
        }
    }
}
