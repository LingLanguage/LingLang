namespace MotherCompiler {

    public enum TokenType {
        Identifier,     // 标识符 (变量名, 函数名, 类名, 结构体名, 枚举名, 接口名, 命名空间名, 等等)
        Keyword,        // 关键字 
        Operator,       // 运算符 (算术运算符, 逻辑运算符, 比较运算符, 位运算符, 赋值运算符, 等等)
        Literal,        // 字面量 (整数, 浮点数, 字符串, 布尔值, 等等)
        Separator,      // 分隔符 (逗号, 分号, 点, 冒号, 等等)
        Comment,        // 注释 (单行注释, 多行注释, 文档注释, 等等)
        Whitespace      // 空格
    }

}