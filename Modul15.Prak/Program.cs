using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace Modul15.Prak
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Type myClassType = typeof(MyClass);

            //Задание1 Исследование типа
            Console.WriteLine("Class Name: " + myClassType.Name);

            Console.WriteLine("\nConstructors:");
            foreach (var constructor in myClassType.GetConstructors(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic))
            {
                Console.WriteLine(constructor);
            }

            Console.WriteLine("\nProperties:");
            foreach (var prop in myClassType.GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic))
            {
                Console.WriteLine($"{prop.PropertyType} {prop.Name}");
            }

            Console.WriteLine("\nMethods:");
            foreach (var method in myClassType.GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic))
            {
                Console.WriteLine($"{method.ReturnType} {method.Name}");
            }

            //Задание2 Создание экземпляра
            var myClassInstance = (MyClass)Activator.CreateInstance(myClassType);

            //Задание3 Манипулирование объектом
            PropertyInfo publicProperty = myClassType.GetProperty("PublicProperty");
            publicProperty.SetValue(myClassInstance, 10);

            MethodInfo publicMethod = myClassType.GetMethod("PublicMethod");
            publicMethod.Invoke(myClassInstance, null);

            //Задание4 Расширенное исследование
            ConstructorInfo privateConstructor = myClassType.GetConstructor(BindingFlags.Instance | BindingFlags.NonPublic, null, new[] { typeof(string) }, null);
            var myClassPrivateInstance = (MyClass)privateConstructor.Invoke(new object[] { "Hello" });

            MethodInfo privateMethod = myClassType.GetMethod("PrivateMethod", BindingFlags.Instance | BindingFlags.NonPublic);
            privateMethod.Invoke(myClassPrivateInstance, null);
            Console.ReadKey();
        }
    }
}
