using System.Collections.Generic;

namespace LingLang.MotherCompiler {

    public static class LogUtil {

        public static void LogTokenBuffer(TokenModel[] tokenBufferArray) {
            for (int i = 0; i < tokenBufferArray.Length; i += 1) {
                TokenModel token = tokenBufferArray[i];
                System.Console.WriteLine(token.value);
            }
        }

    }
}