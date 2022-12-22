namespace LingLang.MotherCompiler {

    public struct TokenModel {

        public string value;
        public TokenType type;
        public int index; // 在 tokenArray 中的索引

        public TokenModel(string value, TokenType type, int index) {
            this.value = value;
            this.type = type;
            this.index = index;
        }

    }

}