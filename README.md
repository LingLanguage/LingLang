<div style="align: center">
<img src="./Docs/Logo/Logo-02.png" />
</div>

# LingLang 玲珑语言
- 这是一门静态编译型语言, 无VM.  
- 主要特点: 1. 接口访问权限可控; 2. 内存安全; 3. 包管理便捷  
- 后缀: .ling / .linglib / .lingmain  

## 语言作者
杰克有茶: 游戏创作者, 擅长C#  

## Logo 作者
(Logo 是一颗杨桃)  
+-: https://okjk.co/6HRkeu  

## 作者碎碎念
1. 第一次写编译器，总得从经历中成长，没写成也可以当作下一次的经验积累  
2. 大项目中，权限控制很重要，这是当前大多数语言缺失的，这是我想实现的关键一点  
3. 多线程经常打乱架构，我想独立出一套多线程控制的方法  
4. 二进制操作应当支持得更友好，比如int8[] ToBytes(T obj)和T FromBytes<T>(int8[] src)
5. 不想取代什么，只想写个像我这样的程序员喜欢的语言

## 📔 Todo
### MotherCompiler
先用个人习惯的语言——C# 写个母编译器，等语言完成后，抽空用LingLang写个编译器以实现自举。  
[] TokenArray  
[] 语法树  
[] 语义  
[] RTL  
[] 汇编  
[] 目标机器码  
