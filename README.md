<div style="align: center">
<img src="./Docs/Logo/Logo-02.png" />
</div>

# LingLang 玲珑语言
- 这是一门静态编译型语言, 无VM.  
- 后缀: .ling / .linglib / .lingmain  

## 语言作者
杰克有茶: https://github.com/jackutea

## Logo 作者
(Logo 是一颗杨桃)  
+-: https://okjk.co/6HRkeu  

## 作者碎碎念
1. 第一次写编译器，总得从经历中成长，没写成也可以当作下一次的经验积累  
2. 当我们在编程时: 90% 时间都在阅读与修改代码，10% 时间写下初始的代码. 因此该语言重视可读性和可维护性.
3. 不想取代什么，只想写个像我这样的程序员喜欢的语言  

## 特性
1. 低面向对象: 不可继承实现 / 组合替代继承 (is -> has)  
2. 允许顶级函数  
3. 隔离副作用(指针层面与函数层面)  
4. 多线程友好: 在安全的地方共享内存  
5. 依赖管理友好: 不依赖路径, 只依赖包名. 项目内亦可增/删/改引用, 对大项目友好.

## 主要关键词
1. `motheronly` / `external`
2. `rptr`
3. `get`: get void Function()
4. `has`

## 📔 Todo
### MotherCompiler
先用个人习惯的语言——C# 写个母编译器，等语言完成后，抽空用LingLang写个编译器以实现自举。  
[] TokenArray  
[] 语法树  
[] 语义  
[] 中间语言(暂定LLVM IR)    
