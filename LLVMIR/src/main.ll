target datalayout = "e-m:o-i64:64-f80:128-n8:16:32:64-S128"
target triple = "x86_64-pc-windows-msvc"

; puts 函数声明
declare i32 @puts(i8* nocapture readonly)
declare i32 @printf(i8*, ...) #1 ; 声明 printf 函数 
@.format_d = private unnamed_addr constant [4 x i8] c"%d\0A\00", align 1 ; 常量字符串

; 全局变量 @
@n1 = global i32 1

define void @log_num(i32 %input) {
entry:
  call i32 (i8*, ...) @printf(i8* getelementptr inbounds ([4 x i8], [4 x i8]* @.format_d, i32 0, i32 0), i32 %input) ; 调用 printf 函数
  ret void
}

define i32 @main() {
entry:
  %0 = load i32, i32* @n1     ; 读取全局变量 @n1 的值 ;
  %1 = add i32 %0, 8          ; 将全局变量 @n1 的值加 1
  store i32 %1, i32* @n1      ; 将计算结果存入全局变量 @n1
  call void @log_num(i32 %1)  ; 调用 log 函数
  ret i32 %1                  ; 返回计算结果
}
