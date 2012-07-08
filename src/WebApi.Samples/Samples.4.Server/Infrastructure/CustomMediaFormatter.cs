using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Http.Formatting;
using Samples.Common;
using System.IO;

namespace Samples._4.Server.Infrastructure
{
    public class CustomMediaFormatter : BufferedMediaTypeFormatter
    {
        public CustomMediaFormatter()
        {
            SupportedMediaTypes.Add(new System.Net.Http.Headers.MediaTypeHeaderValue("text/example"));
        }

        public override bool CanReadType(Type type)
        {
            return false;
        }

        public override bool CanWriteType(Type type)
        {
            if (type == typeof(Resume))
                return true;

            return false;
        }

        public override void WriteToStream(Type type, object value, System.IO.Stream stream, System.Net.Http.Headers.HttpContentHeaders contentHeaders)
        {
            using (var writer = new StreamWriter(stream))
            {
                writer.Write("CustomFormatted resume");
            }
        }
    }
}
