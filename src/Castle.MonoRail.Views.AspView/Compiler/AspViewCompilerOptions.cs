// Copyright 2004-2010 Castle Project - http://www.castleproject.org/
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// 
//     http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

namespace Castle.MonoRail.Views.AspView.Compiler
{
	using System;
	using System.Collections.Generic;

	public class AspViewCompilerOptions
	{
		#region members

		private string temporarySourceFilesDirectory = "temporarySourceFiles";
		readonly List<ReferencedAssembly> assembliesToReference = new List<ReferencedAssembly>();
		readonly IDictionary<Type, Type> providers = new Dictionary<Type, Type>();

		static readonly ReferencedAssembly[] defaultAssemblies = new[]
			{
				new ReferencedAssembly("System.dll", ReferencedAssembly.AssemblySource.GlobalAssemblyCache),
				new ReferencedAssembly("Castle.Core.dll", ReferencedAssembly.AssemblySource.BinDirectory),
				new ReferencedAssembly("Castle.MonoRail.Views.AspView.dll", ReferencedAssembly.AssemblySource.BinDirectory),
				new ReferencedAssembly("Castle.MonoRail.Framework.dll", ReferencedAssembly.AssemblySource.BinDirectory)
			};
		#endregion

		#region c'tor
		public AspViewCompilerOptions()
		{
			AddReferences(defaultAssemblies);
		}

		public AspViewCompilerOptions(
			bool? debug,
			bool? autoRecompilation,
			bool? allowPartiallyTrustedCallers,
			string temporarySourceFilesDirectory,
			bool? keepTemporarySourceFiles,
			IEnumerable<ReferencedAssembly> references,
			IDictionary<Type, Type> providers)
			: this()
		{
			if (debug.HasValue) this.Debug = debug.Value;
			if (autoRecompilation.HasValue) this.AutoRecompilation = autoRecompilation.Value;
			if (allowPartiallyTrustedCallers.HasValue) this.AllowPartiallyTrustedCallers = allowPartiallyTrustedCallers.Value;
			if (keepTemporarySourceFiles.HasValue) this.KeepTemporarySourceFiles = keepTemporarySourceFiles.Value;
			if (temporarySourceFilesDirectory != null) this.temporarySourceFilesDirectory = temporarySourceFilesDirectory;

			AddReferences(references);
			if (providers != null)
				foreach (var service in providers.Keys)
					this.providers[service] = providers[service];
		}

		#endregion

		#region properties

		/// <summary>
		/// True to emit debug symbols
		/// </summary>
		public bool Debug { get; set; }

		/// <summary>
		/// True if the generated concrete classes should be kept on disk
		/// </summary>
		public bool KeepTemporarySourceFiles { get; set; }

		/// <summary>
		/// if true, the engine will recompile the view if the view sources are changed
		/// </summary>
		public bool AutoRecompilation { get; set; }

		/// <summary>
		/// if true, the engine will compile the views with AllowPartiallyTrustedCallers
		/// </summary>
		public bool AllowPartiallyTrustedCallers { get; set; }

		/// <summary>
		/// Location of the generated concrete classes, if saved.
		/// Important: the user who runs the application must have Modify permissions on this path.
		/// </summary>
		public string TemporarySourceFilesDirectory
		{
			get { return temporarySourceFilesDirectory; }
			set { temporarySourceFilesDirectory = value; }
		}
		/// <summary>
		/// Gets list of assemblies that'll be referenced during the compile process by CompiledViews.dll
		/// </summary>
		public ReferencedAssembly[] References
		{
			get { return assembliesToReference.ToArray(); }
		}
		/// <summary>
		/// Gets list of custom providers, implementing IPreCompilationStepsProvider and IMarkupTransformersProvider
		/// </summary>
		public IDictionary<Type, Type> CustomProviders
		{
			get { return providers; }
		}
		#endregion

		public void AddReferences(IEnumerable<ReferencedAssembly> referencesToAdd)
		{
			assembliesToReference.AddRange(referencesToAdd);
		}
	}
}
