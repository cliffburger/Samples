namespace BasicAutoFaq
{
	public class OffensiveRepo: ICommentRepo
	{
		public string[] Retrieve()
		{
			return new string[] { "cur", "cat", "r�vhul", "batch file user", "udg�r" };
		}
	}
}