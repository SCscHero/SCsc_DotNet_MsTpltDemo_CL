using System;

namespace CsLangVersion.Fdmts_Keyword
{
    /// <summary>
    /// 将引用类型根据引用传递，而不是值或特定作用域。
    /// https://learn.microsoft.com/zh-cn/dotnet/csharp/language-reference/keywords/ref
    /// </summary>
    internal class refSyntax
    {
        [Test]
        public void UseRef_按引用传递参数示例1()
        {
            void Method(ref int refArgument)
            {
                refArgument = refArgument + 44;
            }
            //传递到 ref 或 in 形参的实参必须先经过初始化，然后才能传递。 该要求与 out 形参不同，在传递之前，不需要显式初始化该形参的实参。
            int number = 1;
            Method(ref number);
            Console.WriteLine(number);
            // Output: 45
        }
        private class Product
        {
            public Product(string name, int newID)
            {
                ItemName = name;
                ItemID = newID;
            }
            public string ItemName { get; set; }
            public int ItemID { get; set; }
        }
        private static void ChangeByReference(ref Product itemRef)
        {
            // Change the address that is stored in the itemRef parameter.
            itemRef = new Product("Stapler", 99999);

            // You can change the value of one of the properties of
            // itemRef. The change happens to item in Main as well.
            itemRef.ItemID = 12345;
        }
        [Test]
        public void UseRef_按引用传递参数示例2()
        {
            // Declare an instance of Product and display its initial values.
            Product item = new Product("Fasteners", 54321);
            System.Console.WriteLine("Original values in Main.  Name: {0}, ID: {1}\n",
                item.ItemName, item.ItemID);

            // Pass the product instance to ChangeByReference.
            ChangeByReference(ref item);
            System.Console.WriteLine("Back in Main.  Name: {0}, ID: {1}\n",
                item.ItemName, item.ItemID);
        }
        //引用返回值示例
        private static ref int Find(int[,] matrix, Func<int, bool> predicate)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
                for (int j = 0; j < matrix.GetLength(1); j++)
                    if (predicate(matrix[i, j]))
                        return ref matrix[i, j];
            throw new InvalidOperationException("Not found");
        }
        private class Book
        {
            public string Author;
            public string Title;
        }
        private class BookCollection
        {
            private Book[] books = { new Book { Title = "Call of the Wild, The", Author = "Jack London" },
                        new Book { Title = "Tale of Two Cities, A", Author = "Charles Dickens" }
                       };
            private Book nobook = null;

            public ref Book GetBookByTitle(string title)
            {
                for (int ctr = 0; ctr < books.Length; ctr++)
                {
                    if (title == books[ctr].Title)
                        return ref books[ctr];
                }
                return ref nobook;
            }

            public void ListBooks()
            {
                foreach (var book in books)
                {
                    Console.WriteLine($"{book.Title}, by {book.Author}");
                }
                Console.WriteLine();
            }
        }
        [Test]
        public void UseRef_引用返回值示例()
        {
            //调用方将 GetBookByTitle 方法所返回的值存储为 ref 局部变量时，调用方对返回值所做的更改将反映在 BookCollection 对象中，如下例所示。
            var bc = new BookCollection();
            bc.ListBooks();

            ref var book = ref bc.GetBookByTitle("Call of the Wild, The");
            if (book != null)
                book = new Book { Title = "Republic, The", Author = "Plato" };
            bc.ListBooks();
            // The example displays the following output:
            //       Call of the Wild, The, by Jack London
            //       Tale of Two Cities, A, by Charles Dickens
            //
            //       Republic, The, by Plato
            //       Tale of Two Cities, A, by Charles Dickens
        }
        [Test]
        public void UseRef_CS8171编译错误()
        {
            {//error
                //int a = 123;
                //ref int x = ref a;
                //var y = ref x;
            }
            {//To correct this error
                int a = 123;
                ref int x = ref a;
                var y = x;
            }
        }
        private class MyClassCS0206Error
        {
            public static int P
            {
                get
                {
                    return 0;
                }
                set
                {
                }
            }
            public static void MyMethod(ref int i)
            // public static void MyMethod(int i)  
            {
            }
        }
        private class MyClassCS0206ToCorrect
        {
            public static int P;
            public static void MyMethod(ref int i)
            // public static void MyMethod(int i)  
            {
            }
        }
        [Test]
        public void UseRef_CS0206编译错误()
        {
            {
                //MyClassCS0206Error.MyMethod(ref MyClassCS0206Error.P);   // CS0206  
                // try the following line instead  
                // MyMethod(P);   // CS0206  
            }
            {
                MyClassCS0206ToCorrect.MyMethod(ref MyClassCS0206ToCorrect.P);   // CS0206  
                // try the following line instead  
                // MyMethod(P);   // CS0206  
            }
        }
    }
}
