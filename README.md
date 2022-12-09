# LingLang 玲珑
这是一个无运行时的静态编译型语言.  

## 基础设定
### 代码后缀
- .ling

### 包后缀
- .linglib

### 主入口后缀
- .lingmain

### 文件编码
- UTF-8

### 语言编码
- UTF-8

### 语言版本
- 0.0.1

### 语言特性
- 静态编译型语言
- 强类型语言
- 低面向对象语言
    有结构体, 结构体内有方法  
    可声明与实现接口  
    有多态  
    不可继承结构体/无抽象类  
- 支持泛型
- 多线程友好
- 序列化友好
- 重视代码可读性 / 可维护性
- 所有字段和方法都必须包含在结构体内(包括全局变量和Main函数)

### 特殊点
- 中文关键字(未实现)

### Features
- [] 变量
    - [] let
    - [] const
- [] 基本类型
    - [] int8
    - [] int16
    - [] int32
    - [] int64
    - [] uint8
    - [] uint16
    - [] uint32
    - [] uint64
    - [] float32
    - [] float64
    - [] bool
    - [] char
    - [] string
    - [] void
- [] 运算符
    - [] 算术运算符
        - [] +
        - [] -
        - [] *
        - [] /
        - [] %
    - [] 赋值运算符
        - [] =
        - [] +=
        - [] -=
        - [] *=
        - [] /=
        - [] %=
    - [] 比较运算符
        - [] ==
        - [] !=
        - [] >
        - [] <
        - [] >=
        - [] <=
    - [] 逻辑运算符
        - [] &&
        - [] ||
        - [] !
    - [] 位运算符
        - [] &
        - [] |
        - [] ^
        - [] ~
        - [] <<
        - [] >>
- [] 函数
    - [] 无返回值
    - [] 有返回值
    - [] 泛型
    - [] 重载
    - [] 递归
    - [] 尾递归
    - [] 闭包
- [] 结构体
    - [] 字段
    - [] 方法
    - [] 接口
    - [] 多态
    - [] 泛型
    - [] 重载