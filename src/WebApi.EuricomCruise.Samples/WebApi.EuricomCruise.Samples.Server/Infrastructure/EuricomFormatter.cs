using System;
using System.IO;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Net.Http;

namespace WebApi.EuricomCruise.Samples.Server.Infrastructure
{
    public class EuricomFormatter : BufferedMediaTypeFormatter
    {
        public EuricomFormatter()
        {
            SupportedMediaTypes.Add(new MediaTypeHeaderValue("application/euri"));
        }

        public override bool CanReadType(Type type)
        {
            return false;
        }

        public override bool CanWriteType(Type type)
        {
            if (type == typeof(Bank)) 
                return true;

            return false;
        }

        public override void WriteToStream(Type type, object value, Stream writeStream, HttpContent content)
        {
            var bank = (Bank)value;

            using (var writer = new StreamWriter(writeStream))
            {
                writer.Write(bank.BIC + ":EURI:" + bank.Name);
            }
        }        
    }
}
