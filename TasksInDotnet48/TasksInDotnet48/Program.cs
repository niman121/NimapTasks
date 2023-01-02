using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Schema;
using System.Data.Entity;

namespace TasksInDotnet48
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //NumberAddition numberAddition = new NumberAddition();
            //Console.WriteLine();
            //numberAddition = new NumberAddition(1, 2);//adding numbers in the constructors
            //Console.WriteLine();

            ////demonstration of method overloading
            //int twonumberAddition = numberAddition.AddNumbers(2, 4);
            //int threenumberAddition = numberAddition.AddNumbers(3, 4, 5);

            //Console.WriteLine($"Addition of two numbers is {twonumberAddition}");
            //Console.WriteLine($"Addition of three numbers is {threenumberAddition}");
            //Console.WriteLine();


            ////demonstration of method overriding 
            //Square square = new Square(2, 6);
            //int SquareArea = square.Area(5, 8);
            //Console.WriteLine($"Area of Square is {SquareArea}");
            //Thread.Sleep(2000);


            ////demonstration for primitive type and non-primitive type
            //Console.BackgroundColor = ConsoleColor.Green;
            //Console.ForegroundColor = ConsoleColor.Black;
            //Console.Clear();
            //string s1 = "Hello";
            //Console.WriteLine(s1);
            //DataTypeDecider dataTypeDecider = new DataTypeDecider();
            //dataTypeDecider.CheckDataType();


            ////demonstration for stopwatch
            //CustomStopWatch stopWatch = new CustomStopWatch();
            //stopWatch.Start();
            //Thread.Sleep(2000);
            //stopWatch.Stop();
            //Console.WriteLine(stopWatch.TotalElapsedTimeInSeconds());

            ////demonstration for stack
            //CustomStack stack = new CustomStack();
            //stack.Push(1);
            //stack.Push(2);
            //stack.Push(3);
            //stack.Push(4);
            //stack.Push(5);

            //Console.WriteLine(stack.Count());

            //var topItem = stack.Pop();
            //Console.WriteLine(topItem);
            //Console.WriteLine(stack.Count());


            //if(stack.Contains(4)) Console.WriteLine("yes 4 is there");

            //var currentStack = stack.Peek();
            //Console.WriteLine("Current Value in the stack is "+currentStack);

            //Console.WriteLine();

            //stack.GetAllStacks();
            //stack.Clear();
            //Console.WriteLine($"stack cleared");
            //Console.WriteLine();

            //stack.GetAllStacks();


            //working with strings 
            StringManipulation stringManipulation = new StringManipulation();
            //Console.WriteLine("write numbers separating with - ");
            //var Numbers = Console.ReadLine();
            //if(!String.IsNullOrWhiteSpace(Numbers))
            //{
            //    var num = Numbers.Split('-').Select(q => Convert.ToInt32(q)).ToArray();
            //    var IsConsecutive = stringManipulation.ConsecutiveNumberChecker(num);
            //    var IsDuplicate = stringManipulation.DuplicateNumberChecker(num);
            //    if (IsDuplicate) Console.WriteLine("Duplicate");
            //    else Console.WriteLine("Not Duplicate");
            //    if (IsConsecutive) Console.WriteLine("Consecutive");
            //    else Console.WriteLine("Not Consecutive");
            //}
            //string para = "this is a paragraph to give summary of paragraph which is really really long";

            //StringBuilder stringBuilder= new StringBuilder("Hi");
            //stringBuilder.Append(' ');
            //stringBuilder.Append(para);
            //stringBuilder.Remove(stringBuilder.Length - 11,6);
            //stringBuilder.Replace("long", "Bigggg");
            //stringBuilder.AppendLine();
            //stringBuilder.AppendLine("this is a new line");
            //stringBuilder.Insert(stringBuilder.Length - 6, "Inserted ");
            //Console.WriteLine(stringBuilder.ToString());    
            //int max = 25;
            //string summary = stringManipulation.ReturnSummary(para, max);
            //Console.WriteLine(summary);

            //Student s1= new Student();
            //Student s2= new Student();
            //s1.Id = 1;
            //s1.Name= "test";
            //s2 = s1;
            //Console.WriteLine("just assigned s2 to s1 : "+s2.Id + " " + s2.Name);
            //Console.WriteLine("s1 before values : "+s1.Id+" "+s1.Name);
            //s2.Id= 2;
            //s2.Name = "changed s2";
            //Console.WriteLine("s1 after assigned values : " + s1.Id + " " + s1.Name);

            //s1.Id= 3;
            //s1.Name= "changed s1";
            //Console.WriteLine("third change s2 values : " + s2.Id + " " + s2.Name);
            //Console.WriteLine("s1 values : " + s1.Id + " " + s1.Name);

            //var s3 = new Student
            //{
            //    Id = s1.Id,
            //    Name = s1.Name,
            //};
            //Console.WriteLine(s3.Id+" "+s3.Name);   
            //s3.Id= 4;
            //s3.Name = "ch";
            //Console.WriteLine(s1.Id+ " "+s1.Name);
            //Console.WriteLine(s3.Id + " " + s3.Name);

            //string str = "bhavesh";
            //Console.WriteLine(str.ToUpper());
            //Console.WriteLine(str);

            //Lambda Expression demonstration
            List<Student> students = new List<Student>()
            {
                new Student() { Id = 1, Name = "Salman", Marks = 58 },
                new Student() { Id = 2, Name = "Bhavesh", Marks = 98 },
                new Student() { Id = 3, Name = "Rahul", Marks = 60 },
                new Student() { Id = 4, Name = "Sandesh",Marks = 88 },
                new Student() { Id = 5, Name = "Mike",Marks = 40 }
            };

            //var GetAllStudents = students;
            //var GetStudentBasedOnNameCharacter = students.Where(s => s.Name.ToUpper().Contains("S"));
            //var GetStudentWithMoreThan50Marks = students.Where(s => s.Marks > 50).ToList();

            //foreach(var std in GetAllStudents)
            //{
            //    Console.WriteLine(std.Id+" " + " "+std.Name+" "+string.Intern(std.Name));
            //}
            //Console.WriteLine();
            //Console.WriteLine("Name that contains letter s");
            //foreach(var std in GetStudentBasedOnNameCharacter)
            //{
            //    Console.WriteLine(std.Id + " " + " " + std.Name);
            //}
            //Console.WriteLine();
            //Console.WriteLine("Student with more than 50 marks");
            //foreach (var std in GetStudentWithMoreThan50Marks)
            //{
            //    Console.WriteLine($"Id : {std.Id}\tName : {std.Name}\t Marks : {std.Marks}");
            //}

            ////Out and Ref demonstration 
            //int someNumber = 10;            
            //ManipulateSomeNumberByRef(ref someNumber);
            //Console.WriteLine(someNumber);
            //ManipulateSomeNumberByOut(out someNumber);
            //Console.WriteLine(someNumber);


            //IEnumerable vs IEnumerator Demonstration
            //IEnumerable<int> Marks = (IEnumerable<int>)students.OrderBy(Q => Q.Marks).Select(q => q.Marks);
            //IEnumerator<int> IEnumeratorMarks = Marks.GetEnumerator() ;
            //MarksBelow70IEnumerator(IEnumeratorMarks);


            ////TPL Demonstration
            //ParellelIterator();

            ////Asynchronous Method Example 
            //AsynchronousTaskMethod(students);
            //Console.WriteLine("main threa method");
            //Console.ReadLine();


            ////object(check type at compile time) vs dynamic(check type at runtime) vs var(becomes the variable used in expression)
            //dynamic name = "Salman";
            //name = 10;            
            //name++;
            //name = "aBBAS"+2;
            //var AnotherName = name + 1;
            //Console.WriteLine(name+" "+AnotherName);

            //Console.WriteLine("Started");
            //StudentDbContext context = new StudentDbContext();
            
            //var student = context.Students.Find(1);
            //var course = context.Courses.Find(1);
            //student.Courses.Add(course);
            //course.Students.Add(student);
            //context.SaveChanges();
            //Console.WriteLine("Done");
            //Console.ReadLine();

            ////N+1 problem and Eager Loading Demonstration 
            var context = new StudentDbContext();
            //var student = context.Students.Single(q => q.Id == 1);//1 time query
            //foreach (var course in student.Courses)// for each course EF will send query to database// N time query which will result in N+1 query
            //{
            //    Console.WriteLine(course.Name);
            //}

            ////to prevent N+1
            //var Course = context.Courses.Include(q => q.Students).Single(q => q.Id == 1);
            //foreach (var std in Course.Students)
            //{
            //    Console.WriteLine(std.Name);
            //}

        }

        ////out variable is passed by reference only and value has to be initialized in the method and passed variable's value is changed
        ////according to method 
        //static void ManipulateSomeNumberByOut(out int someNumber)
        //{
        //    someNumber = 0;
        //    someNumber = someNumber + 20;
        //}

        ////ref variable is passed by reference and value also gets passed from caller and changes passed value without initializing 
        //static void ManipulateSomeNumberByRef(ref int someNumber)
        //{            
        //    someNumber = someNumber + 40;
        //}


        ////IEnumerable vs IEnumerator Demo
        //static void MarksBelow70(IEnumerable<int> mark)
        //{
        //    foreach(int m in mark)
        //    {
        //        if (m > 70)
        //        {
        //            Console.WriteLine();
        //            MarksAbove70(mark);
        //        }
        //        Console.WriteLine(m);                
        //    }
        //}

        ////IEnumerable vs IEnumerator Demo
        //static void MarksAbove70(IEnumerable<int> mark)
        //{
        //    foreach(int m in mark)
        //    {
        //        Console.WriteLine(m);
        //    }
        //}
        
        ////IEnumerator vs IEnumerable
        //static void MarksBelow70IEnumerator(IEnumerator<int> mark)
        //{
        //    while (mark.MoveNext())
        //    {
        //        if(mark.Current < 70) Console.WriteLine(mark.Current);
        //        if (mark.Current > 70) MarksAbove70IEnumerator(mark);
                
        //    }
        //}

        ////IEnumerator vs IEnumerable 
        //private static void MarksAbove70IEnumerator(IEnumerator<int> mark)
        //{
        //    do// used do-while to prevent mark.current on method change due mark.MoveNext()
        //    {
        //        Console.WriteLine(mark.Current);
        //    }
        //    while (mark.MoveNext());            
        //}


        //TPL Iterator example
        static void ParellelIterator()
        {          
            NormalLoop();
            Thread.Sleep(3000);
            ParallelLoop();
        }

        static void ParallelLoop()
        {
            CustomStopwatch Watch = new CustomStopwatch();
            Stopwatch mainWatch = new Stopwatch();

            mainWatch.Start();
            Watch.Start();

            Parallel.For(1, 15000, num =>
            {
               Console.Write(num + " ");
            });

            Watch.Stop();
            mainWatch.Stop();

            Console.WriteLine("time : " + Watch.TotalElapsedTimeInMiliSeconds());
            Console.WriteLine("Main time : " + mainWatch.ElapsedMilliseconds);
            Console.WriteLine();            
        }


        static void NormalLoop()
        {
            CustomStopwatch watch = new CustomStopwatch();
            Stopwatch mainwatch = new Stopwatch();
            watch.Start();
            mainwatch.Start();

            for (int i = 1; i < 15000; i++)
            {
                Console.Write(i + " ");
            }

            watch.Stop();
            Console.WriteLine("time : " + watch.TotalElapsedTimeInMiliSeconds());
            mainwatch.Stop();
            Console.WriteLine("Main time : " + mainwatch.ElapsedMilliseconds);

        }

        static async Task AsynchronousTaskMethod(List<Student> students)
        {
            Console.WriteLine("Getting Marks");
            var marks = await Task.Run( () => GetMarks(students));
            Console.WriteLine("Getting Names");
            var names =  await Task.Run( () =>  GetNames(students));
            Console.WriteLine("Completed!!");
        }

        public static List<int> GetMarks(List<Student> students)
        {
            var Marks = students.Select(q => q.Marks);
            Console.WriteLine("Marks thread");
            Thread.Sleep(4000);
            return Marks.ToList();
        }

        public static List<string> GetNames(List<Student> students)
        {
            var Names = students.Select(q => q.Name);
            Console.WriteLine("Names thread");
            Thread.Sleep(4000);
            return Names.ToList();

        }
    
    
    
    }
}
