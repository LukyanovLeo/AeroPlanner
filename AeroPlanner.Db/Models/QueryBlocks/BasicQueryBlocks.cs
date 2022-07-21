using System;
using System.Text.RegularExpressions;

namespace Db.Models.QueryBlocks
{
    public static class BasicQueryBlocks
    {
        public static string SELECT(this string source, params string[] columns)
        {
            try
            {
                foreach (var column in columns)
                    if (!Regex.IsMatch(column, @"^([mM][aA][xX]|[mM][iI][nN]|[sS][uU][mM]|[aA][vV][gG])?\(?[a-z_0-9]{1,63}\)?$"))
                        throw new ArgumentException(column);

                source += $"SELECT {String.Join(",", columns)} ";
            }
            catch (ArgumentException e)
            {
                Console.WriteLine($"Wrong column name: {e.Message}. " + e.StackTrace);
            }
            return source;
        }
        public static string INSERT(this string source, string fullTableName, params string[] targetColumns)
        {
            try
            {
                if (!Regex.IsMatch(fullTableName, @"^[a-z_0-9]{1,63}\.[a-z_0-9]{1,63}$"))
                    throw new ArgumentException(fullTableName);

                if (targetColumns != null)
                    foreach (var column in targetColumns)
                        if (!Regex.IsMatch(column, @"^[a-z_0-9]{1,63}$"))
                            throw new ArgumentException(column);

                source += $"INSERT INTO {fullTableName}{(targetColumns != null ? " (" + String.Join(',', targetColumns) + ")" : null)} ";
            }
            catch (Exception e)
            {
                Console.WriteLine(e.InnerException.Message);
            }
            return source;
        }

        public static string DELETE(this string source, string fullTableName)
        {
            try
            {
                if (!Regex.IsMatch(fullTableName, @"^[a-z_0-9]{1,63}\.[a-z_0-9]{1,63}$"))
                    throw new ArgumentException(fullTableName);
                source += $"DELETE FROM {fullTableName}";
            }
            catch (Exception e)
            {
                Console.WriteLine(e.InnerException.Message);
            }
            return source;
        }

        public static string UPDATE(this string source, string fullTableName)
        {
            try
            {
                if (!Regex.IsMatch(fullTableName, @"^[a-z_0-9]{1,63}\.[a-z_0-9]{1,63}$"))
                    throw new ArgumentException(fullTableName);
                source += $"UPDATE {fullTableName} ";
            }
            catch (ArgumentException e)
            {
                Console.WriteLine($"Wrong table name: {e.Message}" + e.StackTrace);
            }
            return source;
        }
    }
}
