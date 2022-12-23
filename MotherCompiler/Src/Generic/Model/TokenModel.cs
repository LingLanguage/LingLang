namespace LingLang.MotherCompiler {

    public struct TokenModel {

        public string value;
        public int index; // 在 tokenArray 中的索引
        public TokenSplitType splitType;

        public TokenModel(string value, TokenSplitType type, int index) {
            this.value = value;
            this.splitType = type;
            this.index = index;
        }

    }

}