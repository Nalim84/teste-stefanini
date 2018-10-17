using System;
using System.Configuration;
using System.IO;
using System.Net;
using System.Text;

namespace XPTO.Extractor
{
    public class Extractor : IExtract
    {
        private readonly string _filename;

        public Extractor(string filename)
        {
            _filename = filename;
        }

        public string Execute()
        {
            if (string.IsNullOrEmpty(_filename))
            {
                throw new Exception("You must set any file to extract.");
            }

            var sb = new StringBuilder();

            using (var fileStream = File.OpenRead(string.Concat(ConfigurationManager.AppSettings["pathOutput"], "/", _filename)))
            using (var streamReader = new StreamReader(fileStream, Encoding.UTF8, true, 128))
            {
                String line;
                while ((line = streamReader.ReadLine()) != null)
                {
                    sb.Append(line);
                }
            }

            return sb.ToString();
        }
    }
}
