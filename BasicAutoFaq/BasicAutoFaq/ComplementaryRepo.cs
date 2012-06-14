namespace BasicAutoFaq
{
	public class ComplementaryRepo : ICommentRepo
	{
		public string[] Retrieve()
		{
			return new string[] { "sweet", "dog", "powershell power user", "leader" };
		}
	}
}