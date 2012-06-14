namespace BasicAutoFaq
{
	public interface ICommentRepo
	{
		string[] Retrieve();
	}

	public class OffensiveRepo: ICommentRepo
	{
		public string[] Retrieve()
		{
			return new string[] { "cur", "cat", "røvhul", "batch file user", "udgør" };
		}
	}

	public class ComplementaryRepo : ICommentRepo
	{
		public string[] Retrieve()
		{
			return new string[] { "sweet", "dog", "powershell power user", "leader" };
		}
	}
}
