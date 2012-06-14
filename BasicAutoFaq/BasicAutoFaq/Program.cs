using System;
using Autofac;

namespace BasicAutoFaq
{
	public class Program
	{
		private static IContainer _container;

		public static void Main(string[] args)
		{
			InitializeContainter();

			DemoBasicResolve();

			FactoryMethodDemo();

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
			var thisWasCreatedViaFactoryMethod = factory("You are not ");
			thisWasCreatedViaFactoryMethod.Print();
		}

		private static void InitializeContainter()
		{
			var builder = new ContainerBuilder();
			builder.RegisterModule(new SimpleModule());
			_container = builder.Build();
		}
	}
}
