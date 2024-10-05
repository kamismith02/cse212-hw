using System.Text.Json;

public static class SetsAndMaps
{
    /// <summary>
    /// The words parameter contains a list of two character 
    /// words (lower case, no duplicates). Using sets, find an O(n) 
    /// solution for returning all symmetric pairs of words.  
    ///
    /// For example, if words was: [am, at, ma, if, fi], we would return :
    ///
    /// ["am & ma", "if & fi"]
    ///
    /// The order of the array does not matter, nor does the order of the specific words in each string in the array.
    /// at would not be returned because ta is not in the list of words.
    ///
    /// As a special case, if the letters are the same (example: 'aa') then
    /// it would not match anything else (remember the assumption above
    /// that there were no duplicates) and therefore should not be returned.
    /// </summary>
    /// <param name="words">An array of 2-character words (lowercase, no duplicates)</param>
    public static string[] FindPairs(string[] words)
    {
        HashSet<string> wordSet = new HashSet<string>(words);
        HashSet<string> processedWords = new HashSet<string>();
        List<string> result = new List<string>();

        foreach (var word in words)
        {
            // Skip if the word has already been processed
            if (processedWords.Contains(word))
            {
                continue;
            }

            // Create the reverse of the current word
            char[] charArray = word.ToCharArray();
            Array.Reverse(charArray);
            string reversedWord = new string(charArray);

            // Check if the reversed word is in the set and not the same
            if (wordSet.Contains(reversedWord) && word != reversedWord)
            {
                // Ensure the pair is added in a consistent order
                string pair = string.Compare(word, reversedWord) < 0
                    ? $"{word} & {reversedWord}"
                    : $"{reversedWord} & {word}";

                // Add the pair to the result and mark both words as processed
                result.Add(pair);
                processedWords.Add(word);
                processedWords.Add(reversedWord);
            }
        }

        return result.ToArray();
    }

    /// <summary>
    /// Read a census file and summarize the degrees (education)
    /// earned by those contained in the file.  The summary
    /// should be stored in a dictionary where the key is the
    /// degree earned and the value is the number of people that 
    /// have earned that degree.  The degree information is in
    /// the 4th column of the file.  There is no header row in the
    /// file.
    /// </summary>
    /// <param name="filename">The name of the file to read</param>
    /// <returns>fixed array of divisors</returns>
    public static Dictionary<string, int> SummarizeDegrees(string filename)
    {
        var degrees = new Dictionary<string, int>();

        // Read the file line by line
        foreach (var line in File.ReadLines(filename))
        {
            // Split the line by comma
            var fields = line.Split(",");

            // Check if the fields contain enough columns
            if (fields.Length >= 4)
            {
                var degree = fields[3].Trim(); // Get the degree from the 4th column

                // Add the degree to the dictionary or update the count
                if (degrees.ContainsKey(degree))
                {
                    degrees[degree]++;
                }
                else
                {
                    degrees[degree] = 1; // Initialize the count for new degree
                }
            }
        }

        return degrees;
    }

    /// <summary>
    /// Determine if 'word1' and 'word2' are anagrams.  An anagram
    /// is when the same letters in a word are re-organized into a 
    /// new word.  A dictionary is used to solve the problem.
    /// 
    /// Examples:
    /// is_anagram("CAT","ACT") would return true
    /// is_anagram("DOG","GOOD") would return false because GOOD has 2 O's
    /// 
    /// Important Note: When determining if two words are anagrams, you
    /// should ignore any spaces.  You should also ignore cases.  For 
    /// example, 'Ab' and 'Ba' should be considered anagrams
    /// 
    /// Reminder: You can access a letter by index in a string by 
    /// using the [] notation.
    /// </summary>
    public static bool IsAnagram(string word1, string word2)
    {
        // Normalize the words: remove spaces and convert to lower case
        word1 = word1.Replace(" ", "").ToLower();
        word2 = word2.Replace(" ", "").ToLower();

        // If the lengths differ, they cannot be anagrams
        if (word1.Length != word2.Length)
        {
            return false;
        }

        // Create a dictionary to count occurrences of each character in word1
        var charCount = new Dictionary<char, int>();

        // Count each character in word1
        foreach (var ch in word1)
        {
            if (charCount.ContainsKey(ch))
            {
                charCount[ch]++;
            }
            else
            {
                charCount[ch] = 1;
            }
        }

        // Decrease the count for each character in word2
        foreach (var ch in word2)
        {
            if (charCount.ContainsKey(ch))
            {
                charCount[ch]--;
                // If count goes below zero, they are not anagrams
                if (charCount[ch] < 0)
                {
                    return false;
                }
            }
            else
            {
                // If character is not found in word1, they are not anagrams
                return false;
            }
        }

        // If we reach here, all counts should be zero
        return true;
    }

    /// <summary>
    /// This function will read JSON (Javascript Object Notation) data from the 
    /// United States Geological Service (USGS) consisting of earthquake data.
    /// The data will include all earthquakes in the current day.
    /// 
    /// JSON data is organized into a dictionary. After reading the data using
    /// the built-in HTTP client library, this function will return a list of all
    /// earthquake locations ('place' attribute) and magnitudes ('mag' attribute).
    /// Additional information about the format of the JSON data can be found 
    /// at this website:  
    /// 
    /// https://earthquake.usgs.gov/earthquakes/feed/v1.0/geojson.php
    /// 
    /// </summary>
    public static string[] EarthquakeDailySummary()
    {
        const string uri = "https://earthquake.usgs.gov/earthquakes/feed/v1.0/summary/all_day.geojson";
        using var client = new HttpClient();
        using var getRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);
        using var jsonStream = client.Send(getRequestMessage).Content.ReadAsStream();
        using var reader = new StreamReader(jsonStream);
        var json = reader.ReadToEnd();
        var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

        var featureCollection = JsonSerializer.Deserialize<FeatureCollection>(json, options);

        // TODO Problem 5:
        // 1. Add code in FeatureCollection.cs to describe the JSON using classes and properties 
        // on those classes so that the call to Deserialize above works properly.
        // 2. Add code below to create a string out each place a earthquake has happened today and its magitude.
        // 3. Return an array of these string descriptions.

        // Create the output array
        var earthquakeSummaries = new string[featureCollection.Features.Count];

        for (int i = 0; i < featureCollection.Features.Count; i++)
        {
            var feature = featureCollection.Features[i];
            earthquakeSummaries[i] = $"{feature.Properties.Place} - Mag {feature.Properties.Mag}";
        }

        return earthquakeSummaries;
    }
}