namespace MoodAnalyzer;

public class MoodAnalysisException : Exception
{
    private ExceptionType type;

    public enum ExceptionType
    {
        NULL_MOOD,
        EMPTY_MOOD,
    }

    public MoodAnalysisException(ExceptionType type, string errorMessage) : base(errorMessage)
    {
        this.type = type;
    }
}