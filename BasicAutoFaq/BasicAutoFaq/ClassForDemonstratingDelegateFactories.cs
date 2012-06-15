using System;
using System.IO;

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
            Print(Console.Out);		
		}

        public void Print(TextWriter writer)
        {
            foreach (string comment in _commentRepo.Retrieve())
            {
                writer.WriteLine("{0} {1} ", _prefix, comment);
            }

        }
	}
}
