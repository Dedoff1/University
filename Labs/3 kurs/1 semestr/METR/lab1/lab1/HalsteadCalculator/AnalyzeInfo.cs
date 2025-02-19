using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace HalsteadCalculator
{
    public class AnalyzeInfo
    {
        public Dictionary<string, int> OperatorCount { get; private set; }
        public Dictionary<string, int> OperandCount { get; private set; }
        public double ProgramLength { get; private set; }
        public double ProgramVocabulary { get; private set; }
        public double ProgramVolume { get; private set; }

        // Зарезервированные слова и типы для фильтрации
        private static readonly HashSet<string> ReservedWords = new HashSet<string>
        {
            "as", "as?", "break", "class", "continue", "do", "else", "false", 
            "for", "fun", "if", "in", "!in", "interface", "is", "!is", "null", 
            "object", "package", "return", "super", "this", "throw", "true", 
            "try", "typealias", "val", "var", "when", "while", "by", "catch", 
            "constructor", "delegate", "dynamic", "field", "file", "finally", 
            "get", "import", "init", "param", "property", "receiver", "set", 
            "setparam", "where", "actual", "abstract", "annotation", "companion", 
            "const", "crossinline", "data", "enum", "expect", "external", "final", 
            "infix", "inline", "inner", "internal", "lateinit", "noinline", "open", 
            "operator", "out", "override", "private", "protected", "public", 
            "reified", "sealed", "suspend", "tailrec", "vararg", "field", "it", 
            "by", "get", "set", "super", "this", "else", "throw", "return", "break", 
            "continue", "object", "if", "try", "when", "for", "do", "while", 
            "package", "import", "class", "interface", "fun", "val", "var", 
            "typealias", "this", "super", "is", "!is", "in", "!in", "throw", 
            "return", "break", "continue", "Boolean", "String", "Int", "import","java","util"
        };

        public void AnalyzeFile(string filePath)
        {
            string[] lines = File.ReadAllLines(filePath);

            OperatorCount = new Dictionary<string, int>();
            OperandCount = new Dictionary<string, int>();

            var functionCalls = new HashSet<string>();
            var methodsCalled = new HashSet<string>();

            foreach (string line in lines)
            {
                // Удаляем строки, заключенные в двойные кавычки
                string processedLine = Regex.Replace(line, "\"([^\"]*)\"", "");

                // Регулярное выражение для вызовов функций
                MatchCollection functionMatches = Regex.Matches(processedLine,
                    @"\b[a-zA-Z_\$][a-zA-Z0-9_\$]*\s*\(");

                foreach (Match match in functionMatches)
                {
                    string functionCall = match.Value.TrimEnd('(');
                    functionCalls.Add(functionCall);
                    if (OperatorCount.ContainsKey(functionCall))
                    {
                        OperatorCount[functionCall]++;
                    }
                    else
                    {
                        OperatorCount[functionCall] = 1;
                    }
                }
                
                // Регулярное выражение для операторов
                MatchCollection operatorMatches = Regex.Matches(processedLine,
                  @"(\===|\++|\+=|\-=|\*=|/=|==|\!=|\>=|\<=|\->|\=>|\|\||&&|::|<<|>>|\.\.|\+|\-|\*|\/|\%|\=|\!|\>|\<|\&|\||\^|\~|\#)");

                foreach (Match match in operatorMatches)
                {
                    string op = match.Value;
                    if (OperatorCount.ContainsKey(op))
                    {
                        OperatorCount[op]++;
                    }
                    else
                    {
                        OperatorCount[op] = 1;
                    }
                }

                // Регулярное выражение для методов, вызванных через точку (например, .toInt)
                //MatchCollection methodCallMatches = Regex.Matches(processedLine, @"\.[a-zA-Z_\$][a-zA-Z0-9_\$]*\b");

                //foreach (Match match in methodCallMatches)
                //{
                //    string methodCall = match.Value.TrimStart('.');
                //    methodsCalled.Add(methodCall);  // Добавляем метод в список вызванных методов

                //    if (OperatorCount.ContainsKey(methodCall))
                //    {
                //        OperatorCount[methodCall]++;
                //    }
                //    else
                //    {
                //        OperatorCount[methodCall] = 1;
                //    }
                //}

                // Регулярное выражение для операндов
                MatchCollection operandMatches = Regex.Matches(processedLine, @"\b[a-zA-Z_\$][a-zA-Z0-9_\$]*\b|\b\d+\b");

                foreach (Match match in operandMatches)
                {
                    string operand = match.Value;
                    // Проверяем, что это не функция, не зарезервированное слово и не метод, вызванный через точку
                    if (!ReservedWords.Contains(operand) && 
                        !functionCalls.Contains(operand) &&
                        !methodsCalled.Contains(operand))
                    {
                        if (OperandCount.ContainsKey(operand))
                        {
                            OperandCount[operand]++;
                        }
                        else
                        {
                            OperandCount[operand] = 1;
                        }
                    }
                }
            }

            // Вычисление метрик программы
            int uniqueOperatorCount = OperatorCount.Count;
            int uniqueOperandCount = OperandCount.Count;
            int totalOperatorCount = OperatorCount.Values.Sum();
            int totalOperandCount = OperandCount.Values.Sum();
            ProgramLength = totalOperatorCount + totalOperandCount;
            ProgramVocabulary = uniqueOperatorCount + uniqueOperandCount;
            ProgramVolume = ProgramLength * (Math.Log(ProgramVocabulary) / Math.Log(2));
        }

        
        //private bool IsOutputLine(string line)
        //{
        //    return line.Contains("println") || line.Contains("print");
        //}
    }
}
