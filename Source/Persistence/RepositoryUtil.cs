using System.Reflection;
using System.Text;

namespace TFirewall.Source.Persistence;

public static class RepositoryUtil
{
    public static string PreviewQuery(string query, object parameters)
    {
        PropertyInfo[] parameterDictionary = parameters.GetType().GetProperties();
        StringBuilder previewSql = new StringBuilder(query);

        foreach (PropertyInfo param in parameterDictionary)
        {
            string placeholder = "@" + param.Name;
            string value = param.GetValue(parameters)?.ToString() ?? "NULL";
            if (value != "NULL")
                value = $"'{value}'";
            previewSql.Replace(placeholder, value);
        }

        return previewSql.ToString();
    }
}