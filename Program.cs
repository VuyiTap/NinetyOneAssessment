using System;
using System.Collections.Generic;

public class Program
{
    public static void Main()
    {
        // CSV data stored as a string
        string csvData = "FirstName,SecondName,Score\nDee,Moore,56\nSipho,Lolo,78\nNoosrat,Hoosain,64\nGeorge,Of The Jungle,78";

        // Parse the CSV data into a list of string arrays representing rows
        List<string[]> dataRows = ParseCSV(csvData);

        // Find the individuals with the highest scores
        List<string[]> highestScorers = GetHighestScorers(dataRows);

        // Output the individuals with the highest scores
        if (highestScorers.Count > 0)
        {
            Console.WriteLine("Individuals with the highest scores:");
            foreach (string[] row in highestScorers)
            {
                Console.WriteLine($"{row[0]} {row[1]}");
            }
            Console.WriteLine($"Score:{highestScorers[0][2]}");
        }
        else
        {
            Console.WriteLine("No highest scorers found.");
        }
    }

    // Parse the CSV data into a list of string arrays representing rows
    private static List<string[]> ParseCSV(string csvData)
    {
        List<string[]> rows = new List<string[]>();

        // Split the CSV data into lines
        string[] lines = csvData.Split(new[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);

        // Iterate over each line
        foreach (string line in lines)
        {
            // Split the line into values using comma as the delimiter
            string[] values = line.Split(',');

            // Add the values as a row to the list
            rows.Add(values);
        }

        // Return the parsed rows
        return rows;
    }

    // Find the individuals with the highest scores
    private static List<string[]> GetHighestScorers(List<string[]> dataRows)
    {
        List<string[]> highestScorers = new List<string[]>();
        int highestScore = 0;

        // Iterate over each row
        foreach (string[] row in dataRows)
        {
            // Check if the row has the expected number of columns and the score is a valid integer
            if (row.Length == 3 && int.TryParse(row[2], out int score))
            {
                // If the score is higher than the current highest score,
                // clear the list and add the current row as the new highest scorer
                if (score > highestScore)
                {
                    highestScorers.Clear();
                    highestScorers.Add(row);
                    highestScore = score;
                }
                // If the score is equal to the current highest score,
                // add the current row to the list of highest scorers
                else if (score == highestScore)
                {
                    highestScorers.Add(row);
                }
            }
        }

        // Sort the highest scorers alphabetically by combining their first names and last names
        highestScorers.Sort((a, b) => string.Compare(a[0] + a[1], b[0] + b[1], StringComparison.Ordinal));

        // Return the list of highest scorers
        return highestScorers;
    }
}
