using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modul15.Prak
{
    public class MyClass
    {
        public int PublicProperty { get; set; }
        private string PrivateProperty { get; set; }
        public MyClass() { }
        public MyClass(int value)
        {
            PublicProperty = value;
        }
        private MyClass(string message)
        {
            PrivateProperty = message;
        }
        public void PublicMethod()
        {
            Console.WriteLine("Public Method Called");
        }
        private void PrivateMethod()
        {
            Console.WriteLine("Private Method Called: " + PrivateProperty);
        }
    }

}
