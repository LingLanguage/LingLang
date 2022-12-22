using System.Collections.Generic;

namespace LingLang.MotherCompiler.Facades {

    public class TokenRepo {

        // ==== Original ====
        List<TokenModel> tokenBuffer;
        public List<TokenModel> TokenBuffer => tokenBuffer;

        public TokenRepo(int tokenBufferOriginSize) {
            tokenBuffer = new List<TokenModel>(tokenBufferOriginSize);
        }

    }

}