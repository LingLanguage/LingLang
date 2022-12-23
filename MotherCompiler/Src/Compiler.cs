using System.Collections.Generic;
using LingLang.MotherCompiler.Facades;
using LingLang.MotherCompiler.PackageLoader;
using LingLang.MotherCompiler.Tokenize;

namespace LingLang.MotherCompiler {

    public class Compiler {

        Context ctx;

        // ==== Front ====
        ModulePhase modulePhase;
        LexPhase lexPhase;

        // ==== Meddium ====

        // ==== Back ====

        public Compiler(CompileOption option) {

            this.ctx = new Context();

            this.modulePhase = new ModulePhase();
            this.lexPhase = new LexPhase();

            ctx.Inject(option);

            lexPhase.Inject(ctx);

        }

        public void Compile(string packageDir) {
            string[] sources = modulePhase.Load(packageDir);
            for (int i = 0; i < sources.Length; i += 1) {
                string source = sources[i];
                CompileOneFile(source);
            }
        }

        public void CompileOneFile(string source) {
            lexPhase.Analyze(source);
        }

    }

}