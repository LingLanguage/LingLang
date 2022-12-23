namespace LingLang.MotherCompiler {

    public enum TokenDetailType : byte {
        None,
        Identifier,             // 标识符
        LiteralStringValue,     // 字符串字面量 (双引号)
        LiteralNumber,          // 数字字面量
        CommentValue,           // 注释
        DocumentValue,          // 文档

        Assign,                 // 赋值符号
        Operator,               // 操作符
        Separator,              // 分隔符
        Access,                 // 访问符号
        StaticConst,            // 静态修饰符
        Constraint,             // 约束符号
        Declaration,            // 声明符号 (let, var, const, struct, interface, static, thread, method, ptr, rptr)

    }

}