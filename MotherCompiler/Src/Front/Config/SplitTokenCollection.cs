using System.Collections.Generic;

namespace LingLang.MotherCompiler.Tokenize {

    public static class SplitTokenCollection {

        public readonly static HashSet<char> splitSingleTokens = new HashSet<char>() {
            ' ',
            '(', ')',
            '{', '}',
            '[', ']',
            ',', ';', '.', ':',
            '?', '!', '@', '#',
            '$', '%', '^', '&',
            '*', '+', '-', '=',
            '/', '\\', '|',
            '<', '>',
            '~', '`',
            '\'', '\'',
            '"',
            '\r', '\n', '\t'
        };

        public readonly static Dictionary<char, string[]> splitMultiTokens = new Dictionary<char, string[]>() {
            // 更长的放前面
            { '=', new string[] { "==", "=>" } },
            { '!', new string[] { "!=", "!!" } },
            { '<', new string[] { "<<=", "<<", "<=", "<>" } },
            { '>', new string[] { ">>=", ">>", ">=" } },
            { '&', new string[] { "&&", "&=" } },
            { '|', new string[] { "||", "|=" } },
            { '+', new string[] { "++", "+=" } },
            { '-', new string[] { "--", "-=", "->" } },
            { '*', new string[] { "**", "*=" } },
            { '/', new string[] { "/=" } },
            { '%', new string[] { "%=" } },
            { '^', new string[] { "^=" } },
            { '~', new string[] { "~=" } },
            { '`', new string[] { "```", "``" } },
            { '?', new string[] { "??" } },
            { '\r',new string[] { "\r\n" } },
        };

    }

}