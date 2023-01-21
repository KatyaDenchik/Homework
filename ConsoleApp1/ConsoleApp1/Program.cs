using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Console.WriteLine("Старi номери телефонiв: ");
            var text = GetText("./telephoneDirectory.txt");
            var paternOldTelephone = @"\d{2}\(\d{2}\)\d{3}-\d{2}-\d{2}";
            FindPatern(text, paternOldTelephone);

            Console.WriteLine("\nЕлектронi адреси: ");
            var paternEmail = @"^(?("")(""[^""]+?""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                          @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9]{2,17}))$";
            text = GetText("./emailAddresses.txt");
            FindPatern(text, paternEmail);

            Console.WriteLine("\nОператори привласнення: ");
            text = GetText("./codeC++.txt");
            var paternAssignmemtOperator = @"[^\>\<\=]=[^\>\<\=]";
            FindPatern(text, paternAssignmemtOperator);

            Console.WriteLine("\nОператори умовного переходу: ");
            text = GetText("./codeC++.txt");
            var paternConditionOperator = @"else if|else|if";
            FindPatern(text, paternConditionOperator);

            Console.WriteLine("\nОператори циклу: ");
            text = GetText("./codeC++.txt");
            var paternCycleOperator = @"for each|while|for";
            FindPatern(text, paternCycleOperator);

            Console.WriteLine("\nНомери оператору Київстар: ");
            text = GetText("./KS.txt");
            var paternKSOperator = @"(38)?0(67|96|97|98)[\d ]*";
            FindPatern(text, paternKSOperator);

            Console.WriteLine("\nЛинки на iнформацiйнi ресурси: ");
            text = GetText("./links.txt");
            var paternLinks = @"https?:\/\/[^ \s(),]*";
            FindPatern(text, paternLinks);

            Console.WriteLine("\nЛинки на iнформацiйнi ресурси технiкуму: ");
            text = GetText("./links.txt");
            var paternLinksKHPCC = @"(https?:\/\/)?khpcc.com\/?[^ \s(),]*";
            FindPatern(text, paternLinksKHPCC);

            Console.WriteLine("\nЛинки на iнформацiйнi ресурси FB: ");
            text = GetText("./links.txt");
            var paternLinksFB = @"(https?:\/\/)?www.facebook.com\/?[^ \s(),]*";
            FindPatern(text, paternLinksFB);

            Console.WriteLine("\nМатематичнi вирази: ");
            text = GetText("./links.txt");
            var paternMathematicalExpression = @"^(!?\+?\-?\*?\/?\(?\)?[a-z]?\d?)+=(!?\+?\-?\*?\/?\(?\)?[a-z]?\d?=?)+";
            FindPatern(text, paternMathematicalExpression);




        }

        private static void FindPatern(List<string> text, string patern)
        {
            Regex regex = new Regex(patern);
            foreach (var line in text)
            {
                MatchCollection matches = regex.Matches(line);
                if (matches.Any())
                {
                    foreach (Match match in matches)
                        Console.WriteLine(match.Value);
                }
            }
        }

        public static List<string> GetText(string path) => File.ReadAllLines(path).ToList();
    }
}
