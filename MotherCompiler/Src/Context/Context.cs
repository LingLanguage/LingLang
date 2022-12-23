using System;
using System.Collections.Generic;

namespace LingLang.MotherCompiler.Facades {

    public class Context {

        CompileOption compileOption;
        public CompileOption CompileOption => compileOption;

        TokenRepo tokenRepo;
        public TokenRepo TokenRepo => tokenRepo;

        public Context() {
            this.tokenRepo = new TokenRepo();
        }

        internal void Inject(CompileOption option) {
            this.compileOption = option;
        }

    }

}