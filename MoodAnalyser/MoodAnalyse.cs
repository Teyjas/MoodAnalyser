namespace MoodAnalyzer;

public class MoodAnalyser
{
    string message;

    public MoodAnalyser()
    {
        message = "";
    }

    public MoodAnalyser(string message)
    {
        this.message = message;
    }

    /// <summary>
    /// Analyses the mood.
    /// </summary>
    public string AnalyseMood()
    {
        if (message.Contains("Sad", StringComparison.OrdinalIgnoreCase) is true)
            return "Sad";
        return "Happy";
    }
}