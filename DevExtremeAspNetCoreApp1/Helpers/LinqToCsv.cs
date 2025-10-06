using System.Text;

namespace DevExtremeAspNetCoreApp1.Helpers
{
    public static class LinqToCsv
    {
        public static string ToCsv<T>(this IEnumerable<T> items, bool addHeaderRow = true)
            where T : class
        {
            var csvBuilder = new StringBuilder();

            var properties = typeof(T).GetProperties();

            if (addHeaderRow)
            {
                string line = string.Join(";", properties.Select(p => p.Name.ToCsvValue()).ToArray());
                csvBuilder.AppendLine(line);
            }

            foreach (T item in items)
            {
                string line = string.Join(";", properties.Select(p => p.GetValue(item, null).ToCsvValue()).ToArray());
                csvBuilder.AppendLine(line);
            }

            return csvBuilder.ToString();
        }

        private static string ToCsvValue<T>(this T item)
        {
            if (item == null) return "\"\"";

            if (item is string s)
                return string.Format("\"{0}\"", s.Replace("\"", "\"\""));

            if (item is DateTime time)
                return string.Format("\"{0:O}\"", time.ToLocalTime());

            double dummy;
            if (double.TryParse(item.ToString(), out dummy))
                return string.Format("{0}", item);

            return string.Format("\"{0}\"", item);
        }
    }
}