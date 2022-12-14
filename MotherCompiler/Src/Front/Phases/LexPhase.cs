using System.Collections.Generic;
using LingLang.MotherCompiler.Facades;

namespace LingLang.MotherCompiler.Tokenize {

    public class LexPhase {

        Context ctx;

        public LexPhase() { }

        internal void Inject(Context ctx) {
            this.ctx = ctx;
        }

        public void Analyze(string source) {

            var option = ctx.CompileOption;
            var tokenBuffer = new List<TokenModel>(option.tokenBufferOriginSize);

            // 分割
            Split(source, tokenBuffer);

            // 缓存 (以加快后续的访问速度)
            var tokenBufferArray = tokenBuffer.ToArray();
            ctx.TokenRepo.SetTokenBufferArray(tokenBufferArray);

            // 确定 Token 具体类型
            FillTokenDetail(tokenBufferArray);

            // 看看效果
            // LogUtil.LogTokenBuffer(tokenBufferArray);

        }

        // ====  分割  ====
        static void Split(string source, List<TokenModel> tokenBuffer) {
            int startIndex = 0;
            HashSet<char> splitSingleTokens = SplitTokenCollection.splitSingleTokens;
            Dictionary<char, string[]> splitMultiTokens = SplitTokenCollection.splitMultiTokens;
            for (int i = 0; i < source.Length; i += 1) {
                char c = source[i];
                bool isSpecify = splitSingleTokens.Contains(c);
                if (isSpecify) {

                    // 分割非分隔符
                    SplitUserWord(source, tokenBuffer, ref startIndex, i);

                    // 处理分隔符
                    SplitSplitWord(source, tokenBuffer, ref startIndex, splitMultiTokens, ref i, c);

                } else {
                    // 不是分隔符, 继续
                }
            }
        }

        static void SplitUserWord(string source, List<TokenModel> tokenBuffer, ref int startIndex, int curIndex) {
            bool has = TrySubstring(source, startIndex, curIndex - startIndex, out string tokenValue);
            if (has) {
                startIndex = curIndex + 1;
                TokenModel token = new TokenModel(tokenValue, TokenSplitType.UserWord, tokenBuffer.Count);
                tokenBuffer.Add(token);
            }
        }

        static void SplitSplitWord(string source, List<TokenModel> tokenBuffer, ref int startIndex, Dictionary<char, string[]> splitMultiTokens, ref int curIndex, char c) {

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
                token = new TokenModel(source.Substring(curIndex, endIndex - curIndex + 1), TokenSplitType.LiteralStringValue, tokenBuffer.Count);
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
                        token = new TokenModel(result, TokenSplitType.DocumentValue, tokenBuffer.Count);
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
                token = new TokenModel(result, TokenSplitType.CommentValue, tokenBuffer.Count);
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
                        token = new TokenModel(multiToken, TokenSplitType.SeparatorOrOperator, tokenBuffer.Count);
                        tokenBuffer.Add(token);
                        curIndex += len - 1;
                        startIndex = curIndex + 1;
                        return;
                    }
                }
            }

            // 单字符分隔符
            token = new TokenModel(c.ToString(), TokenSplitType.SeparatorOrOperator, tokenBuffer.Count);
            tokenBuffer.Add(token);
            startIndex = curIndex + 1;

        }

        static bool TrySubstring(string source, int startIndex, int len, out string result) {
            if (startIndex < 0 || (startIndex + len) > source.Length || len <= 0) {
                result = string.Empty;
                return false;
            }
            result = source.Substring(startIndex, len);
            return true;
        }

        // ==== 确定具体 token 类型 ====
        static void FillTokenDetail(TokenModel[] tokenArray) {

        }

    }

}