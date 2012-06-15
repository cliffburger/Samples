using System;
using System.IO;
using System.Diagnostics;
using Autofac;

namespace BasicAutoFaq
{
	public class Program
	{
		private static IContainer _container;
        const int iterations = 100000;
		public static void Main(string[] args)
		{
			InitializeContainter();

			DemoBasicResolve();

			FactoryMethodDemo();

            Console.WriteLine("Testing performance of resolution vs new");

            Console.WriteLine("NEW");
            ExecuteWithNew(args);

            Console.WriteLine("RESOLVE");
            ExecuteWithResolve(args);

            Console.WriteLine("NEW");
            ExecuteWithNew(args);
            

            Console.ReadLine();
        }

		private static void DemoBasicResolve()
		{
			var comments = _container.Resolve<ICommentRepo>();
			foreach(string comment in comments.Retrieve())
			{
				Console.WriteLine("Your are {0}", comment);
			}
		}

		private static void FactoryMethodDemo()
		{
			Func<string, ClassForDemonstratingDelegateFactories> factory;
			factory = _container.Resolve<Func<string, ClassForDemonstratingDelegateFactories>>();
			ClassForDemonstratingDelegateFactories thisWasCreatedViaFactoryMethod = factory("You are not ");
			thisWasCreatedViaFactoryMethod.Print();
		}

        private static void ExecuteWithResolve(string[] args)
        {
            Stopwatch watch = new Stopwatch();
            
            using (var writer = new StreamWriter(new MemoryStream()))
            {
                watch.Start();
                for (int i = 0; i < iterations; i++)
                {
                    Func<string, ClassForDemonstratingDelegateFactories> factory = _container.Resolve<Func<string, ClassForDemonstratingDelegateFactories>>();
                    factory("You are ").Print(writer);
                }
            }
            Console.WriteLine("Execution time {0}. Iterations per ms {1}", watch.Elapsed, watch.Elapsed.Milliseconds == 0 ? 0 : iterations / watch.Elapsed.Milliseconds);

        }

        private static void ExecuteWithNew(string[] args)
        {
            Stopwatch watch = new Stopwatch();
            ICommentRepo repo = new ComplementaryRepo();
            using (var writer = new StreamWriter(new MemoryStream()))
            {
                watch.Start();
                for (int i = 0; i < iterations; i++)
                {
                    // Note that this would be a singleton in Autofac. As singletons are difficult and dangerous without autfac, I'll create one each time.
                    //ICommentRepo repo = new ComplementaryRepo();
                    new ClassForDemonstratingDelegateFactories(repo, "Whatever ").Print(writer);

                }
            }
            Console.WriteLine("Execution time {0}. Iterations per ms {1}", watch.Elapsed, watch.Elapsed.Milliseconds == 0 ? 0 : iterations / watch.Elapsed.Milliseconds);

        }

		private static void InitializeContainter()
		{
			var builder = new ContainerBuilder();
			builder.RegisterModule(new SimpleModule());
			_container = builder.Build();
		}
	}
}
