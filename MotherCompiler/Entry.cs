using System;
using System.IO;
using System.Diagnostics;

namespace LingLang.MotherCompiler {

    public class Entry {

        public static void Main(string[] args) {

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            string packageDir = Path.Combine(Environment.CurrentDirectory, "Assets");

            // LLVM DIR
            var info = new DirectoryInfo(Environment.CurrentDirectory);
            var root = info.Parent.FullName;
            var llvmDir = Path.Combine(root, "LLVMIR", "src");

            // Compile
            CompileOption option = CompileOption.Default;
            Compiler compiler = new Compiler(option);
            compiler.Compile(packageDir);

            stopwatch.Stop();
            Console.WriteLine("Compile Time: " + stopwatch.ElapsedMilliseconds + "ms");

        }

    }
}