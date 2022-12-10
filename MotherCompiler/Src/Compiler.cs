using System.Collections.Generic;
using MotherCompiler.Facades;
using MotherCompiler.PackageLoader;
using MotherCompiler.Tokenize;

namespace MotherCompiler {

    public class Compiler {

        Context ctx;

        PackageLoaderPhase packageLoaderPhase;
        TokenizePhase tokenizePhase;

        public Compiler() {
            this.ctx = new Context();
            this.packageLoaderPhase = new PackageLoaderPhase();
            this.tokenizePhase = new TokenizePhase();
        }

        public void Compile(string packageDir) {
            List<TokenModel> tokenBuffer = new List<TokenModel>(65535);
            string[] sources = packageLoaderPhase.Load(packageDir);
            for (int i = 0; i < sources.Length; i += 1) {
                string source = sources[i];
                CompileOneFile(source, tokenBuffer);
            }

            for (int i = 0; i < tokenBuffer.Count; i += 1) {
                TokenModel token = tokenBuffer[i];
                System.Console.WriteLine(token.value);
            }

        }

        public void CompileOneFile(string source, List<TokenModel> tokenBuffer) {
            tokenizePhase.Tokenize(source, tokenBuffer);
        }

    }

}