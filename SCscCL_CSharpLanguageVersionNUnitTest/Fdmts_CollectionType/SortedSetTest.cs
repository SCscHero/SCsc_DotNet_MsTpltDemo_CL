using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace CsLangVersion.Fdmts_CollectionType
{
	//【官方解读】表示按排序顺序维护的对象集合。
	//【Ref】https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.sortedset-1?view=net-8.0
	/// <summary>
	/// A SortedSet<T> object maintains a sorted order without affecting performance as elements are inserted and deleted. Duplicate elements are not allowed. Changing the sort values of existing items is not supported and may lead to unexpected behavior.
	/// For a thread safe alternative to SortedSet<T>, see ImmutableSortedSet<T>
	/// </summary>
	internal class SortedSetTest
	{
		[Test]
		public void 官方文档示例()
		{
			try
			{
				// Get a list of the files to use for the sorted set.
				IEnumerable<string> files1 =
						Directory.EnumerateFiles(@"\\archives\2007\media",
						"*", SearchOption.AllDirectories);

				// Create a sorted set using the ByFileExtension comparer.
				var mediaFiles1 = new SortedSet<string>(new ByFileExtension());

				// Note that there is a SortedSet constructor that takes an IEnumerable,
				// but to remove the path information they must be added individually.
				foreach (string f in files1)
				{
					mediaFiles1.Add(f.Substring(f.LastIndexOf(@"\") + 1));
				}

				// Remove elements that have non-media extensions.
				// See the 'IsDoc' method.
				Console.WriteLine("Remove docs from the set...");
				Console.WriteLine($"\tCount before: {mediaFiles1.Count}");
				mediaFiles1.RemoveWhere(IsDoc);
				Console.WriteLine($"\tCount after: {mediaFiles1.Count}");

				Console.WriteLine();

				// List all the avi files.
				SortedSet<string> aviFiles = mediaFiles1.GetViewBetween("avi", "avj");

				Console.WriteLine("AVI files:");
				foreach (string avi in aviFiles)
				{
					Console.WriteLine($"\t{avi}");
				}

				Console.WriteLine();

				// Create another sorted set.
				IEnumerable<string> files2 =
						Directory.EnumerateFiles(@"\\archives\2008\media",
								"*", SearchOption.AllDirectories);

				var mediaFiles2 = new SortedSet<string>(new ByFileExtension());

				foreach (string f in files2)
				{
					mediaFiles2.Add(f.Substring(f.LastIndexOf(@"\") + 1));
				}

				// Remove elements in mediaFiles1 that are also in mediaFiles2.
				Console.WriteLine("Remove duplicates (of mediaFiles2) from the set...");
				Console.WriteLine($"\tCount before: {mediaFiles1.Count}");
				mediaFiles1.ExceptWith(mediaFiles2);
				Console.WriteLine($"\tCount after: {mediaFiles1.Count}");

				Console.WriteLine();

				Console.WriteLine("List of mediaFiles1:");
				foreach (string f in mediaFiles1)
				{
					Console.WriteLine($"\t{f}");
				}

				// Create a set of the sets.
				IEqualityComparer<SortedSet<string>> comparer =
						SortedSet<string>.CreateSetComparer();

				var allMedia = new HashSet<SortedSet<string>>(comparer);
				allMedia.Add(mediaFiles1);
				allMedia.Add(mediaFiles2);
			}
			catch (IOException ioEx)
			{
				Console.WriteLine(ioEx.Message);
			}

			catch (UnauthorizedAccessException AuthEx)
			{
				Console.WriteLine(AuthEx.Message);
			}
		}

		// Defines a predicate delegate to use
		// for the SortedSet.RemoveWhere method.
		private static bool IsDoc(string s)
		{
			s = s.ToLower();
			return (s.EndsWith(".txt") ||
					s.EndsWith(".xls") ||
					s.EndsWith(".xlsx") ||
					s.EndsWith(".pdf") ||
					s.EndsWith(".doc") ||
					s.EndsWith(".docx"));
		}
	}

	// Defines a comparer to create a sorted set
	// that is sorted by the file extensions.
	public class ByFileExtension : IComparer<string>
	{
		string xExt, yExt;

		CaseInsensitiveComparer caseiComp = new CaseInsensitiveComparer();

		public int Compare(string x, string y)
		{
			// Parse the extension from the file name.
			xExt = x.Substring(x.LastIndexOf(".") + 1);
			yExt = y.Substring(y.LastIndexOf(".") + 1);

			// Compare the file extensions.
			int vExt = caseiComp.Compare(xExt, yExt);
			if (vExt != 0)
			{
				return vExt;
			}
			else
			{
				// The extension is the same,
				// so compare the filenames.
				return caseiComp.Compare(x, y);
			}
		}
	}
}
