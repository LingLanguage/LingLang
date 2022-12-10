using MotherCompiler.Tokenize;

namespace MotherCompiler {

    public class Compiler {

        TokenizePhase tokenizePhase;

        public Compiler() {
            this.tokenizePhase = new TokenizePhase();
        }

        public void Compile(string source) {
            var tokens = tokenizePhase.Tokenize(source);
            for (int i = 0; i < tokens.Length; i += 1) {
                var token = tokens[i];
                System.Console.WriteLine(token.value);
            }
        }

    }

}