# 说明
MotherCompiler 是首次编译 LingLang 的编译器, 也是 LingLang 的第一个编译器, 基于 C#.  
当实现自举后, 将会使用 LingLang 重写 MotherCompiler, 并将其命名为 LingLangCompiler.

# 编译阶段
## 词法分析 LexicalAnalysis
SourceCode -> Token Array
```
// 1. 换行符 / 多空格 -> 1个空格
// 2. 移除 // 注释
// 3. 保留 //// 注释
// 4. 遍历每个字符, 生成 Token
// 5. 生成 Token Array
// 1~5 是单一文件的处理, 对所有文件进行处理后, 合并成一个 Token Array
```

## 语法分析 SyntaxAnalysis
Token Array -> Syntax Tree

## 语义分析 SemanticAnalysis
Syntax Tree -> Semantic Tree

## 中间代码生成 IntermediateCodeGeneration
Semantic Tree -> Intermediate Code

## 代码优化 CodeOptimization
Intermediate Code -> Optimized Intermediate Code

## 目标代码生成 TargetCodeGeneration
Optimized Intermediate Code -> Target Code
