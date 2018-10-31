using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using CommandLine;

namespace FixHomoglyphs
{
    public class Program
    {
        private class Options
        {
            [Option("input-file", Required = true, HelpText = "Input file to be processed.")]
            public string InputFile { get; set; }

            [Option("output-file", Required = true, HelpText = "Output file destination.")]
            public string OutputFile { get; set; }
        }

        public static void Main(string[] args)
        {
            Console.WriteLine("Press a key to continue...");
            Console.ReadKey();
            Parser.Default.ParseArguments<Options>(args)
                .WithParsed(RunOptionsAndReturnExitCode)
                .WithNotParsed(HandleParseError);
        }

        private static void HandleParseError(IEnumerable<Error> errs)
        {
            Console.WriteLine("Failed to parse command line arguments.");

            foreach (var err in errs)
            {
                Console.WriteLine(err.ToString());
            }
        }

        private static void RunOptionsAndReturnExitCode(Options opts)
        {
            Console.WriteLine("Input: " + opts.InputFile + ", Output: " + opts.OutputFile);

            var names = File.ReadLines(opts.InputFile);

            Console.WriteLine("Read in " + names.Count() + " names.");

            var newNames = new List<string>(new[] { "Test" });

            Dictionary<string, string> homoglyphs = new Dictionary<string, string>()
        {
                {"Ä","A"},
                {"Å","A"},
                {"Á","A"},
                {"Â","A"},
                {"À","A"},
                {"Ã","A"},
                {"â","a"},
                {"ä","a"},
                {"à","a"},
                {"å","a"},
                {"á","a"},
                {"ã","a"},
                {"ß","B"},
                {"þ","b"},
                {"Þ","b"},
                {"Ç","C"},
                {"ç","c"},
                {"Ð","D"},
                {"É","E"},
                {"Ê","E"},
                {"Ë","E"},
                {"È","E"},
                {"é","e"},
                {"ê","e"},
                {"ë","e"},
                {"è","e"},
                {"ƒ","f"},
                {"Í","I"},
                {"Î","I"},
                {"Ï","I"},
                {"ï","i"},
                {"î","i"},
                {"ì","i"},
                {"í","i"},
                {"ı","i"},
                {"Ñ","N"},
                {"ñ","n"},
                {"Ö","O"},
                {"Ó","O"},
                {"Ô","O"},
                {"Ò","O"},
                {"Õ","O"},
                {"ô","o"},
                {"ö","o"},
                {"ò","o"},
                {"ó","o"},
                {"ø","o"},
                {"ð","o"},
                {"õ","o"},
                {"Ü","U"},
                {"Ú","U"},
                {"Û","U"},
                {"Ù","U"},
                {"ü","u"},
                {"û","u"},
                {"ù","u"},
                {"ú","u"},
                {"µ","u"},
                {"Ý","Y"},
                {"ÿ","y"},
                {"ý","y"},
                {"Ø","0"}
        };




            //var re = new Regex(@"(\d{6}),(\d{3}),""(\w+), (\w+)"",""?([\d,]+)""?,(\d{8}),(\d{4})", RegexOptions.Compiled);

            foreach (var name in names)
            {

                newNames.Add(name);

                //var match = re.Match(record);

                //if (match.Success)
                //{
                //var accountNumber = match.Groups[1].Value;
                //var loanId = match.Groups[2].Value;
                //var name = match.Groups[4].Value + " " + match.Groups[3].Value;
                //var firstName = match.Groups[4].Value;
                //var amountDue = "$" + int.Parse(match.Groups[5].Value.Replace(",", "")) / 100.0m + ".00";
                //var dueDate = match.Groups[6].Value;
                //var ssn = match.Groups[7].Value;

                //var newRecord = string.Join(",", accountNumber, loanId, name, amountDue, dueDate, ssn);

                //    newNames.Add(newName);
                //}
            }

            File.WriteAllLines(opts.OutputFile, newNames);
        }
    }
}

