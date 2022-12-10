using System.Text.RegularExpressions;

namespace MotherCompiler.Tokenize {

    public class TokenizePhase {

        public TokenModel[] Tokenize(string source) {
            // 去除多余空格和换行
            source = Regex.Replace(source, @"[\s]+", " ");
            System.Console.WriteLine(source);
            return new TokenModel[0];
        }

    }
}