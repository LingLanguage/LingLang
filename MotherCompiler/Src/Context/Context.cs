using System.Collections.Generic;

namespace LingLang.MotherCompiler.Facades {

    public class Context {

        TokenRepo tokenRepo;
        public TokenRepo TokenRepo => tokenRepo;

        public Context(int tokenBufferOriginSize) {
            this.tokenRepo = new TokenRepo(tokenBufferOriginSize);
        }

    }

}