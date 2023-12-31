namespace CsLangVersion.Fdmts_CollectionType
{
	internal class stringArray
	{
		//【Ref】https://learn.microsoft.com/en-us/dotnet/csharp/how-to/concatenate-multiple-strings
		[Test]
		public void Concat方法()
		{
			string[] words = { "The", "quick", "brown", "fox", "jumps", "over", "the", "lazy", "dog." };

			var unreadablePhrase = string.Concat(words);
			System.Console.WriteLine(unreadablePhrase);

			var readablePhrase = string.Join(" ", words);
			System.Console.WriteLine(readablePhrase);
		}
		//【Ref】https://learn.microsoft.com/en-us/dotnet/csharp/how-to/concatenate-multiple-strings
		[Test]
		public void 官方示例()
		{

		}
	}
}
