using System.IO;
using System.Linq;
using System.Text;
using PartStatsIHSTest.BLL.Interfacies;


namespace PartStatsIHSTest.BLL.Utils
{
    public class FileValidate : IFileValidate
    {
        public bool CheckFileEncoding(FileInfo fileInfo, Encoding encoding)
        {
            using (var reader = new StreamReader(fileInfo.FullName, new UnicodeEncoding()))
            {
                reader.Peek();
                return reader.CurrentEncoding == encoding;
            }
        }

        public bool Check(string str)
        {
            if (str.Count(x => x == ',') == 1)
            {
                var result = str.Split(',').Select(t => t.Trim()).ToArray();

                if (!string.IsNullOrEmpty(result[0]) && int.TryParse(result[1], out int numer))
                    return true;
            }
            return false;
        }
    }
}
