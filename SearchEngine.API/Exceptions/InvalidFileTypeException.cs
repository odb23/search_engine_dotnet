namespace SearchEngine.API.Exceptions
{
    public class InvalidFileTypeException : Exception
    {
        public InvalidFileTypeException() : base() { }   
        public InvalidFileTypeException(string message) : base(message) { }
    }
}
