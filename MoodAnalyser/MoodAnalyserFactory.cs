using System.Text.RegularExpressions;

namespace MoodAnalyzer;

public static class MoodAnalyserFactory
{
    /// <summary>
    /// Creates the mood analyser object with default constructor
    /// </summary>
    /// <param name="className">Name of the class.</param>
    /// <param name="constructorName">Name of the constructor.</param>
    /// <returns>Object of the className provided</returns>
    /// <exception cref="MoodAnalyzer.MoodAnalysisException">
    /// No Such Class
    /// or
    /// No Such Method
    /// </exception>
    public static object CreateMoodAnalyserObject(string className, string constructorName)
    {
        string pattern = @"." + constructorName + "$";
        Match result = Regex.Match(className, pattern);
        if (result.Success)
        {
            try
            {
                Type moodAnalyseType = Type.GetType(className);
                return Activator.CreateInstance(moodAnalyseType);
            }
            catch (ArgumentNullException)
            {
                Console.WriteLine("Your input is not valid");
                throw new MoodAnalysisException(MoodAnalysisException.ExceptionType.NO_SUCH_CLASS, "Class not found");

            }
        }
        else
            throw new MoodAnalysisException(MoodAnalysisException.ExceptionType.NO_SUCH_METHOD, "Constructor is not found");
        return null;
    }
}
