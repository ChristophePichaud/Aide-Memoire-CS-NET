using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.IO;
using System.IO.Compression;
using System.IO.MemoryMappedFiles;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security;
using System.Security.Policy;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
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


    public class Program
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

            /*
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
                    Console.WriteLine("Erreur générale... plantage !");
                }
            }
            */

            int[] ar1 = { 5, 10, 15, 20, 25 };
            int first = ar1[0];
            int last = ar1[ar1.Length - 1];
            foreach (int i in ar1)
            {
                Console.WriteLine(i);
            }

            List<string> lst1 = new List<string>();
            lst1.Add("Edith");
            lst1.Add("Lisa");
            lst1.Add("Maggie");
            lst1.RemoveRange(0, 2);
            lst1.Add("Edith 2");
            lst1.Add("Lisa 2");
            lst1.RemoveAt(0);
            lst1.Remove("Lisa 2");
            lst1.Add("Maggie 2");
            Console.WriteLine(lst1[0]);
            foreach (string f in lst1)
            {
                Console.WriteLine(f);
            }
            lst1.Clear();

            LinkedList<string> lst2 = new LinkedList<string>();
            lst2.AddFirst("Edith");
            lst2.AddAfter(lst2.First, "Lisa");
            lst2.AddLast("Maggie");
            lst2.AddBefore(lst2.Last, "et super cocotte !");
            foreach (string ff2 in lst2)
            {
                Console.WriteLine(ff2);
            }

            Queue<string> queue1 = new Queue<string>();
            queue1.Enqueue("Edith");
            queue1.Enqueue("Lisa");
            queue1.Enqueue("Maggie");
            string s1 = queue1.Dequeue();
            Console.WriteLine("La plus grande, c'est {0}", s1); // Edith

            Stack<string> stack1 = new Stack<string>();
            stack1.Push("Edith");
            stack1.Push("Lisa");
            stack1.Push("Maggie");
            string s01 = stack1.Peek();
            Console.WriteLine("La coquine, c'est {0}", s01); // Maggie

            BitArray ba1 = new BitArray(2);
            ba1[0] = false;
            ba1[1] = true;
            ba1.Xor(ba1);
            Console.WriteLine("ba1[0]={0} ba1[1]={1}", ba1[0], ba1[1]);

            HashSet<string> hs1 = new HashSet<string>();
            hs1.Add("Edith");
            hs1.Add("Lisa");
            hs1.Add("Maggie");
            hs1.Add("Bart");
            if (hs1.Contains("Lisa"))
            {
                Console.WriteLine("Lisa est ici !");
            }
            hs1.Remove("Bart");

            Dictionary<string, string> df = new Dictionary<string, string>();
            df.Add("17", "Edith");
            df.Add("14", "Lisa");
            df.Add("9", "Maggie");
            foreach (KeyValuePair<string, string> kvp in df)
            {
                Console.WriteLine("k={0} v:{1}", kvp.Key, kvp.Value);
            }
            if (df.ContainsKey("9"))
            {
                Console.WriteLine("key 9 exists");
                Console.WriteLine("v:{0}", df["9"]);
            }

            string[] filles2 = { "Edith", "Lisa", "Maggie" };
            IEnumerable<string> filteredFilles = Enumerable.Where(filles2, f => f.Contains('a'));
            foreach (string f02 in filteredFilles)
            {
                Console.WriteLine(f02);
            }
            // Using extensions methods
            IEnumerable<string> filteredFilles2 = filles2.Where(f => f.Contains('a'));
            foreach (string f3 in filteredFilles2)
            {
                Console.WriteLine(f3);
            }

            string[] famille1 = { "Edith", "Lisa", "Maggie", "Bart" };
            IEnumerable<string> filtered2 = famille1
                .Where(f => f.Contains('a'))
                .OrderBy(f => f.Length)
                .Select(f => f.ToUpper());
            foreach (string f0 in filtered2)
            {
                Console.WriteLine(f0);
            }
            IEnumerable<string> filtered4 = from f4 in famille1
                                            where f4.Contains('a')
                                            orderby f4.Length
                                            select f4.ToUpper();
            foreach (string f04 in filtered2)
            {
                Console.WriteLine(f04);
            }

            /*
            DataContext dc = new DataContext("Server=localhost;Database=Aide-Memoire-CS;Integrated Security=SSPI;");
            Table<Customer> customers = dc.GetTable<Customer>();
            IQueryable<string> filtered3 = from n in customers
                                        where n.Name.Contains("a")
                                        orderby n.Name.Length
                                        select n.Name.ToUpper();
            foreach (string f3 in filtered3)
            {
                Console.WriteLine(f3);
            }

            Table<Customer> customers5 = dc.GetTable<Customer>();
            IEnumerable<Customer> filtered5 = customers5
                .Where(f => f.Name.Contains('a'))
                .OrderBy(f => f.Name.Length)
                .AsEnumerable();
            //foreach (Customer c5 in filtered5)
            //{
            //    Console.WriteLine(c5.Name);
            //}
            var it = filtered5.GetEnumerator();
            if (it != null)
            {
                while (true)
                {
                    if (it.MoveNext() == false)
                        break;
                    Console.WriteLine(it.Current.Name);
                }
            }
            */


            string[] famille = { "Edith", "Lisa", "Maggie", "Bart" };
            IEnumerable<string> fa1 = famille.Where(name => name.EndsWith("e"));
            Dump(fa1);
            IEnumerable<string> fa2 = from n in famille
                                      where n.EndsWith("e")
                                      select n;
            Dump(fa2);
            IEnumerable<string> fa3 = from n in famille
                                      where n.Length > 4
                                      let u = n.ToUpper()
                                      where u.EndsWith("E")
                                      select u;
            Dump(fa3);

            IEnumerable<string> fa4 = famille.Where((n, i) => i % 2 == 0);
            Dump(fa4); // Edith & Maggie

            MyDataContext datacontext = new MyDataContext("Server=localhost;Database=Aide-Memoire-CS;Integrated Security=SSPI;");
            try
            {
                IQueryable<Purchase> qp1 = datacontext.Purchases.Where(p => p.Description.CompareTo("C") < 0);

                string[] some = { "Lisa", "Maggie" };
                IQueryable<Customer> qc1 = from c2 in datacontext.Customers
                                           where some.Contains(c2.Name)
                                           select c2;

                IQueryable<Book> qb1 = datacontext.Books
                       .Where(b1 => b1.Title.Contains("Microsoft"))
                       .OrderBy(b1 => b1.Title)
                       .Take(10);

                IQueryable<Book> qb2 = datacontext.Books
                       .Where(b1 => b1.Title.Contains("Microsoft"))
                       .OrderBy(b1 => b1.Title)
                       .Skip(10);
            }
            catch (Exception ex)
            {
            }

            int[] age = { 9, 14, 19, 1 }; // Bart is one, the cat !
            IEnumerable<int> ageFilles = age.TakeWhile(ag => ag > 5);
            Dump<int>(ageFilles); // 9 14 19
            IEnumerable<int> ageFilles2 = age.SkipWhile(ag => ag != 14);
            Dump<int>(ageFilles2); // 14 19 1

            string m1 = "1234567890-0987654321-1234567890";
            char[] m1res = m1.Distinct().ToArray();
            string res1 = new string(m1res);
            Console.WriteLine(res1); // 1234567890-

            Book[] bs1 = {
                new Book { ID = 1, Title = "Inside MAPI" },
                new Book { ID = 2, Title = "Inside Windows NT" },
                new Book { ID = 3, Title = "Inside Visual C++" },
                new Book { ID = 4, Title = "The C++ Object Model" }
            };
            IEnumerable<string> res2 = from b1 in bs1
                                       where b1.Title.Contains("C++")
                                       select b1.Title;
            Dump<string>(res2);
            IEnumerable<Book> res3 = from b2 in bs1
                                     where b2.Title.Contains("C++")
                                     select b2;

            var res4 = from b3 in bs1
                       where b3.Title.Contains("C++")
                       select new { Title = b3.Title, Series = "Inside", Editor = "Microsoft Press" };

            IEnumerable<string> res5 = bs1.Select((v, i) => i + ":" + v.Title);
            Dump<string>(res5);

            var res6 = from b5 in bs1
                       where b5.Title.Contains("C++")
                       select new
                       {
                           ID = new Guid(),
                           RelatedBooks = from b6 in bs1
                                          where b6.Title.Contains("C++")
                                          select b6.ID
                       };

            try
            {
                var res7 =
                    from cu1 in datacontext.Customers
                    select new
                    {
                        cu1.Name,
                        Purchases = from pu1 in datacontext.Purchases
                                    where pu1.CustomerID == cu1.ID && pu1.Price > 100
                                    select new { pu1.Price, pu1.Description }
                    };
            }
            catch (Exception ex)
            {
            }

            string[] authors = { "Stanley Lippman", "Bjarne Stroustrup", "Herb Sutter", "Don Box", "Jeffrey Richter", "Marc Russinovitch" };
            IEnumerable<string> res8 = authors.SelectMany(s => s.Split());
            Dump<string>(res8);

            IEnumerable<string> res9 = from r9 in authors
                                       from name in r9.Split()
                                       select name;
            Dump<string>(res9);

            /*
            try
            {
                var res10 =
                    from cu1 in datacontext.Customers
                    from pu1 in datacontext.Purchases
                    select cu1.Name + "->" + pu1.Description;

                var res11 =
                    from cu1 in datacontext.Customers
                    from pu1 in datacontext.Purchases
                    where cu1.ID == pu1.CustomerID
                    select cu1.Name + "->" + pu1.Description;

                var res12 =
                    from cu1 in datacontext.Customers
                    from pu1 in cu1.Purchases
                    select new { cu1.Name, pu1.Description };

                var res13 =
                    from cu1 in datacontext.Customers
                    from pu1 in cu1.Purchases.DefaultIfEmpty()
                    select new { cu1.Name, pu1.Description };

                var res14 =
                    from cu1 in datacontext.Customers
                    from pu1 in cu1.Purchases.Where(pu1.Price < 100).DefaultIfEmpty()
                    select new { cu1.Name, pu1.Description };

                IQueryable<string> res15 =
                    from cu1 in datacontext.Customers
                    join pu1 in datacontext.Purchases on cu1.ID equals pu1.CustomerID
                    select cu1.Name + ", " + pu1.Description;

                var res16 =
                    from cu1 in datacontext.Customers
                    from pu1 in cu1.Purchases on cu1.ID equals pu1.CustomerID
                    select new { cu1.Name, pu1.Description };

                datacontext.Customers.Join(datacontext.Purchases, 
                    cu1 => cu1.ID,
                    pu1 => pu1.CustomerID,
                    (cu1, pu1) => new { cu1.Name, pu1.Description, pu1.Price }));

                IQueryable<string> res17 =
                    from cu1 in datacontext.Customers
                    join pu1 in datacontext.Purchases on cu1.ID equals pu1.CustomerID
                    orderby pu1.Price
                    select cu1.Name + ", " + pu1.Description;

                IQueryable<IEnumerable<Purchase>> res18 =
                    from cu1 in datacontext.Customers
                    join pu1 in datacontext.Purchases on cu1.ID equals pu1.CustomerID
                    into custPurchases
                    select custPurchases;
            }
            catch (Exception ex)
            {
            }
            */

            string[] coquines1 = { "Edith", "Lisa", "Maggie", "Bart" };
            IEnumerable<string> co1 = coquines1
                .OrderBy(c2 => c2);
            Dump<string>(co1);

            IEnumerable<string> co2 = coquines1
                .OrderBy(c2 => c2.Length)
                .ThenBy(c2 => c2);
            Dump<string>(co2);

            IEnumerable<string> co3 = from ca1 in coquines1
                                      orderby ca1.Length, ca1
                                      select ca1;
            Dump<string>(co3);

            IEnumerable<string> co4 = coquines1
                .OrderBy(c2 => c2.Length)
                .ThenBy(c2 => c2)
                .AsEnumerable()
                .Where(c2 => c2 != "Bart");
            Dump<string>(co4);

            string[] books2 = Directory.GetFiles(@"D:\Files_Books");
            IEnumerable<IGrouping<string, string>> res20 =
                books2.GroupBy(f => Path.GetExtension(f))
                .OrderBy(gr1 => gr1.Key);
            foreach (IGrouping<string, string> grouping in res20)
            {
                Console.WriteLine("Ext:{0}", grouping.Key);
                foreach (string filename in grouping)
                {
                    Console.WriteLine("File:{0}", filename);
                }
            }

            var res21 = from file in books2
                        group file by Path.GetExtension(file) into grouping
                        orderby grouping.Key
                        select grouping;


            int[] seq1 = {
                1, 2, 3, 4, 5, 6, 7, 8, 9, 0,
                0, 9, 8, 7, 6, 5, 4, 3, 2, 1,
                1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };
            int[] seq2 = {
                1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };

            IEnumerable<int> ie1 = seq1.Concat(seq2);
            IEnumerable<int> ie2 = seq1.Union(seq2);
            IEnumerable<int> ie3 = seq1.Intersect(seq2);
            IEnumerable<int> ie4 = seq1.Except(seq2);

            int[] suite = { 1, 2, 3, 5, 10, 20 };
            int f1 = suite.First(); // 1
            int f2 = suite.First(a2 => a2 % 10 == 0); // 10
            int l1 = suite.Last(); // 20
            int l2 = suite.Last(b2 => b2 % 2 == 0); // 20
            int ress1 = suite.Single(ss1 => ss1 % 3 == 0); // 3
            int ress2 = suite.SingleOrDefault(ss1 => ss1 % 7 == 0); // 0
            int el1 = suite.ElementAt(2); // 3
            int el2 = suite.ElementAtOrDefault(10); // 0

            int[] suite2 = { 1, 2, 3, 5, 10, 20 };
            int resa1 = suite2.Count();
            int resa2 = suite.Min();
            int resa3 = suite.Max();
            int resa4 = suite.Sum();
            double resa5 = suite.Average();
            int resa6 = suite.Aggregate(0, (total, n) => total + n); // 41

            int[] suite3 = { 1, 2, 3, 5, 10, 20 };
            bool resb1 = suite3.Contains(3); // true
            bool resb2 = suite3.Any(nb2 => nb2 % 3 == 0); // true
            bool resb3 = suite3.All(nb3 => nb3 < 50); // true

            IEnumerable<int> resc1 = Enumerable.Range(1, 10); // 1..10
            Dump<int>(resc1);
            IEnumerable<int> resc2 = Enumerable.Repeat(5, 3); // 5 5 5 
            Dump<int>(resc2);

            FileStream fs = new FileStream("helloworld.dat", FileMode.Create);
            fs.WriteByte(26);
            byte[] bloc = { 10, 13, 50, 51 };
            fs.Write(bloc, 0, bloc.Length);
            fs.Close();

            FileStream fs2 = new FileStream("helloworld.dat", FileMode.Open);
            byte[] data2 = new byte[1024];
            int count = fs2.Read(data2, 0, data2.Length);
            fs2.Close();

            FileStream fstr1 = File.OpenRead("helloworld.dat"); // read-only
            fstr1.Close();
            FileStream fstr2 = File.OpenWrite("helloworld.dat"); // write-only
            fstr2.Close();
            FileStream fstr3 = File.Create("helloworld.dat"); // read/write
            fstr3.Close();

            TextWriter tw1 = File.AppendText("helloworld2.txt");
            tw1.WriteLine("hello world !");
            tw1.Close();

            TextReader tr1 = File.OpenText("helloworld2.txt");
            string datatr1 = tr1.ReadLine();
            tr1.Close();
            Console.WriteLine(datatr1);

            Stream stream1 = File.Create("A1.txt");
            TextWriter tw2 = new StreamWriter(stream1, Encoding.Unicode);
            tw2.WriteLine("this is an unicode string !");
            tw2.Close();
            stream1.Close();

            byte[] datatw2 = File.ReadAllBytes("A1.txt");
            foreach (byte bA1 in datatw2)
            {
                Console.Write("{0} ", bA1);
            }
            Console.WriteLine();

            string data2tw2 = File.ReadAllText("A1.txt");
            foreach (char bA1 in data2tw2)
            {
                Console.Write("{0} ", bA1);
            }
            Console.WriteLine();
            Console.WriteLine(data2tw2);

            Stream stream2 = File.Create("Data1.dat");
            BinaryWriter bw1 = new BinaryWriter(stream2);
            Employee emp1 = new Employee() { Age = 9, Name = "Maggie" };
            bw1.Write(emp1.Age);
            bw1.Write(emp1.Name);
            bw1.Close();
            stream2.Close();

            Stream stream3 = File.OpenRead("Data1.dat");
            BinaryReader br1 = new BinaryReader(stream3);
            Employee emp2 = new Employee();
            emp2.Age = br1.ReadInt32();
            emp2.Name = br1.ReadString();
            br1.Close();
            stream3.Close();
            Console.WriteLine("Age:{0} Name:{1}", emp2.Age, emp2.Name);

            using (Stream stream4 = File.Create("Data1.dat"))
            {
                using (BinaryWriter bw2 = new BinaryWriter(stream4))
                {
                    Employee emp3 = new Employee() { Age = 9, Name = "Maggie" };
                    bw2.Write(emp3.Age);
                    bw2.Write(emp3.Name);
                }
            }

            Stream stream5 = File.Create("DataCompressed1.dat");
            DeflateStream ds1 = new DeflateStream(stream5, CompressionMode.Compress);
            string am1 = "Maggie est un amour ultime";
            byte[] dataam1 = Encoding.UTF8.GetBytes(am1);
            ds1.Write(dataam1, 0, dataam1.Length);
            ds1.Close();
            stream5.Close();

            Stream stream6 = File.OpenRead("DataCompressed1.dat");
            DeflateStream ds2 = new DeflateStream(stream6, CompressionMode.Decompress);
            byte[] datads2 = new byte[100];
            int readds2 = ds2.Read(datads2, 0, datads2.Length);
            Array.Resize(ref datads2, readds2);
            string am2 = Encoding.UTF8.GetString(datads2);
            ds2.Close();
            stream6.Close();
            Console.WriteLine("data=<{0}>", am2);

            //ZipFile.CreateFromDirectory(
            //    @"d:\dev\web\ultrafluid.net", 
            //    @"d:\dev\web\ultrafluid.net.zip");

            //FileAttributes 
            FileInfo fi1 = new FileInfo("DataCompressed1.dat");
            Console.WriteLine("{0} {1} {2} {3} {4} {5}",
                fi1.Name,
                fi1.FullName,
                fi1.DirectoryName,
                fi1.Directory.Name,
                fi1.Extension,
                fi1.Length);

            DirectoryInfo di1 = new DirectoryInfo(@"d:\dev\web\ultrafluid.net");
            foreach (FileInfo fi2 in di1.GetFiles())
            {
                Console.WriteLine("{0}", fi2.Name);
            }

            foreach (DriveInfo dri1 in DriveInfo.GetDrives())
            {
                Console.WriteLine("{0} {1} {2} {3}",
                    dri1.Name,
                    dri1.DriveType,
                    dri1.RootDirectory,
                    dri1.TotalSize);
            }

            using (MemoryMappedFile mmFile =
                MemoryMappedFile.CreateNew("SharedSpace", 1024))
            {
                using (MemoryMappedViewAccessor accessor =
                    mmFile.CreateViewAccessor())
                {
                    accessor.Write(0, 100);

                    byte[] data1 = Encoding.UTF8.GetBytes("Ma belle Lisa");
                    accessor.Write(4, data1.Length);
                    accessor.WriteArray(8, data1, 0, data1.Length);
                    MyData mydata1 = new MyData() { X = 9, Y = 14 };
                    accessor.Write(8 + data1.Length, ref mydata1);

                    // This can run in a separate EXE:
                    MemoryMappedFile mmFile2 =
                        MemoryMappedFile.OpenExisting("SharedSpace");
                    MemoryMappedViewAccessor accessor2 =
                        mmFile.CreateViewAccessor();
                    int data = accessor2.ReadInt32(0); // 100
                    Console.WriteLine(data);

                    byte[] data3 = new byte[accessor2.ReadInt32(4)];
                    accessor2.ReadArray(8, data3, 0, data3.Length);
                    string strData = Encoding.UTF8.GetString(data3);
                    Console.WriteLine(strData);
                    MyData mydata2 = new MyData();
                    accessor2.Read(8 + data3.Length, out mydata2);
                    Console.WriteLine("X:{0} Y:{1}",
                        mydata2.X, mydata2.Y);
                }
            }

            TheProduct tp1 = new TheProduct();
            tp1.Name = "XBox One";
            tp1.Price = 330;

            DataContractSerializer dcs = new DataContractSerializer(typeof(TheProduct));
            using (Stream stp1 = File.Create("theproduct1.xml"))
            {
                dcs.WriteObject(stp1, tp1);
            }

            TheProduct tp2;
            using (Stream stp2 = File.OpenRead("theproduct1.xml"))
            {
                tp2 = (TheProduct)dcs.ReadObject(stp2);
            }
            Console.WriteLine("TheProduct {0} {1}", tp2.Name, tp2.Price);

            DataContractSerializer dcs2 = new DataContractSerializer(typeof(TheProduct));
            XmlWriterSettings xws = new XmlWriterSettings() { Indent = true };
            using (XmlWriter xw1 = XmlWriter.Create("theproduct2.xml", xws))
            {
                dcs2.WriteObject(xw1, tp1);
            }

            TheEmployee te1 = new TheEmployee();
            te1.Name = "Maggie";
            te1.Age = 9;

            // Serilisation XML
            DataContractSerializer dcs3 = new DataContractSerializer(typeof(TheEmployee));
            using (XmlWriter xw2 = XmlWriter.Create("maggie.xml", xws))
            {
                dcs3.WriteObject(xw2, te1);
            }

            TheBasket tb1 = new TheBasket();
            tb1.CustomerName = "Pic l'American";
            tb1.NumberofItems = 10;
            tb1.TotalPrice = 525;

            IFormatter ift = new BinaryFormatter();
            using (FileStream stp1 = File.Create("thebasket1.bin"))
            {
                ift.Serialize(stp1, tb1);
            }

            TheBasket tb2;
            using (FileStream stp2 = File.OpenRead("thebasket1.bin"))
            {
                tb2 = (TheBasket)ift.Deserialize(stp2);
            }
            Console.WriteLine("TheBasket {0} {1} {2}", 
                tb2.CustomerName, 
                tb2.NumberofItems, 
                tb2.TotalPrice);


            TheRoom tro1 = new TheRoom();
            tro1.ChildName = "Lisa";
            tro1.NumberOfGames = 5;
            tro1.Surface = 12;

            IFormatter ift2 = new BinaryFormatter();
            using (FileStream stp1 = File.Create("theroom1.bin"))
            {
                ift2.Serialize(stp1, tro1);
            }
            
            TheRoom tro2;
            using (FileStream stp2 = File.OpenRead("theroom1.bin"))
            {
                tro2 = (TheRoom)ift.Deserialize(stp2);
            }
            Console.WriteLine("TheRoom {0} {1} {2}",
                tro2.ChildName,
                tro2.NumberOfGames,
                tro2.Surface);

            SoccerPlayer sp1 = new SoccerPlayer();
            sp1.Age = 32;
            sp1.Name = "Leo Messi";

            XmlSerializer xs1 = new XmlSerializer(typeof(SoccerPlayer));
            using (Stream stp1 = File.Create("soccerplayer1.xml"))
            {
                xs1.Serialize(stp1, sp1);
            }

            SoccerPlayer sp2;
            using (Stream stp2 = File.OpenRead("soccerplayer1.xml"))
            {
                sp2 = (SoccerPlayer) xs1.Deserialize(stp2);
            }
            Console.WriteLine("SoccerPlayer {0} {1}", sp2.Name, sp2.Age);

            SoccerPlayer2 spl2 = new SoccerPlayer2();
            spl2.Age = 34;
            spl2.Name = "Christinao Ronaldo";

            XmlSerializer xs2 = new XmlSerializer(typeof(SoccerPlayer2));
            using (Stream stp1 = File.Create("soccerplayer2.xml"))
            {
                xs2.Serialize(stp1, spl2);
            }
        }

        public class TheAddress : IXmlSerializable
        {
            public string Street;
            public string PostCode;
            public XmlSchema GetSchema() { return null; }
            public void ReadXml(XmlReader reader)
            {
                reader.ReadStartElement();
                Street = reader.ReadElementContentAsString("Street", "");
                PostCode = reader.ReadElementContentAsString("PostCode", "");
                reader.ReadEndElement();
            }
            public void WriteXml(XmlWriter writer)
            {
                writer.WriteElementString("Street", Street);
                writer.WriteElementString("PostCode", PostCode);
            }
        }

        public class SoccerPlayer2
        {
            [XmlElement("PlayerName")] 
            public string Name;
            
            [XmlAttribute("PlayerAge")]
            public int Age;
        }

        public class SoccerPlayer
        {
            public string Name;
            public int Age;
        }

        [Serializable]
        class TheRoom : ISerializable
        {
            public string ChildName;
            public int Surface;
            public int NumberOfGames;

            public void GetObjectData(SerializationInfo info, StreamingContext context)
            {
                info.AddValue("ChildName", ChildName);
                info.AddValue("Surface", Surface);
                info.AddValue("Games", NumberOfGames);

            }

            protected TheRoom(SerializationInfo info, StreamingContext context)
            {
                ChildName = info.GetString("ChildName");
                Surface = info.GetInt32("Surface");
                NumberOfGames = info.GetInt32("Games");
            }

            public TheRoom()
            { }
        }


        [Serializable]
        class TheBasket
        {
            public string CustomerName;
            public int NumberofItems;
            public int TotalPrice;

            [NonSerialized]
            public int Shipping;

            [OptionalField(VersionAdded = 2)]
            public string Currency;
        }

        [DataContract(Name ="Employee", Namespace ="http://www.dunod.com/aide-memoire")]
        class TheEmployee
        {
            [DataMember(Name="FirstLastName")]
            public string Name;

            [DataMember(Name ="YearsOld")]
            public int Age;

            [OnSerializing]
            void BeforeSerialize(StreamingContext sc)
            {
                if (Name == "Maggie")
                    Name = "Audrey";
            }
        }

        [DataContract]
        class TheProduct
        {
            [DataMember]
            public string Name;

            [DataMember]
            public int Price;
        }

        struct MyData
        {
            public int X;
            public int Y;
        }

        public static void Dump(IEnumerable<string> e)
        {
            foreach (string s in e)
            {
                Console.WriteLine(s);
            }
        }

        public static void Dump<T>(IEnumerable<T> e)
        {
            foreach (T t in e)
            {
                Console.WriteLine(t);
            }
        }

        [Table]
        public class Customer
        {
            [Column(IsPrimaryKey = true)] public int ID;
            [Column] public string Name;

            public List<EntityRef<Purchase>> Purchases;
        }

        [Table]
        public class Purchase
        {
            [Column(IsPrimaryKey = true)] public int ID;
            [Column] public int? CustomerID;
            [Column] public string Description;
            [Column] public decimal Price;
            [Column] public DateTime Date;

            EntityRef<Customer> custRef;
            [Association(Storage = "custRef", ThisKey = "CustomerID", IsForeignKey = true)]
            public Customer Customer
            {
                get { return custRef.Entity; }
                set { custRef.Entity = value; }
            }
        }

        [Table]
        public class Book
        {
            [Column(IsPrimaryKey = true)] public int ID;
            [Column] public string Title;
        }

        public class MyDataContext : DataContext
        {
            public MyDataContext(string cnx) : base(cnx) { }
            public Table<Customer> Customers { get { return GetTable<Customer>(); } }
            public Table<Purchase> Purchases { get { return GetTable<Purchase>(); } }
            public Table<Book> Books { get { return GetTable<Book>(); } }
        }
    }
}
