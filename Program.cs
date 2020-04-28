using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ListString = System.Collections.Generic.List<string>;

namespace ConsoleApp1
{
    internal sealed class aTypeA1
    {
        private int x = 5;
    }

    internal sealed class TypeB1
    {
        static TypeB1()
        {
            // ...
        }
    }

    public sealed class TypeC1
    {
        public static TypeC1 operator +(TypeC1 a, TypeC1 b)
        {
            TypeC1 c = new TypeC1();
            c.x = a.x + b.x;
            return c;
        }

        public int x { get; set; }
    }

    public sealed class TypeD1
    {
        public TypeD1(TypeC1 c)
        {
            y = c.x;
        }

        public TypeD1() { }

        public static implicit operator TypeD1(int x)
        {
            TypeD1 d1 = new TypeD1();
            d1.y = x;
            return d1;
        }

        public static explicit operator Int32(TypeD1 d)
        {
            return d.y;
        }

        public int y { get; set; }
    }

    public static class StringExtension
    {
        public static string GetCheetCode(this String s)
        {
            string str = "Papa Piche => Edith, Lisa et Maggie !";
            return str;
        }
    }

    public partial class PartialClass1
    {
        partial void DisplayX();
        public void Info()
        {
            DisplayX();
        }

        public int x { get; set; }
    }

    public partial class PartialClass1
    {
        partial void DisplayX()
        {
            Console.WriteLine("Value = {0}", x);
        }
    }

    public class Tools
    {
        public static void Func1(int x = 10, int y = 20, string str = "Hello World")
        {
            Console.WriteLine("{0} {1} {2}", x, y, str);
        }
        public static void Add100(ref int x)
        {
            x += 100;
        }

        public static void GetPi(out double x)
        {
            x = 3.1415129265359;
        }
        public static void PrintAll(params string[] msg)
        {
            foreach (string str in msg)
            {
                Console.Write(str);
                Console.Write(" ");
            }
            Console.WriteLine();
        }
        public static void PrintTypes(params Object[] objects)
        {
            for (int i = 0; i != objects.Length; ++i)
            {
                Object aParam = objects[i];
                Console.WriteLine(aParam.GetType());
            }
        }
    }

    public class Employee
    {
        public string Name;
        public int Age;
    }

    public class Employee2
    {
        private string _name;
        private int _age;

        public string GetName()
        {
            return _name;
        }

        public void SetName(string value)
        {
            _name = value;
        }

        public int GetAge()
        {
            return _age;
        }

        public void SetAge(int age)
        {
            if (age < 0 || age > 120)
            {
                throw new ArgumentOutOfRangeException("age", age, "Value is out of range");
            }
            _age = age;
        }
    }

    public class Employee3
    {
        private string _name;
        private int _age;
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public int Age
        {
            get { return _age; }
            set
            {
                if (value < 0 || value > 120)
                {
                    throw new ArgumentOutOfRangeException("value", value, "Value is out of range");
                }
                _age = value;
            }
        }
    }

    public class Employee4
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }

    public class MyArray
    {
        public MyArray(int size)
        {
            _size = size;
            _data = new String[_size];
        }

        public String this[int pos]
        {
            get
            {
                return _data[pos];
            }

            set
            {
                _data[pos] = value;
            }
        }

        private String[] _data;
        private int _size;
    }

    public class Person
    {
        private string _name;
        public string Name
        {
            get { return _name; }
            protected set { _name = value; }
        }
        //...
    }

    public class PersonArgs : EventArgs
    {
        private string _name;
        private int _age;

        public PersonArgs(string name, int age)
        {
            _name = name;
            _age = age;

        }
        public string Name
        {
            get { return _name; }
        }

        public int Age
        {
            get { return _age; }
        }
    }

    public class PersonManager
    {
        public event EventHandler<PersonArgs> _NewPerson;
        //...

#if COMMENT
        public delegate void EventHandler<TEVentArgs>(Object sender, TEVentArgs e);
        void MethodName(Object sender, PersonArgs e);
#endif
        protected virtual void OnNewPerson(PersonArgs e)
        {
            e.Raise(this, ref _NewPerson);
        }

        public void CreateAPerson(string name, int age)
        {
            PersonArgs e = new PersonArgs(name, age);
            OnNewPerson(e);
        }
    }

    public static class PersonArgExtensioon
    {
        public static void Raise<TEventArgs>(this TEventArgs e, Object sender, ref EventHandler<TEventArgs> eventDelegate)
        {
            EventHandler<TEventArgs> temp = Volatile.Read(ref eventDelegate);
            if (temp != null)
            {
                temp(sender, e);
            }

        }
    }

    public class PMHandler
    {
        private void Pm__NewPerson(object sender, PersonArgs e)
        {
            Console.WriteLine("{0} {1}", e.Name, e.Age);
        }

        public void Process()
        {
            PersonManager pm = new PersonManager();
            pm._NewPerson += Pm__NewPerson;
            pm.CreateAPerson("Edith", 17);
        }
    }

    public class MyListString : List<String>
    {
    }

    public class MyArray<T>
    {
        public MyArray(int size)
        {
            _data = new T[size];
        }

        public T this[int index]
        {
            get { return _data[index]; }
            set { _data[index] = value; }
        }

        // ...

        private T[] _data;
    }

    public interface IEnumerator<T> : IDisposable, System.Collections.IEnumerator
    {
        T Current { get; }
    }

    public class AType1
    {
        public delegate TReturn CallMe<TReturn, TKey, TValue>(TKey key, TValue value);
    }

    public class PrivateAffector<T>
    {
        private T _value;

        public void SetValue<K>(T TValue, K KValue)
        {
            Console.WriteLine("{0}", KValue);
            _value = TValue;
        }

        public void DisplayValue()
        {
            Console.WriteLine("{0}", _value);
        }
    }

    public interface MyWork
    {
        bool DoWork();
    }

    public class MyWorkerStuff<T> where T : MyWork, new()
    {
        T _data;

        //public MyWorkerStuff() { }

        public void Process(T obj)
        {
            obj.DoWork();
        }

    }

    public class MyWorkEx : MyWork
    {
        public MyWorkEx() { }
        public bool DoWork()
        {
            Console.WriteLine("MyWorkEx::DoWork");
            return true;
        }
    }

    public interface IProcess
    {
        bool Process();
    }

    public interface IProcess2<T>
    {
        T Item { get; }
        bool Process(T t);
    }

    public interface IMyEnumerator<T>
    {
        T Get_Item();
    }

    public interface IMyCollection<T> : IMyEnumerator<T>
    {
        int Count { get; }
        void Add(T item);
        void Clear();
        bool Contains(T item);
        bool Remove(T item);
    }

    public class MyCollection<T> : IMyCollection<T>, IMyEnumerator<T>
    {
        public int Count => throw new NotImplementedException();

        public void Add(T item)
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public bool Contains(T item)
        {
            throw new NotImplementedException();
        }

        public T Get_Item()
        {
            throw new NotImplementedException();
        }

        public bool Remove(T item)
        {
            throw new NotImplementedException();
        }
    }

    public class MyCollection2<T> : IMyCollection<T>, IMyEnumerator<T>
    {
        int IMyCollection<T>.Count => throw new NotImplementedException();

        void IMyCollection<T>.Add(T item)
        {
            throw new NotImplementedException();
        }

        void IMyCollection<T>.Clear()
        {
            throw new NotImplementedException();
        }

        bool IMyCollection<T>.Contains(T item)
        {
            throw new NotImplementedException();
        }

        T IMyEnumerator<T>.Get_Item()
        {
            throw new NotImplementedException();
        }

        bool IMyCollection<T>.Remove(T item)
        {
            throw new NotImplementedException();
        }
    }

    public class DelegateSample1
    {
        public static void Init()
        {
            Action<string> fn1 = Process;
            fn1("Hello Maggie !");
        }

        public static void Process(string str)
        {
            Console.WriteLine("Message: {0}", str);
        }
    }

    public class DelegateSample2
    {
        public static void Init()
        {
            Func<string, bool> fn1 = Process;
            bool ret = fn1("Hello Maggie !");
        }

        public static bool Process(string str)
        {
            Console.WriteLine("Message: {0}", str);
            return true;
        }
    }

    /*

    public struct Nullable<T> where T : struct
    {
        public Nullable(T value);
        public bool HasValue { get; }
        public T Value { get; }
        public override bool Equals(object other);
        public override int GetHashCode();
        public T GetValueOrDefault();
        public T GetValueOrDefault(T defaultValue);
        public override string ToString();
        public static implicit operator T?(T value);
        public static explicit operator T(T? value);
    }
     */

    enum Shape
    {
        Rectangle,  // 0
        Ellipse,    // 1
        Line        // 2
    }

    class DrawingStuff
    {
        public static void Draw(Shape shape)
        {
            if (shape == Shape.Rectangle)
            {
                Console.WriteLine("Dessine un Rectangle");
            }
            else { }
        }
    }

    [Flags]
    enum Permission
    {
        Read    = 0x00000001,
        Write   = 0x00000002,
        Append  = 0x00000004,
        Other   = 0x00000008
    }

    class Product1
    {
        public delegate void Feedback(int val);

        public void Count(int from, int to, Feedback routine)
        {
            for (int i = from; i < to; i++)
            {
                if (routine != null)
                {
                    routine(i);
                }
            }
        }
    }
    class Product2
    {
        public void Feedback(int val)
        {
            Console.WriteLine("val:{0}", val);
        }

        public void Count(int from, int to, Action<int> routine)
        {
            for (int i = from; i < to; i++)
            {
                if (routine != null)
                {
                    routine(i); // eq. routine.Invoke(i);
                }
            }
        }
    }


    class Program
    {
        public static void myFeedback(int val) 
        { 
            Console.WriteLine("val:{0}", val); 
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World !");
            TypeC1 a = new TypeC1();
            TypeC1 b = new TypeC1();
            a.x = 10;
            b.x = 20;
            TypeC1 c = a + b;
            Console.WriteLine("c={0}", c.x);

            TypeC1 c1 = new TypeC1();
            c1.x = 100;
            TypeD1 d = new TypeD1(c1);
            Console.WriteLine("d={0}", d.y);

            TypeD1 d1 = 10;
            Console.WriteLine("d1={0}", d1.y);
            int i1 = (Int32)d1;
            Console.WriteLine("i1={0}", i1);

            string str = "any data";
            Console.WriteLine("value:{0}", str.GetCheetCode());

            PartialClass1 pc1 = new PartialClass1();
            pc1.x = 100;
            pc1.Info();

            Tools.Func1();
            Tools.Func1(20, 100, "Papa Piche");
            Tools.Func1(x: 10, y: 20);
            Tools.Func1(x: 10);
            Tools.Func1(str: "Maggie coquine !");

            int x1 = 5;
            Tools.Add100(ref x1);
            Console.WriteLine(x1); // 105

            double y1;
            Tools.GetPi(out y1);
            Console.WriteLine(y1); // 3.1415129565359

            Tools.PrintAll("Edith", "Lisa", "Maggie");
            Tools.PrintAll("Je", "vous", "aime", "les filles !");
            /*
            Edith Lisa Maggie
            Je vous aime les filles !
            */
            
            Tools.PrintTypes("Edith", 17, "Dijon");
            /*
            System.String
            System.Int32
            System.String
            */

            Employee e1 = new Employee();
            e1.Name = "Christophe Pichaud";
            e1.Age = 45;

            Employee2 e2 = new Employee2();
            e2.SetName("Lisa Pichaud Castany");
            e2.SetAge(14);

            Employee3 e3 = new Employee3();
            e3.Name = "Maggie la tornade";
            e3.Age = 9;
            //e3.Age = -10; // Exception !

            Employee4 e4 = new Employee4();
            e4.Name = "Edith";
            e4.Age = 17;

            Employee4 a4 = new Employee4() { Name = "Papy Jean-Marc", Age = 65 };
            Employee4 b4 = new Employee4() { Name = "Mamy Mireille", Age = 67 };

            var p1 = new { Price = 1.5f, Name = "Cocal Cola 1.5L" };
            Console.WriteLine("Price={0}, Name={1}", p1.Price, p1.Name);

            MyArray mya1 = new MyArray(10);
            mya1[0] = "Edith";
            mya1[1] = "Lisa";
            mya1[2] = "Maggie";
            Console.WriteLine(mya1[2]);

            PMHandler pmh = new PMHandler();
            pmh.Process();

            List<String> filles = new List<String>();
            filles.Add("Edith");
            filles.Add("Lisa");
            filles.Add("Maggie");
            Console.WriteLine(filles.Count);

            List<int> ages = new List<int>();
            ages.Add(17);
            ages.Add(14);
            ages.Add(9);

            MyArray<string> mesFilles = new MyArray<string>(3);
            mesFilles[0] = "Edith";
            mesFilles[1] = "Lisa";
            mesFilles[2] = "Maggie";
            Console.WriteLine(mesFilles[2]);

            PrivateAffector<string> pa1 = new PrivateAffector<string>();
            pa1.SetValue<int>("hello world", 100);
            pa1.DisplayValue();
            pa1.SetValue<string>("hello world", "the world of C!");
            pa1.DisplayValue();

            MyWorkerStuff<MyWorkEx> a1 = new MyWorkerStuff<MyWorkEx>();
            MyWorkEx w1 = new MyWorkEx();
            a1.Process(w1);

            DelegateSample1.Init();
            DelegateSample2.Init();

            DrawingStuff.Draw(Shape.Rectangle);

            Permission perms = Permission.Read | Permission.Write;

            Int32? in1 = 100;
            if (in1.HasValue)
            {
                Console.WriteLine("i={0}", in1);
            }

            Nullable<int> ni1 = 10;
            int valni1 = ni1.Value;

            Int32? in2 = null;


            Product1 product1 = new Product1();
            product1.Count(0, 3, myFeedback);

            Product2 product2 = new Product2();
            Action<int> fn = product2.Feedback;
            product2.Count(0, 4, fn);

            int a10 = 10;
            if (a10 == 10)
                throw new Exception("a10 == 10 !");

            int a0 = 10;
            while (a0 > 2)
            {
	            try
	            {
		            ++a0;
	            }
	            catch (Exception ex)
	            {
                    Console.WriteLine("Erreur générale... plantage ! Message:{0}", ex.Message);
	            }
	            catch
	            {
                    Console.WriteLine("Erreur générale... plantage !"););
                }
            }

        }

    }
}
