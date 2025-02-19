
/*static void Main(string[] args)
{
    int p,x,k;
    Console.WriteLine("Введите p");
    p=int.Parse(Console.ReadLine());
    Console.WriteLine("Введите x");
    x = int.Parse(Console.ReadLine());
    Console.WriteLine("Введите k");
    k = int.Parse(Console.ReadLine());

    // Создаем массив для хранения простых делителей.
    int[] primeDivisors = new int[10]; // Задаем начальный размер массива на 10 элементов.
    int primeDivisorsCount = 0; // Счетчик количества простых делителей.

    // Перебираем все числа от 2 до квадратного корня числа.
    for (int i = 2; i <= Math.Sqrt(p); i++)
    {
        // Если число делится на i без остатка и i является простым, добавляем i в массив простых делителей.
        if (p % i == 0 && IsPrime(i))
        {
            // Увеличиваем счетчик количества простых делителей.
            primeDivisorsCount++;

            // Если массив заполнен, увеличиваем его размер в два раза.
            if (primeDivisorsCount == primeDivisors.Length)
            {
                Array.Resize(ref primeDivisors, primeDivisors.Length * 2);
            }

            // Добавляем i в массив простых делителей.
            primeDivisors[primeDivisorsCount - 1] = i;

            // Делим число на i, пока оно делится на i без остатка.
            while (p % i == 0)
            {
                p /= i;
            }
        }
    }

    // Если число больше 1, значит, оно является простым числом, и мы добавляем его в массив простых делителей.
    if (p > 1)
    {
        // Увеличиваем счетчик количества простых делителей.
        primeDivisorsCount++;

        // Если массив заполнен, увеличиваем его размер в два раза.
        if (primeDivisorsCount == primeDivisors.Length)
        {
            Array.Resize(ref primeDivisors, primeDivisors.Length * 2);
        }

        // Добавляем число в массив простых делителей.
        primeDivisors[primeDivisorsCount - 1] = p;
    }

    // Уменьшаем размер массива до фактического количества простых делителей.
    Array.Resize(ref primeDivisors, primeDivisorsCount);

    // Выводим массив простых делителей.
    Console.WriteLine("Простые делители числа {0}:", p);
    foreach (int primeDivisor in primeDivisors)
    {
        Console.WriteLine(primeDivisor);
    }
}

static bool IsPrime(int number)
{
    if (number <= 1)
    {
        return false;
    }

    for (int i = 2; i <= Math.Sqrt(number); i++)
    {
        if (number % i == 0)
        {
            return false;
        }
    }

    return true;
}
*/

using System;

namespace PrimeDivisors
{
    class Program
    {
        static void Main(string[] args)
        {
            int p, x, k;
            Console.WriteLine("Введите p");
            p = int.Parse(Console.ReadLine());
            Console.WriteLine("Введите x");
            x = int.Parse(Console.ReadLine());
            Console.WriteLine("Введите k");
            k = int.Parse(Console.ReadLine());
            // Запрашиваем у пользователя число.

            // Создаем массив для хранения простых делителей.
            int[] primeDivisors = new int[10]; // Задаем начальный размер массива на 10 элементов.
            int primeDivisorsCount = 0; // Счетчик количества простых делителей.

            // Перебираем все числа от 2 до квадратного корня числа.
            for (int i = 2; i <= Math.Sqrt(p); i++)
            {
                // Если число делится на i без остатка и i является простым, добавляем i в массив простых делителей.
                if (p % i == 0 && IsPrime(i))
                {
                    // Увеличиваем счетчик количества простых делителей.
                    primeDivisorsCount++;

                    // Если массив заполнен, увеличиваем его размер в два раза.
                    if (primeDivisorsCount == primeDivisors.Length)
                    {
                        Array.Resize(ref primeDivisors, primeDivisors.Length * 2);
                    }

                    // Добавляем i в массив простых делителей.
                    primeDivisors[primeDivisorsCount - 1] = i;

                    // Делим число на i, пока оно делится на i без остатка.
                    while (p % i == 0)
                    {
                        p /= i;
                    }
                }
            }

            // Если число больше 1, значит, оно является простым числом, и мы добавляем его в массив простых делителей.
            if (p > 1)
            {
                // Увеличиваем счетчик количества простых делителей.
                primeDivisorsCount++;

                // Если массив заполнен, увеличиваем его размер в два раза.
                if (primeDivisorsCount == primeDivisors.Length)
                {
                    Array.Resize(ref primeDivisors, primeDivisors.Length * 2);
                }

                // Добавляем число в массив простых делителей.
                primeDivisors[primeDivisorsCount - 1] = p;
            }

            // Уменьшаем размер массива до фактического количества простых делителей.
            Array.Resize(ref primeDivisors, primeDivisorsCount);

            // Выводим массив простых делителей.
            Console.WriteLine("Простые делители числа {0}:", p);
            foreach (int primeDivisor in primeDivisors)
            {
                Console.WriteLine(primeDivisor);
            }
        }

        /// <summary>
        /// Проверяет, является ли число простым.
        /// </summary>
        /// <param name="number">Число для проверки.</param>
        /// <returns>True, если число простое, иначе false.</returns>
        static bool IsPrime(int number)
        {
            if (number <= 1)
            {
                return false;
            }

            for (int i = 2; i <= Math.Sqrt(number); i++)
            {
                if (number % i == 0)
                {
                    return false;
                }
            }

            return true;
        }
    }
}