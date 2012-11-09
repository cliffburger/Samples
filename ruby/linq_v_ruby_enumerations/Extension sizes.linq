<Query Kind="Program">
  <Reference>&lt;RuntimeDirectory&gt;\System.Web.dll</Reference>
  <Namespace>System.Web</Namespace>
</Query>

void Main()
{
	DirectoryInfo folder = new DirectoryInfo(@"c:\source\3\eproject\root");
	var files = folder.EnumerateFiles("*", SearchOption.TopDirectoryOnly);
	
	(from f in files
	select new {Ext = f.Extension, Length =f.Length}
	group f by f.extension into files
	select files.extension, files.Lenght
	)
	.Dump();
}
 
