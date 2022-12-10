using System;
using System.IO;

namespace MotherCompiler {

    public class Entry {

        public static void Main(string[] args) {

            string dir = Path.Combine(Environment.CurrentDirectory, "Assets");
            string file = Path.Combine(dir, "SampleCode.ling");
            string code = File.ReadAllText(file);

            Compiler compiler = new Compiler();
            compiler.Compile(code);

        }

    }
}