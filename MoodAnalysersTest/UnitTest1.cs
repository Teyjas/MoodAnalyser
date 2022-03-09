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

    [TestMethod]
    [ExpectedException(typeof(MoodAnalysisException))]
    [DataRow(null)]
    [DataRow("")]
    public void TestMoodException(string message)
    {
        MoodAnalyser moodAnalyser = new MoodAnalyser(message);
        moodAnalyser.AnalyseMood();
    }

    [TestMethod]
    public void TestMoodReflectionDefaultCtor()
    {
        string message = null;
        MoodAnalyser expected = new MoodAnalyser(message);
        object obj = MoodAnalyserFactory.CreateMoodAnalyserObject("MoodAnalyzer.MoodAnalyser", "MoodAnalyser");
        Assert.AreNotEqual(expected, obj);
    }
}