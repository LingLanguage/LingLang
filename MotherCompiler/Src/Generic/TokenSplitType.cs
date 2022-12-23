namespace LingLang.MotherCompiler {

    public enum TokenSplitType : byte {
        None,
        UserWord,               // 非关键字
        LiteralStringValue,     // 字符串字面量 (双引号)
        SeparatorOrOperator,    // 分隔符或操作符
        CommentValue,           // 注释 (单行注释, 多行注释, 文档注释, 等等)
        DocumentValue,          // 文档 (单行文档)
    }

}