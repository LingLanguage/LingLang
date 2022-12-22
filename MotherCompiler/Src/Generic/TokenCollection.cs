using System.Collections.Generic;

namespace LingLang.MotherCompiler {

    public static class TokenCollection {

        // ==== 语句 ====
        public static HashSet<string> expressions = new HashSet<string>() {
            "if", "elseif", "else",                 // 条件语句
            "switch", "case",                       // 分支语句
            "while", "for",                         // 循环语句
            "break", "continue", "return", "goto",  // 跳转语句
            "try", "catch", "finally",              // 异常处理
        };

        public static HashSet<string> definitions = new HashSet<string>() {
            "var", "let", "static", "const",        // 变量声明
            "ptr", "rptr",                          // 指针
            "struct", "interface", "thread",        // 类型声明
            "func", "method",                       // 函数声明
        };

        public static HashSet<string> modules = new HashSet<string>() {
            "ns", "use",                            // 命名空间
            "import", "export", "lib"               // 模块
        };

        // ==== 表达式 ====
        // - 运算符
        public static HashSet<string> operators = new HashSet<string>() {
            "+", "-", "*", "/", "%", "++", "--",    // 算术运算符
            "==", "!=", ">", "<", ">=", "<=",       // 比较运算符
            "&&", "||", "!",                        // 逻辑运算符
            "|", "&", "^", "~", "<<", ">>",         // 位运算符
            "=", "->", "+=", "-=", "*=", "/=", "%=", "&=", "|=", "^=", "<<=", ">>=", // 赋值运算符
            "sizeof", "typeof",                     // 类型运算符
            "hnew", "snew",                         // 内存运算符
        };

    }

}