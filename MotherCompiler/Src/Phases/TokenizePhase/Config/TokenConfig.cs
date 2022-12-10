using System.Collections.Generic;

namespace MotherCompiler.Tokenize {

    public class TokenConfig {

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
        };

        public readonly static Dictionary<char, string[]> splitMultiTokens = new Dictionary<char, string[]>() {
            { '=', new string[] { "==", "=>" } },
            { '!', new string[] { "!=", "!!" } },
            { '<', new string[] { "<<=", "<<", "<=", "<>" } },
            { '>', new string[] { ">>=", ">>", ">=" } },
            { '&', new string[] { "&&", "&=" } },
            { '|', new string[] { "||", "|=" } },
            { '+', new string[] { "++", "+=" } },
            { '-', new string[] { "--", "-=" } },
            { '*', new string[] { "**", "*=" } },
            { '/', new string[] { "//", "/=" } },
            { '%', new string[] { "%=" } },
            { '^', new string[] { "^=" } },
            { '~', new string[] { "~=" } },
            { '`', new string[] { "``", "```" } },
            { '?', new string[] { "??" } },
            { '\\',new string[] {"\\r\\n" , "\\r", "\\n" } },
            { '{', new string[] { "{{" } },
            { '}', new string[] { "}}" } },
        };

    }

}