using System.Collections.Generic;

namespace LingLang.MotherCompiler.Facades {

    public class TokenRepo {

        // ==== Original ====
        TokenModel[] tokenBufferArray;
        public TokenModel[] TokenBufferArray => tokenBufferArray;
        public void SetTokenBufferArray(TokenModel[] value) => tokenBufferArray = value;

        public TokenRepo() { }

    }

}