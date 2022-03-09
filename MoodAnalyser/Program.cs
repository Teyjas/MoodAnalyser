using MoodAnalyzer;

MoodAnalyser mood = new MoodAnalyser("I am really sad");

string moodStatus = mood.AnalyseMood();

Console.WriteLine("Input Text: I am really sad");
Console.WriteLine("Mood: " + moodStatus);
Console.ReadLine();