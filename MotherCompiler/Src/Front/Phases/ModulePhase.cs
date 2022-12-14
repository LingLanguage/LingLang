using System.IO;

namespace LingLang.MotherCompiler.PackageLoader {

    public class ModulePhase {

        public string[] Load(string packageDir) {
            string[] files = Directory.GetFiles(packageDir, "*.ling");
            string[] sources = new string[files.Length];
            for (int i = 0; i < files.Length; i += 1) {
                string file = files[i];
                sources[i] = File.ReadAllText(file);
            }
            return sources;
        }

    }

}