using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using System.Xml.Xsl;
using TfsMergeCandidates.Extensions;

namespace TfsMergeCandidates.Output
{
    public class HtmlMergeOutputter : IMergeOutputter
    {
        private string _xsltTemplateLocation;

        public HtmlMergeOutputter(string xsltTemplateLocation)
        {
            _xsltTemplateLocation = xsltTemplateLocation;
        }

        public void WriteOut(MergeCandidateContainer merges, string outputPath)
        {
            using (var writer = new StreamWriter(Path.Combine(outputPath, string.Format("merge-candidates-{0}.html", DateTime.Now.ToString()).MakePathSafe())))
            {
                writer.Write(GenerateHtmlOutput(merges));
            }
        }

        private string GenerateHtmlOutput(MergeCandidateContainer mergeData)
        {
            // Serialize the build report data.
            Stream serializationStream = new MemoryStream();
            XmlSerializer serializer = new XmlSerializer(mergeData.GetType());
            serializer.Serialize(serializationStream, mergeData);

            // Load the XSLT build email template.
            Stream styleSheetStream = new FileStream(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, _xsltTemplateLocation), FileMode.Open);
            XmlReader styleSheetReader = XmlReader.Create(styleSheetStream);
            XslCompiledTransform xslTransformer = new XslCompiledTransform();
            xslTransformer.Load(styleSheetReader);
            styleSheetStream.Close();
            styleSheetReader.Close();

            // Generate object reader/writer.
            Stream outputStream = new MemoryStream();
            XmlWriter writer = XmlWriter.Create(outputStream, new XmlWriterSettings() { ConformanceLevel = ConformanceLevel.Fragment });

            serializationStream.Position = 0;
            XmlReader reader = XmlReader.Create(serializationStream);

            // Perform the transform.
            xslTransformer.Transform(reader, writer);

            // Return the generated HTML content.
            outputStream.Position = 0;
            StreamReader outputReader = new StreamReader(outputStream);
            string contentBody = outputReader.ReadToEnd();

            outputReader.Close();
            return contentBody;
        }
    }
}
