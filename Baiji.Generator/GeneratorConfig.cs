using System;
using System.Collections.Generic;
using System.IO;
using CTripOSS.Baiji.Helper;

namespace CTripOSS.Baiji.Generator
{
    public class GeneratorConfig
    {
        /// <summary>
        /// Input base URI to load IDL files.
        /// </summary>
        public Uri InputBase
        {
            get;
            private set;
        }

        /// <summary>
        /// The output folder which contain the generated sources.
        /// </summary>
        public DirectoryInfo OutputFolder
        {
            get;
            private set;
        }

        /// <summary>
        /// If not-null, overrides the namespace definitions in the IDL files.
        /// </summary>
        public string OverrideNamespace
        {
            get;
            private set;
        }

        /// <summary>
        /// If no namespace was set in the IDL file, fall back to this namespace.
        /// </summary>
        public string DefaultNamespace
        {
            get;
            private set;
        }

        public ISet<string> GeneratorTweaks
        {
            get;
            set;
        }

        /// <summary>
        /// If true, generate code for all included IDLs instead of just referring to them.
        /// </summary>
        public bool GenerateIncludedCode
        {
            get;
            private set;
        }

        /// <summary>
        /// The template to use for generating source code.
        /// </summary>
        public string CodeFlavor
        {
            get;
            private set;
        }

        private GeneratorConfig(Uri inputBase,
            DirectoryInfo outputFolder,
            string overrideNamespace,
            string defaultNamespace,
            ISet<string> generatorTweaks,
            bool generateIncludedCode,
            string codeFlavor)
        {
            InputBase = inputBase;
            OutputFolder = outputFolder;
            OverrideNamespace = overrideNamespace;
            DefaultNamespace = defaultNamespace;
            GeneratorTweaks = generatorTweaks;
            GenerateIncludedCode = generateIncludedCode;
            CodeFlavor = codeFlavor;
        }

        public bool ContainsTweak(string tweak)
        {
            return GeneratorTweaks.Contains(tweak);
        }

        /// <summary>
        /// The template to use for generating source code
        /// </summary>
        public class Builder
        {
            private Uri _inputBase;
            private DirectoryInfo _outputFolder;
            private string _overrideNamespace;
            private string _defaultNamespace;
            private readonly ISet<string> _generatorTweaks = new HashSet<string>();
            private bool _generateIncludedCode;
            private string _codeFlavor;

            public GeneratorConfig Build()
            {
                Enforce.IsNotNull(_outputFolder, "output folder must be set!");
                Enforce.IsNotNull(_inputBase, "input base uri must be set to load includes!");
                Enforce.IsNotNull(_codeFlavor, "no code flavor selected!");

                return new GeneratorConfig(_inputBase,
                    _outputFolder,
                    _overrideNamespace,
                    _defaultNamespace,
                    _generatorTweaks,
                    _generateIncludedCode,
                    _codeFlavor);
            }

            public Builder InputBase(Uri inputBase)
            {
                _inputBase = inputBase;
                return this;
            }

            public Builder OutputFolder(DirectoryInfo outputFolder)
            {
                _outputFolder = outputFolder;
                return this;
            }

            public Builder OverrideNamespace(string overrideNamespace)
            {
                _overrideNamespace = overrideNamespace;
                return this;
            }

            public Builder DefaultNamespace(string defaultNamespace)
            {
                _defaultNamespace = defaultNamespace;
                return this;
            }

            public Builder AddTweak(string tweak)
            {
                _generatorTweaks.Add(tweak);
                return this;
            }

            public Builder GenerateIncludedCode(bool generateIncludedCode)
            {
                _generateIncludedCode = generateIncludedCode;
                return this;
            }

            public Builder CodeFlavor(string codeFlavor)
            {
                _codeFlavor = codeFlavor;
                return this;
            }
        }
    }
}