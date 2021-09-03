using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Enumeration;
using System.Text;
using System.Text.RegularExpressions;

namespace ConsoleApp1
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var x = System.IO.File.ReadAllText("f.text");
            x = x.Replace("\n", "").Replace("\r", "").Replace(") ", ")")
                    .Replace(") ",")")
                    .Replace(")  ",")")
                    .Replace(")   ",")")
                    .Replace(")    ",")")
                    .Replace(")     ",")")
                    .Replace(")      ",")");
             var str = x.Split("Total Number of Direction");
             var n = 0;

                var dic = new Dictionary<int, string>();
                
                    foreach (var s in str)
                    {
                        if (string.IsNullOrEmpty(s)) continue;
                        n += 1;
                        dic.Add(n,s);
                    }

                    var newDic = new Dictionary<int, string>();
                foreach (var d in dic)
            {
                n += 1;
                
                    const string pattern = @"\d{6}\s[A-Z]{8}\(";
                var m = Regex.Match(d.Value, pattern, RegexOptions.IgnoreCase);
                if (m.Success)
                {
                    const string pattern2 = @"\)Number of Chars:|\)\sNumber of Chars:";
                    var m2 = Regex.Match(d.Value, pattern2, RegexOptions.IgnoreCase);
                    if (!m2.Success)
                    {
                        newDic.Add(d.Key,d.Value);
                        Console.WriteLine(d.Key);
                    }

                }
                else
                {
                    newDic.Add(d.Key,d.Value);
                    Console.WriteLine(d.Key);
                }


            }


                //=========================

                    
               

                const string fileName = @"commercial.txt";    
    
                try    
                {    
                    if (File.Exists(fileName))    
                    {    
                        File.Delete(fileName);    
                    }
                foreach (var (key, value) in newDic)
                {
                    using var fs = File.AppendText(fileName);
                    fs.WriteLine($"No[{key}] Total Number of Direction{value}"); }
                }    
                catch (Exception Ex)    
                {    
                    Console.WriteLine(Ex.Message);    
                }

                //=========================
        }
    }
}