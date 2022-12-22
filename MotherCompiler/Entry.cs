using System;
using System.IO;

namespace LingLang.MotherCompiler {

    public class Entry {

        public static void Main(string[] args) {

            string packageDir = Path.Combine(Environment.CurrentDirectory, "Assets");

            CompileOption option = CompileOption.Default;
            Compiler compiler = new Compiler(option);
            compiler.Compile(packageDir);

        }

        public class Cat {
            public int age;
        }

        public static void Input(in Cat cat) {
            cat.age = 10; // error, when set
            System.Console.WriteLine(cat.age); // allowed, when get
        }

    }
}