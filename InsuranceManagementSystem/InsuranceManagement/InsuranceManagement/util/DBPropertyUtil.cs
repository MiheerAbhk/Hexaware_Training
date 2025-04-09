using System;
using System.Collections.Generic;
using System.IO;

namespace InsuranceManagementSystem.util
{
    public class DBPropertyUtil
    {
        public static Dictionary<string, string> GetDbProperties(string fileName)
        {
            var properties = new Dictionary<string, string>();
            foreach (var line in File.ReadAllLines(fileName))
            {
                if (!string.IsNullOrWhiteSpace(line) && line.Contains("="))
                {
                    var parts = line.Split('=');
                    properties[parts[0].Trim()] = parts[1].Trim();
                }
            }
            return properties;
        }

        public static string GetConnectionString(string fileName)
        {
            var props = GetDbProperties(fileName);
            string server = props["server"];
            string database = props["database"];

            // Connection string for Windows Authentication
            return $"Data Source={server};Initial Catalog={database};Integrated Security=True";
        }
    }
}
