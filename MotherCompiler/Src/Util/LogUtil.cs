using System.Collections.Generic;

namespace LingLang.MotherCompiler {

    public static class LogUtil {

        public static void LogTokenBuffer(List<TokenModel> tokenBuffer) {
            for (int i = 0; i < tokenBuffer.Count; i += 1) {
                TokenModel token = tokenBuffer[i];
                System.Console.WriteLine(token.value);
            }
        }

    }
}