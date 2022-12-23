using System.Collections.Generic;
using LingLang.MotherCompiler.Facades;
using LingLang.MotherCompiler.PackageLoader;
using LingLang.MotherCompiler.Tokenize;

namespace LingLang.MotherCompiler {

    public class Compiler {

        Context ctx;

        PackageLoaderPhase packageLoaderPhase;
        TokenizePhase tokenizePhase;

        public Compiler(CompileOption option) {

            this.ctx = new Context(option.tokenBufferOriginSize);

            this.packageLoaderPhase = new PackageLoaderPhase();
            this.tokenizePhase = new TokenizePhase();

        }

        public void Compile(string packageDir) {
            string[] sources = packageLoaderPhase.Load(packageDir);
            for (int i = 0; i < sources.Length; i += 1) {
                string source = sources[i];
                CompileOneFile(source, ctx.TokenRepo);
            }
        }

        public void CompileOneFile(string source, TokenRepo tokenRepo) {
            tokenizePhase.Tokenize(source, tokenRepo);
        }

    }

}