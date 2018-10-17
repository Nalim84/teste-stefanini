using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XPTO.Extractor;

namespace XPTO.Application.Service
{
    public class ExtractorService<T> : BaseService
    {
        private readonly IExtract _extractFile;
        private readonly IParser<T> _parser;

        private const char fileLineBreak = ';';
        private const char fileValueBreak = ',';

        public ExtractorService(IExtract extractFile, IParser<T> parser)
        {
            _extractFile = extractFile;
            _parser = parser;
        }

        public IList<T> ExtractParsedFiles()
        {
            var data = _extractFile.Execute();
            var model = _parser.Parse(data, fileValueBreak, fileLineBreak);

            return model;
        }
    }
}
