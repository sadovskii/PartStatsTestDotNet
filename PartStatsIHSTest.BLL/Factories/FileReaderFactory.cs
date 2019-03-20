using PartStatsIHSTest.BLL.Exceptions;
using PartStatsIHSTest.BLL.Interfacies;
using PartStatsIHSTest.BLL.Readers;
using PartStatsIHSTest.BLL.Resources;
using PartStatsIHSTest.BLL.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartStatsIHSTest.BLL.Factories
{
    public class FileReaderFactory : IFileReaderFactory
    {
        private Dictionary<string, IFileReader> readers;

        public FileReaderFactory()
        {
            readers = new Dictionary<string, IFileReader>();
            readers.Add(Constans.PdfFormat, new PdfFileReader());
            readers.Add(Constans.TxtFormat, new TxtFileReader());
        }

        public IFileReader Create(string context)
        {
            if (readers.ContainsKey(context))
                return readers[context];

            throw new FormatFileNotReadException(string.Format(ExceptionResource.FormatFileNotRead, context));
        }
    }
}
