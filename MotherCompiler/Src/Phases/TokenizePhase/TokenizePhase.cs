using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace MotherCompiler.Tokenize {

    public class TokenizePhase {

        public void Tokenize(string source, List<TokenModel> tokenBuffer) {

            // TODO: 根据参数是否处理注释, 如不处理注释, 则直接移除注释部分

            // 识别关键字
            TokenizeKeyword(source, tokenBuffer);

            // 看看效果
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < tokenBuffer.Count; i += 1) {
                TokenModel token = tokenBuffer[i];
                sb.Append(token.value);
            }
            System.Console.WriteLine(sb.ToString());

        }

        string TrimToOnlyOneSpace(string source) {
            // 去除多余的空格和换行符
            return Regex.Replace(source, @"[\s]+", " ");
        }

        void TokenizeKeyword(string source, List<TokenModel> tokenBuffer) {
            int startIndex = 0;
            HashSet<char> splitSingleTokens = TokenConfig.splitSingleTokens;
            Dictionary<char, string[]> splitMultiTokens = TokenConfig.splitMultiTokens;
            for (int i = 0; i < source.Length; i += 1) {
                char c = source[i];
                bool isSpecify = splitSingleTokens.Contains(c);
                if (isSpecify) {

                    // 分割非分隔符
                    TokenizeNormalWord(source, tokenBuffer, ref startIndex, i);

                    // 处理分隔符
                    TokenizeSplitWord(source, tokenBuffer, ref startIndex, splitMultiTokens, ref i, c);

                } else {
                    // 不是分隔符, 继续
                }
            }
        }

        void TokenizeNormalWord(string source, List<TokenModel> tokenBuffer, ref int startIndex, int curIndex) {
            bool has = TrySubstring(source, startIndex, curIndex - startIndex, out string tokenValue);
            if (has) {
                startIndex = curIndex + 1;
                TokenModel token = new TokenModel() {
                    value = tokenValue,
                    type = TokenType.Identifier,
                    isSplitWord = false,
                };
                tokenBuffer.Add(token);
            }
        }

        void TokenizeSplitWord(string source, List<TokenModel> tokenBuffer, ref int startIndex, Dictionary<char, string[]> splitMultiTokens, ref int curIndex, char c) {

            TokenModel token;

            // ==== 换行符 ====
            // 如果是换行符`\n`, 把后面的换行符和空格都跳过
            if (c == '\n' || c == '\r') {
                int endIndex = curIndex;
                for (int i = curIndex; i < source.Length; i += 1) {
                    char c2 = source[i];
                    if (c2 == ' ' || c2 == '\n' || c2 == '\r') {
                        endIndex = i;
                    } else {
                        break;
                    }
                }

                curIndex = endIndex;
                startIndex = endIndex + 1;
                return;
            }

            // ==== 空格 ====
            // 如果是空格` `, 把后面的空格都跳过
            if (c == ' ') {
                int endIndex = curIndex;
                for (int i = curIndex; i < source.Length; i += 1) {
                    char c2 = source[i];
                    if (c2 == ' ') {
                        endIndex = i;
                    } else {
                        break;
                    }
                }

                curIndex = endIndex;
                startIndex = endIndex + 1;
                return;
            }

            // ==== 换行 ====
            // 如果是换行符`\n`, 把后面的换行符都跳过

            // ==== 字符串常量 ====
            // 如果是字符串`"`的左边引号, 直到字符串的右边引号才结束, 形成一个字符串常量
            if (c == '"') {
                // 找下一个引号, 如果引号左边一个字符是转义符`\`, 则不是字符串的右边引号
                int endIndex = curIndex;
                for (int i = curIndex + 1; i < source.Length; i += 1) {
                    char c2 = source[i];
                    if (c2 == '"') {
                        if (source[i - 1] == '\\') {
                            // 转义符, 继续
                        } else {
                            endIndex = i;
                            break;
                        }
                    }
                }

                // 生成一个字符串常量的 token
                token = new TokenModel() {
                    value = source.Substring(curIndex, endIndex - curIndex + 1),
                    type = TokenType.LiteralStringValue,
                    isSplitWord = true,
                };
                tokenBuffer.Add(token);
                curIndex = endIndex;
                startIndex = endIndex + 1;
                return;

            }

            // ==== 文档注释 ====
            // 如果是文档注释 `////`, 直到换行符才结束
            if (c == '/') {
                bool has = TrySubstring(source, curIndex, 4, out string result);
                if (has && result == "////") {
                    int endIndex = source.IndexOf('\n', curIndex + 1);
                    if (endIndex == -1) {  // 没有找到换行符, 报错
                        throw new System.Exception("注释没有换行符");
                    }
                    has = TrySubstring(source, curIndex, 4, out result);
                    if (has) {
                        token = new TokenModel() {
                            value = result,
                            type = TokenType.DocumentValue,
                            isSplitWord = true,
                        };
                        tokenBuffer.Add(token);
                        curIndex = endIndex;
                        startIndex = curIndex + 1;
                        return;
                    }
                }
            }

            // ==== 注释 ====
            // 如果是注释 `//`, 直到换行符才结束
            if (c == '/') {
                int endIndex = source.IndexOf('\n', curIndex + 1);
                if (endIndex == -1) {  // 没有找到换行符, 报错
                    throw new System.Exception("注释没有换行符");
                }
                string result = source.Substring(curIndex + 2, endIndex - curIndex);
                token = new TokenModel() {
                    value = result,
                    type = TokenType.CommentValue,
                    isSplitWord = true,
                };
                tokenBuffer.Add(token);
                curIndex = endIndex;
                startIndex = curIndex + 1;
                return;
            }

            // ==== 常规字符分隔符 ====
            if (splitMultiTokens.TryGetValue(c, out string[] multiTokens)) {
                // 多字符分隔符
                int count = multiTokens.Length;
                for (int i = 0; i < count; i += 1) {
                    var multiToken = multiTokens[i];
                    int len = multiToken.Length;
                    bool has = TrySubstring(source, curIndex, len, out string result);
                    if (has && result == multiToken) {
                        token = new TokenModel() {
                            value = multiToken,
                            type = TokenType.Separator,
                            isSplitWord = true,
                        };
                        tokenBuffer.Add(token);
                        curIndex += len - 1;
                        startIndex = curIndex + 1;
                        return;
                    }
                }
            }

            // 单字符分隔符
            token = new TokenModel() {
                value = c.ToString(),
                type = TokenType.Separator,
                isSplitWord = true,
            };
            tokenBuffer.Add(token);
            startIndex = curIndex + 1;

        }

        bool TrySubstring(string source, int startIndex, int len, out string result) {
            if (startIndex < 0 || (startIndex + len) > source.Length || len <= 0) {
                result = string.Empty;
                return false;
            }
            result = source.Substring(startIndex, len);
            return true;
        }

    }

}