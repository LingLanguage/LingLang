using System;
using System.IO;

namespace MotherCompiler {

    public class Entry {

        public static void Main(string[] args) {

            string packageDir = Path.Combine(Environment.CurrentDirectory, "Assets");

            Compiler compiler = new Compiler();
            compiler.Compile(packageDir);

        }

    }
}