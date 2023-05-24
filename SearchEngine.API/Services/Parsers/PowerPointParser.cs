using SearchEngine.API.Interfaces;
using System.Text;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Presentation;
using SearchEngine.API.Models;

namespace SearchEngine.API.Services.Parsers
{
    public class PowerPointParser : DocParser
    {
        public override IDocument? ExtractDataToDocument(FileInfo file)
        {
            return new Document
            {
                Name = file.Name,
                Content = GetTextContentFromPowerPointFile(file)
            };
        }

        public static string GetTextContentFromPowerPointFile(FileInfo file)
        {

            StringBuilder textContent = new();

            using (PresentationDocument ppt = PresentationDocument.Open(file.FullName, false))
            {
                // Get the relationship ID of the first slide.
                PresentationPart? pptPart = ppt.PresentationPart;

                if (pptPart == null)
                {
                    return string.Empty;
                }
                Presentation presentation = pptPart.Presentation;
                var slideIds = presentation.SlideIdList;

                if  (slideIds == null)
                {
                    return string.Empty;
                }

                foreach (SlideId slideId in slideIds)
                {
                    if (pptPart.GetPartById(slideId.RelationshipId) is SlidePart slidePart)
                    {
                        Slide slide = slidePart.Slide;

                        foreach (var element in slide.Descendants<DocumentFormat.OpenXml.Drawing.Text>())
                        {
                            textContent.Append(element.Text);
                        }
                    }
                } 

              
            }

            return textContent.ToString();        
        }
    }
}
