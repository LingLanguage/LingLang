using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace MotherCompiler.Tokenize {

    public class TokenizePhase {

        public void Tokenize(string source, List<TokenModel> tokenBuffer) {

            // TODO: 根据参数是否处理注释, 如不处理注释, 则直接移除注释部分

            // 去除多余空格和换行符
            source = TrimToOnlyOneSpace(source);
            System.Console.WriteLine(source);

            // 识别关键字
            TokenizeKeyword(source, tokenBuffer);

            // 看看效果
            string tmp = "";
            for (int i = 0; i < tokenBuffer.Count; i += 1) {
                TokenModel token = tokenBuffer[i];
                tmp += token.value;
            }
            System.Console.WriteLine(tmp);

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

        void TokenizeSplitWord(string source, List<TokenModel> tokenBuffer, ref int startIndex, Dictionary<char, string[]> splitMultiTokens, ref int curIndex, char c) {
            if (splitMultiTokens.TryGetValue(c, out string[] multiTokens)) {
                // 如果是多字符分隔符
                int count = multiTokens.Length;
                for (int i = 0; i < count; i += 1) {
                    var multiToken = multiTokens[i];
                    int len = multiToken.Length;
                    if (len + curIndex > source.Length) {
                        continue;
                    }
                    if (source.Substring(curIndex, len) == multiToken) {
                        TokenModel token = new TokenModel() {
                            value = multiToken.Trim(),
                            type = TokenType.None,
                            isSplitWord = true,
                        };
                        tokenBuffer.Add(token);
                        curIndex += len - 1;
                        startIndex = curIndex + 1;
                        break;
                    }
                }
            } else {
                // 如果是单字符分隔符
                TokenModel token = new TokenModel() {
                    value = c.ToString().Trim(),
                    type = TokenType.None,
                    isSplitWord = true,
                };
                tokenBuffer.Add(token);
            }
        }

        void TokenizeNormalWord(string source, List<TokenModel> tokenBuffer, ref int startIndex, int curIndex) {
            string tokenValue = source.Substring(startIndex, curIndex - startIndex);
            startIndex = curIndex + 1;
            TokenModel token = new TokenModel() {
                value = tokenValue.Trim(),
                type = TokenType.None,
                isSplitWord = false,
            };
            tokenBuffer.Add(token);
        }

    }

}