using System;

namespace BasicAutoFaq
{
	public class ClassForDemonstratingDelegateFactories
	{
		private readonly ICommentRepo _commentRepo;
		private readonly string _prefix;

		public ClassForDemonstratingDelegateFactories(ICommentRepo commentRepo, string prefix)
		{
			_commentRepo = commentRepo;
			_prefix = prefix;
		}

		public void Print()
		{
			foreach(string comment in _commentRepo.Retrieve())
			{
				Console.WriteLine("{0} {1} " , _prefix, comment);	
			}
			
		}
	}
}
