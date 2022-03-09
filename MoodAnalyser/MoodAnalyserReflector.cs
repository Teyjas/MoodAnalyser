using System.Reflection;
using System.Text.RegularExpressions;

namespace MoodAnalyzer;

public static class MoodAnalyserReflector
{
    /// <summary>
    /// Creates the mood analyser object.
    /// </summary>
    /// <param name="className">Name of the class.</param>
    /// <param name="constructorName">Name of the constructor.</param>
    /// <param name="message">The message.</param>
    /// <returns></returns>
    /// <exception cref="MoodAnalyzer.MoodAnalysisException">
    /// No Such Class
    /// or
    /// No Such Method
    /// </exception>
    public static object CreateMoodAnalyserObject(string className, string constructorName, string message = "")
    {
        string pattern = @"." + constructorName + "$";
        Match result = Regex.Match(className, pattern);
        if (result.Success)
        {
            try
            {
                Type moodAnalyseType = Type.GetType(className);
                if (message == "")
                    return Activator.CreateInstance(moodAnalyseType);
                return Activator.CreateInstance(moodAnalyseType, message);
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

    public static object ReflectorInvoke(string method, string message)
    {
        try
        {
            Type type = typeof(MoodAnalyser);
            MethodInfo methodInfo = type.GetMethod(method);
            object classInstance = Activator.CreateInstance(type);
            FieldInfo fieldInfo = type.GetField("message");
            try
            {
                fieldInfo.SetValue(classInstance, message);
            }
            catch (TargetException)
            {
                throw new MoodAnalysisException(MoodAnalysisException.ExceptionType.NO_SUCH_FIELD, "No such field");
            }
            catch (NullReferenceException)
            {
                throw new MoodAnalysisException(MoodAnalysisException.ExceptionType.NO_SUCH_FIELD, "No such field");
            }
            return methodInfo.Invoke(classInstance, null);
        }
        catch (TargetException)
        {
            throw new MoodAnalysisException(MoodAnalysisException.ExceptionType.NO_SUCH_METHOD, "No such method");
        }
        return null;
    }
}