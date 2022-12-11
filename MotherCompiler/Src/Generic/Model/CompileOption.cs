namespace MotherCompiler {

    public struct CompileOption {

        public int tokenBufferOriginSize;

        public readonly static CompileOption Default = new CompileOption() {
            tokenBufferOriginSize = 65535
        };

    }

}