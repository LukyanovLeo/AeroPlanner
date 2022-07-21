using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Db.Models.QueryBlocks
{
    public static class AdditionalQueryBlocks
    {
        private static Dictionary<LogicCondition, string> ConditionsMap { get; } = new Dictionary<LogicCondition, string>
        {
            { LogicCondition.Eq, "=" },
            { LogicCondition.Ne, "<>" },
            { LogicCondition.Gt, ">" },
            { LogicCondition.Lt, "<" },
            { LogicCondition.Ge, ">=" },
            { LogicCondition.Le, "<=" },
        };

        public enum LogicCondition
        {
            Eq,
            Ne,
            Gt,
            Lt,
            Ge,
            Le,
        }

        public static string FROM(this string source, string fullTableName)
        {
            try
            {
                if (!Regex.IsMatch(fullTableName, @"^[a-z_0-9]{1,63}\.[a-z_0-9]{1,63}$"))
                    throw new ArgumentException(fullTableName);
                source += $"FROM {fullTableName} ";
            }
            catch (ArgumentException e)
            {
                Console.WriteLine($"Wrong table name: {e.Message}" + e.StackTrace);
            }
            return source;
        }

        public static string LogicEquation(this string source, string value1, LogicCondition cond, string value2)
        {
            try
            {
                if (!Regex.IsMatch(value1, @"^[a-z_0-9]{1,63}$"))
                    throw new ArgumentException(value1);

                if (Regex.IsMatch(value2, @"\(.+\)"))
                    source += $"({value1} {ConditionsMap[cond]} {value2}) ";
                else
                    source += $"({value1} {ConditionsMap[cond]} '{value2}') ";
            }
            catch (ArgumentException e)
            {
                Console.WriteLine($"Wrong value: {e.Message}" + e.StackTrace);
            }
            return source;
        }

        public static string WHERE(this string source) => source + " WHERE ";
        public static string AND(this string source) => source + " AND ";
        public static string OR(this string source) => source + " OR ";
        public static string OPEN(this string source) => source + "(";
        public static string CLOSE(this string source) => source + ")";

        public static string IN(this string source, string target, IEnumerable<object> values)
        {
            try
            {
                if (!Regex.IsMatch(target, @"^[a-z_0-9]{1,63}$"))
                    throw new ArgumentException(target);
                source += $"({target} IN ({String.Join(',', values.Select(v => $"'{v}'"))})) ";
            }
            catch (ArgumentException e)
            {
                Console.WriteLine($"Wrong column name: {e.Message}" + e.StackTrace);
            }
            return source;
        }

        public static string IN(this string source, string target, params object[] values)
        {
            try
            {
                if (!Regex.IsMatch(target, @"^[a-z_0-9]{1,63}$"))
                    throw new ArgumentException(target);
                source += $"({target} IN ({String.Join(',', values.Select(v => $"'{v}'"))})) ";
            }
            catch (ArgumentException e)
            {
                Console.WriteLine($"Wrong column name: {e.Message}" + e.StackTrace);
            }
            return source;
        }

        public static string LIKE(this string source, string target, string pattern)
        {
            try
            {
                if (!Regex.IsMatch(target, @"^[a-z_0-9]{1,63}$"))
                    throw new ArgumentException(target);
                source += $"({target} LIKE '{pattern}') ";
            }
            catch (ArgumentException e)
            {
                Console.WriteLine($"Wrong column name: {e.Message}" + e.StackTrace);
            }
            return source;
        }



        public static string LIMIT(this string source, ushort limit, ushort offset = 0)
        {
            try
            {
                source += $"LIMIT {limit} OFFSET {offset} ";
            }
            catch (Exception e)
            {
                Console.WriteLine(e.InnerException.Message);
            }
            return source;
        }

        public static string VALUES(this string source, params string[] entities)
        {
            try
            {
                foreach (var entity in entities)
                    if (!Regex.IsMatch(entity, @"^@[a-zA-Z0-9]{1,64}$"))
                        throw new ArgumentException(entity);

                if (!source.Contains("VALUES"))
                    source += $"VALUES ({String.Join(',', entities)}) ";
                else
                    source += $",({String.Join(',', entities)}) ";
            }
            catch (Exception e)
            {
                Console.WriteLine(e.InnerException.Message);
            }
            return source;
        }

        public static string RETURNING_ID(this string source)
        {
            try
            {
                source += $"RETURNING id ";
            }
            catch (Exception e)
            {
                Console.WriteLine(e.InnerException.Message);
            }
            return source;
        }

        public static string SET(this string source, string targetColumn, object targetValue)
        {
            try
            {
                if (!Regex.IsMatch(targetColumn, @"^[a-z_0-9]{1,63}$"))
                    throw new ArgumentException(targetColumn);

                if (!source.Contains("SET"))                    
                    source += $"SET {targetColumn} = '{targetValue}' ";
                else
                    source += $", {targetColumn} = '{targetValue}' ";
            }
            catch (ArgumentException e)
            {
                Console.WriteLine($"Wrong table name: {e.Message}" + e.StackTrace);
            }
            return source;
        }

        private static string ToSnakeCase(string input)
        {
            if (string.IsNullOrEmpty(input)) { return input; }

            var startUnderscores = Regex.Match(input, @"^_+");
            return startUnderscores + Regex.Replace(input, @"([a-z0-9])([A-Z])", "$1_$2").ToLower();
        }

        private static List<object> StringifyValues(this List<object> values)
        {
            var newValues = new List<object>();
            foreach (var value in values)
            {
                if (value != null)
                    newValues.Add($"'{value}'");
                else
                    newValues.Add("null");
            }
            return newValues;
        }
    }
}
