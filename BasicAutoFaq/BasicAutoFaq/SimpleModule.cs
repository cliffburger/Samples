using Autofac;

namespace BasicAutoFaq
{
	public class SimpleModule:Module
	{
		protected override void Load(ContainerBuilder builder)
		{
			builder.RegisterType<ComplementaryRepo>().As<ICommentRepo>().SingleInstance();
			// Default would be instance per request.
			builder.RegisterType<ObjectWhoseConstructorTakesUnregisteredParameters>();
			base.Load(builder);
		}
	}
}
