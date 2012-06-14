namespace BasicAutoFaq
{
	public class OffensiveRepo: ICommentRepo
	{
		public string[] Retrieve()
		{
			return new string[] { "cur", "cat", "røvhul", "batch file user", "udgør" };
		}
	}
}