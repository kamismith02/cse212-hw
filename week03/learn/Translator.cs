public class Translator
{
    private Dictionary<string, string> _words = new();

    public static void Run()
    {
        var englishToGerman = new Translator();
        englishToGerman.AddWord("House", "Haus");
        englishToGerman.AddWord("Car", "Auto");
        englishToGerman.AddWord("Plane", "Flugzeug");

        Console.WriteLine(englishToGerman.Translate("Car"));    // Auto
        Console.WriteLine(englishToGerman.Translate("Plane"));  // Flugzeug
        Console.WriteLine(englishToGerman.Translate("Train"));  // ???
    }

    /// <summary>
    /// Add the translation from 'from_word' to 'to_word'
    /// </summary>
    /// <param name="fromWord">The word to translate from</param>
    /// <param name="toWord">The word to translate to</param>
    public void AddWord(string fromWord, string toWord)
    {
        // Add the translation to the dictionary
        _words[fromWord] = toWord;
    }

    /// <summary>
    /// Translates the from word into the word that this stores as the translation
    /// </summary>
    /// <param name="fromWord">The word to translate</param>
    /// <returns>The translated word or "???" if no translation is available</returns>
    public string Translate(string fromWord)
    {
        // Check if the word exists in the dictionary and return the translation or "???"
        return _words.TryGetValue(fromWord, out var translation) ? translation : "???";
    }
}