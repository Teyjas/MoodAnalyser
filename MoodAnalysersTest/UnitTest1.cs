using Microsoft.VisualStudio.TestTools.UnitTesting;
using MoodAnalyzer;

namespace MoodTest;

[TestClass]
public class TestMood
{
    /// <summary>
    /// Tests for sad mood.
    /// </summary>
    /// <param name="message">The message.</param>
    [TestMethod]
    [DataRow("I am in Sad Mood")]
    public void TestSadMood(string message)
    {
        MoodAnalyser moodAnalyser = new MoodAnalyser(message);
        string result = moodAnalyser.AnalyseMood();
        Assert.AreEqual("Sad", result);
    }

    /// <summary>
    /// Tests for happy mood.
    /// </summary>
    /// <param name="message">The message.</param>
    [TestMethod]
    [DataRow("I am in any Mood")]
    public void TestHappyMood(string message)
    {
        MoodAnalyser moodAnalyser = new MoodAnalyser(message);
        string result = moodAnalyser.AnalyseMood();
        Assert.AreEqual("Happy", result);
    }

    /// <summary>
    /// Tests the mood exception.
    /// </summary>
    /// <param name="message">The message.</param>
    [TestMethod]
    [ExpectedException(typeof(MoodAnalysisException))]
    [DataRow(null)]
    [DataRow("")]
    public void TestMoodException(string message)
    {
        MoodAnalyser moodAnalyser = new MoodAnalyser(message);
        moodAnalyser.AnalyseMood();
    }

    /// <summary>
    /// Test mood reflection default ctor for valid names.
    /// </summary>
    [TestMethod]
    public void ValidTestMoodReflectionDefaultCtor()
    {
        string message = null;
        MoodAnalyser expected = new MoodAnalyser(message);
        object obj = MoodAnalyserReflector.CreateMoodAnalyserObject("MoodAnalyzer.MoodAnalyser", "MoodAnalyser");
        Assert.AreNotEqual(expected, obj);
    }

    /// <summary>
    /// Test mood reflection default ctor for invalid names.
    /// </summary>
    [TestMethod]
    [ExpectedException(typeof(MoodAnalysisException))]
    [DataRow("MoodAnalyzer.MoodAnalysers", "MoodAnalyser", "sad")]
    [DataRow("MoodAnalyzer.MoodAnalyser", "MoodAnalysers", "sad")]
    public void InvalidTestMoodReflectionParamCtor(string className, string ctorName, string message)
    {
        MoodAnalyser expected = new MoodAnalyser(message);
        object obj = MoodAnalyserReflector.CreateMoodAnalyserObject(className, ctorName, message);
        Assert.AreNotEqual(expected, obj);
    }

    /// <summary>
    /// Test reflector invoke for invalid method and messages
    /// </summary>
    /// <param name="method">The method.</param>
    /// <param name="message">The message.</param>
    [TestMethod]
    [ExpectedException(typeof(MoodAnalysisException))]
    [DataRow("AnalyzeMood", "Happy")]
    [DataRow("AnalyseMood", null)]
    public void InvalidTestReflectorInvoke(string method, string message)
    {
        MoodAnalyserReflector.ReflectorInvoke(method, message);
    }
}