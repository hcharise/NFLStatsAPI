/// <summary>
/// Handles fetching and deserializing JSON data from a given URL.
/// This class is responsible for making HTTP requests, validating responses,
/// and converting JSON into C# objects for further processing.
/// </summary>

using Newtonsoft.Json;

public class JsonHandler
{
    public async Task<TeamGamesThisSeason> FetchAndDeserializeJson(string url)
    {
        // Attempt to load and deserialize the json from the URL
        try
        {
            using (HttpClient client = new HttpClient())
            {
                // Validate the URL
                if (string.IsNullOrWhiteSpace(url))
                {
                    throw new ArgumentException("The URL cannot be null or empty.", nameof(url));
                }

                // Fetch the content from the URL
                HttpResponseMessage response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode(); // Throws if status code is not 2xx

                // Read and log the response content
                string jsonContent = await response.Content.ReadAsStringAsync();

                // Check if the response is empty or not JSON-like
                if (string.IsNullOrWhiteSpace(jsonContent) || jsonContent.TrimStart().StartsWith("<"))
                {
                    throw new Exception("The API response is not valid JSON or is empty.");
                }

                // Deserialize the JSON into the Root object
                return JsonConvert.DeserializeObject<TeamGamesThisSeason>(jsonContent);
            }
        }
        catch (HttpRequestException ex)
        {
            // Handle network-related errors
            Console.WriteLine($"Network error: {ex.Message}");
            throw new Exception("There was a problem connecting to the server. Please try again later.", ex);
        }
        catch (JsonException ex)
        {
            // Handle JSON parsing errors
            Console.WriteLine($"JSON error: {ex.Message}");
            throw new Exception("The server response could not be parsed as valid JSON.", ex);
        }
        catch (ArgumentException ex)
        {
            // Handle invalid arguments like null or empty URLs
            Console.WriteLine($"Invalid argument: {ex.Message}");
            throw;
        }
        catch (Exception ex)
        {
            // Catch any other exceptions
            Console.WriteLine($"An unexpected error occurred: {ex.Message}");
            throw new Exception("An unexpected error occurred while processing your request.", ex);
        }
    }
}
