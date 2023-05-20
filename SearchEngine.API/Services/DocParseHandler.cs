﻿using SearchEngine.API.Exceptions;
using SearchEngine.API.Interfaces;
using SearchEngine.API.Models;
using SearchEngine.API.Utils;

namespace SearchEngine.API.Services
{
    public class DocParseHandler : IDocHandler
    {
        private static bool IsValidFile(FileInfo file)
        {
            return ValidFileTypes.types.Contains(file.Extension);
        }

        public IDocument ExtractDataDocumentFromFile(FileInfo file)
        {
            IDocParser? parser = this.GetValidExtractor(file) ?? 
                                throw new InvalidFileTypeException("Invalid File Format! File cannot be parsed.");
            var _doc = parser.ExtractDataToDocument(file) ?? 
                                throw new InvalidFileTypeException("Error Occurred! File could not be parsed.");
            return _doc;
        }

        public IDocParser? GetValidExtractor(FileInfo file)
        {
            if (!IsValidFile(file)) return null;

            return file.Extension switch
            {
                "html" => new HTMLParser(),
                _ => null,
            };
        }


    }
}