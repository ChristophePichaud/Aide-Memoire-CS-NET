using System;

namespace ConsoleApp
{
    public class TypeA
    {
        public int i;
    }

    public class TypeB : TypeA
    {
        public int j;
    }
    public sealed class SomeType
    { // 1
      // Nested class
        private class SomeNestedType { } // 2

        // Constant, read-only, and static read/write field
        private const Int32 c_SomeConstant = 1; // 3
        private readonly String m_SomeReadOnlyField = "2"; // 4
        private static Int32 s_SomeReadWriteField = 3; // 5

        // Type constructor
        static SomeType() { } // 6

        // Instance constructors
        public SomeType(Int32 x) { } // 7
        public SomeType() { } // 8

        // Instance and static methods
        private String InstanceMethod() { return null; } // 9

        // Instance property
        public Int32 SomeProp
        { // 11
            get { return 0; } // 12
            set { } // 13
        }
        // Instance parameterful property (indexer)
        public Int32 this[String s]
        { // 14
            get { return 0; } // 15
            set { } // 16
        }
        // Instance event
        public event EventHandler SomeEvent; // 17
    }

    public class MyTypeA { }
    internal class MyTypeB { }
    class MyTypeC { }

    public static class MyTypeStaticA
    {
        public static void AStaticMethod() { }
        public static int Number
        {
            get { return number; }
            set { number = value; }
        }

        private static int number;
    }

    public class MyTypeA2
    {
        public const int i = 10;
    }

    public class MyTypeA3
    {
        public readonly int i;
        public MyTypeA3()
        {
            i = 10;

        }

        private int j;

        public void Method1()
        {
            j = 20;
        }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            // ...
    try
    {
        Object o = new object();
        TypeA a0 = (TypeA)o;
    }
    catch( Exception ex)
    {
        Console.WriteLine("{0}", ex.GetType());
    }

    TypeB b1 = new TypeB();
    b1.i = 10;
    b1.j = 20;
    TypeA a1 = (TypeA)b1;
    Console.WriteLine("{0} {1}", a1.i, b1.j);

    TypeB b2 = new TypeB();
    bool bres1 = b2 is TypeA; // True
    Console.WriteLine(bres1);
    bool bres2 = b2 is Object;
    Console.WriteLine(bres2); // True
    TypeA a3 = new TypeA();
    bool bres3 = a3 is TypeB;
    Console.WriteLine(bres3); // False

    TypeA a4 = new TypeA();
    TypeB b4 = (a4 as TypeB);
    if( b4 == null )
        Console.WriteLine("b4 is null");


        }
    }
}
