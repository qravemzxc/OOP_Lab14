using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Reflection;
using System.Threading;
using System.IO;

namespace Lab14
{ 
    public static class Methods
    {
        public static void SimpleNumb()
        {
            string path = "C:\\Пацей\\Lab14\\Lab14\\record.txt";
            using (StreamWriter writer = new StreamWriter(path, true))
            {
                int k = 0;
                Console.Write("Введите n:");
                int userNumb = Convert.ToInt32(Console.ReadLine());
                Console.Write("Простые числа:");
                for (int i = 2; i < userNumb + 1; i++)
                {
                    for (int j = 2; j < i; j++)
                    {
                        if (i % j == 0)
                        {
                            k++;
                        }
                    }
                    if (k == 0)
                    {
                        writer.WriteLine(i);
                        Console.Write($"{i},");
                    }
                    else
                    {
                        k = 0;
                    }
                    Thread.Sleep(100);
                }
            }
            Console.WriteLine();
        }
        public static void EvenNumbers()
        {
            string path = "C:\\Пацей\\Lab14\\Lab14\\record.txt";
            using (StreamWriter writer = new StreamWriter(path, true))
            {
                for (int i = 0; i <= 20; i++)
                {
                    if (i % 2 == 0)
                    {
                        writer.Write(i);
                        Console.Write($"{i} ");
                        Thread.Sleep(100);
                    }
                }
            }
        }



        public static void OddNumbers()
        {
            string path = "C:\\Пацей\\Lab14\\Lab14\\record.txt";
            using (StreamWriter writer = new StreamWriter(path, true))
            {
                for (int i = 0; i <= 20; i++)
                {
                    if (i % 2 != 0)
                    {
                        writer.Write(i);
                        Console.Write($"{i} ");
                        Thread.Sleep(200);
                    }
                }
            }
        }

        public static void TimeMethod(object obj)
        {
            Console.WriteLine("Hello World!");
        }
    }
    
   class Program
    {
        static void Main(string[] args)
        {
            // Задание 1. Процессы и информация о них
         
            foreach(var proc in process)
            {
                try
                {
                    Console.WriteLine($"Id процесса - {proc.Id}\n" +
                                      $"Имя процесса - {proc.ProcessName}\n" +
                                      $"Приоритет процесса - {proc.BasePriority}\n" +
                                      $"Время запуска процесса - {proc.StartTime}\n" +
                                      $"Текущее состояние процесса - {proc.Responding}\n" +
                                      $"Время работы процесса - {proc.TotalProcessorTime}\n" +
                                      $"Время загрузки процесса - {proc.UserProcessorTime}\n");
                }
                catch(Exception e)
                {

                }
      
            }


            // Задание 2. Исследование текущего домена
            AppDomain domain = AppDomain.CurrentDomain; 
            Console.WriteLine($"Имя домена - {domain.FriendlyName}");
            Console.WriteLine("Базовый каталог:\n" + domain.BaseDirectory);
            Console.WriteLine($"Детали конфигурации - {domain.SetupInformation}");
            Console.WriteLine("Сборки, загруженные в домен:");
            Assembly[] assemblies = domain.GetAssemblies();
            foreach (Assembly asm in assemblies)
            {
                Console.WriteLine(asm.GetName().Name);
            }
            Console.WriteLine();
            AppDomain newDomain = AppDomain.CreateDomain("New_Domain"); 
            newDomain.Load(Assembly.GetExecutingAssembly().FullName);  
            AppDomain.Unload(newDomain);


            // Задание 3. Вывод простых чисел от 1 до n
            Thread simpleThread = new Thread(Methods.SimpleNumb);
            simpleThread.Start();
            Console.WriteLine("\n\n\nИнформация о потоке:");
            Console.WriteLine("Выполняется ли поток: " + simpleThread.IsAlive);
            Console.WriteLine("Приоритет потока: " + simpleThread.Priority);
            Console.WriteLine("Идентификатор: " + simpleThread.ManagedThreadId);
            simpleThread.Join();


            // Задание 4. Два потока четных и нечетных чисел
            Console.WriteLine("\n\n\nПотоки чётных и нечётных чисел:");
            Thread evenThread = new Thread(Methods.EvenNumbers);
            evenThread.Priority = ThreadPriority.BelowNormal;
            evenThread.Start();
            evenThread.Join();

            Console.WriteLine();
            Thread oddThread = new Thread(Methods.OddNumbers);
            oddThread.Priority = ThreadPriority.AboveNormal;
            oddThread.Start();
            oddThread.Join();


            // Задание 5. Класс Timer
            TimerCallback tm = new TimerCallback(Methods.TimeMethod);     
            Timer timer = new Timer(tm, null, 0, 1000);              
            Thread.Sleep(4000);

        }
    }
}
