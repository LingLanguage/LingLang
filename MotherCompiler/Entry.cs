using System;
using System.IO;

namespace MotherCompiler {

    public class Entry {

        public static void Main(string[] args) {

            string packageDir = Path.Combine(Environment.CurrentDirectory, "Assets");

            CompileOption option = CompileOption.Default;
            Compiler compiler = new Compiler(option);
            compiler.Compile(packageDir);

        }

    }
}