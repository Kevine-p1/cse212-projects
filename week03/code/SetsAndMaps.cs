 using System.Text.Json;

public static class SetsAndMaps
{
    /// <summary>
    /// Find symmetric pairs of two-character words using a set.
    /// </summary>
    public static string[] FindPairs(string[] words)
    {
        var seen = new HashSet<string>();
        var pairs = new List<string>();

        foreach (var word in words)
        {
            // Words such as "aa" should not match themselves.
            if (word[0] == word[1])
            {
                continue;
            }

            var reversed = $"{word[1]}{word[0]}";

            // If we have already seen the reversed word,
            // then we have found a symmetric pair.
            if (seen.Contains(reversed))
            {
                pairs.Add($"{word} & {reversed}");
            }

            seen.Add(word);
        }

        return pairs.ToArray();
    }

    /// <summary>
    /// Read a census file and summarize the degrees earned.
    /// </summary>
    public static Dictionary<string, int> SummarizeDegrees(string filename)
    {
        var degrees = new Dictionary<string, int>();

        foreach (var line in File.ReadLines(filename))
        {
            var fields = line.Split(",");

            // The degree is stored in the fourth column.
            var degree = fields[3].Trim();

            if (degrees.ContainsKey(degree))
            {
                degrees[degree]++;
            }
            else
            {
                degrees[degree] = 1;
            }
        }

        return degrees;
    }

    /// <summary>
    /// Determine whether two strings are anagrams.
    /// Ignore spaces and letter case.
    /// </summary>
    public static bool IsAnagram(string word1, string word2)
    {
        var letterCounts = new Dictionary<char, int>();
        var word1Length = 0;
        var word2Length = 0;

        // Count the letters in the first word.
        foreach (var letter in word1)
        {
            if (letter == ' ')
            {
                continue;
            }

            var normalizedLetter = char.ToLowerInvariant(letter);
            word1Length++;

            if (letterCounts.ContainsKey(normalizedLetter))
            {
                letterCounts[normalizedLetter]++;
            }
            else
            {
                letterCounts[normalizedLetter] = 1;
            }
        }

        // Remove matching letters using the second word.
        foreach (var letter in word2)
        {
            if (letter == ' ')
            {
                continue;
            }

            var normalizedLetter = char.ToLowerInvariant(letter);
            word2Length++;

            if (!letterCounts.TryGetValue(normalizedLetter, out var count) ||
                count == 0)
            {
                return false;
            }

            letterCounts[normalizedLetter] = count - 1;
        }

        return word1Length == word2Length;
    }

    /// <summary>
    /// Read earthquake data from the USGS and return
    /// formatted place and magnitude descriptions.
    /// </summary>
    public static string[] EarthquakeDailySummary()
    {
        const string uri =
            "https://earthquake.usgs.gov/earthquakes/feed/v1.0/summary/all_day.geojson";

        using var client = new HttpClient();
        using var getRequestMessage =
            new HttpRequestMessage(HttpMethod.Get, uri);

        using var jsonStream =
            client.Send(getRequestMessage).Content.ReadAsStream();

        using var reader = new StreamReader(jsonStream);

        var json = reader.ReadToEnd();

        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };

        var featureCollection =
            JsonSerializer.Deserialize<FeatureCollection>(json, options);

        if (featureCollection?.Features == null)
        {
            return [];
        }

        var results = new List<string>();

        foreach (var feature in featureCollection.Features)
        {
            if (feature.Properties == null)
            {
                continue;
            }

            results.Add(
                $"{feature.Properties.Place} - Mag {feature.Properties.Mag}"
            );
        }

        return results.ToArray();
    }
}