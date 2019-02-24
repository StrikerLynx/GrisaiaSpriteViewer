﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Grisaia.Asmodean {
	/// <summary>
	///  A copy of a <see cref="Kifint"/> for used in outputting a list to json.
	/// </summary>
	public sealed class KifintList {
		#region Fields

		/// <summary>
		///  Gets the file path to the KIFINT archive.
		/// </summary>
		[JsonProperty("file_path")]
		public string FilePath { get; private set; }
		/// <summary>
		///  Gets the ordered list of entries in the KIFINT archive.
		/// </summary>
		[JsonProperty("entries")]
		public IReadOnlyList<string> Entries { get; private set; }

		#endregion

		#region Constructors

		/// <summary>
		///  Used for consutrction during deserialization with <see cref="Newtonsoft.Json"/>.
		/// </summary>
		public KifintList() { }
		/// <summary>
		///  Constructs the KIFINT archive list and sorts the entry file names.
		/// </summary>
		/// <param name="kifint">The associated KIFINT archive.</param>
		public KifintList(Kifint kifint) {
			StringComparer comparer = StringComparer.InvariantCultureIgnoreCase;
			FilePath = kifint.FilePath;
			Entries = kifint.Entries.Values.Select(e => e.FileName)
												  .OrderBy(e => e, comparer)
												  .ToList()
												  .AsReadOnly();
		}

		#endregion
	}
}
