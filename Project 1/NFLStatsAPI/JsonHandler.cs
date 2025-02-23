using Newtonsoft.Json;
using System.Collections.Concurrent;
using System.Threading;

public class JsonHandler
{
    private readonly HttpClient _client;
    private readonly ConcurrentQueue<(string url, TaskCompletionSource<TeamMatchUpsThisSeason> tcs)> _requestQueue;
    private readonly SemaphoreSlim _semaphore;
    private readonly Task _processingTask;
    private bool _isRunning;

    public JsonHandler(int maxConcurrentRequests = 5)
    {
        _client = new HttpClient();
        _requestQueue = new ConcurrentQueue<(string, TaskCompletionSource<TeamMatchUpsThisSeason>)>();
        _semaphore = new SemaphoreSlim(maxConcurrentRequests);
        _isRunning = true;
        _processingTask = Task.Run(ProcessQueue);
    }

    public Task<TeamMatchUpsThisSeason> FetchAndDeserializeJson(string url)
    {
        if (string.IsNullOrWhiteSpace(url))
            throw new ArgumentException("The URL cannot be null or empty.", nameof(url));

        var tcs = new TaskCompletionSource<TeamMatchUpsThisSeason>();
        _requestQueue.Enqueue((url, tcs)); // Enqueue URL with the TaskCompletionSource
        return tcs.Task; // Return the Task to the caller
    }

    private async Task ProcessQueue()
    {
        while (_isRunning)
        {
            if (_requestQueue.TryDequeue(out var request)) // Dequeue a request
            {
                string url = request.url;
                var tcs = request.tcs;

                await _semaphore.WaitAsync(); // Limit concurrent requests
                try
                {
                    TeamMatchUpsThisSeason result = await FetchAndDeserializeJsonInternal(url);
                    tcs.SetResult(result); // Resolve the task with the result
                }
                catch (Exception ex)
                {
                    tcs.SetException(ex); // Pass the exception to the waiting task
                }
                finally
                {
                    _semaphore.Release();
                }
            }
            else
            {
                await Task.Delay(100); // Avoid busy-waiting
            }
        }
    }

    private async Task<TeamMatchUpsThisSeason> FetchAndDeserializeJsonInternal(string url)
    {
        try
        {
            HttpResponseMessage response = await _client.GetAsync(url);
            response.EnsureSuccessStatusCode();

            string jsonContent = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<TeamMatchUpsThisSeason>(jsonContent);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error fetching JSON from {url}: {ex.Message}");
            throw;
        }
    }

    public void StopProcessing()
    {
        _isRunning = false;
    }
}
