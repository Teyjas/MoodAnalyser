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
}