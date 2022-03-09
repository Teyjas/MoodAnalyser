namespace MoodAnalyzer;

public class MoodAnalysisException : Exception
{
    private ExceptionType type;

    public enum ExceptionType
    {
        NULL_MOOD,
        EMPTY_MOOD,
        NO_SUCH_CLASS,
        NO_SUCH_METHOD
    }

    public MoodAnalysisException(ExceptionType type, string errorMessage) : base(errorMessage)
    {
        this.type = type;
    }
}