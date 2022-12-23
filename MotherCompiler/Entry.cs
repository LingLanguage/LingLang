using System;
using System.IO;

namespace LingLang.MotherCompiler {

    public class Entry {

        public static void Main(string[] args) {

            string packageDir = Path.Combine(Environment.CurrentDirectory, "Assets");

            // LLVM DIR
            var info = new DirectoryInfo(Environment.CurrentDirectory);
            var root = info.Parent.FullName;
            var llvmDir = Path.Combine(root, "LLVMIR", "src");

            // Compile
            CompileOption option = CompileOption.Default;
            Compiler compiler = new Compiler(option);
            compiler.Compile(packageDir);

        }

    }
}