Basic Usage

    using System.Text.Json;
    using SDK = InteroperabilityWrapperRnet.InteroperabilityWrapperRnet;
    
    public class DotnetSDKit
    {
        public void RunDemo()
        {
            string paramsJson = "{\"page\": \"1\"}";
    
            Console.WriteLine(".NET SDK");
    
            try 
            {
                string response = SDK.FetchForDotnet(paramsJson);
                Console.WriteLine(response);
            }
            catch (Exception e) 
            {
                Console.WriteLine($"Error: {e.Message}");
            }
        }
    }
    
    class Program
    {
        static void Main()
        {
            new DotnetSDKit().RunDemo();
        }
    }

Dynamic Usage

    using System.Text.Json;
    using System.Text.Json.Serialization;
    using SDK = InteroperabilityWrapperRnet.InteroperabilityWrapperRnet;
    
    public record Pagination(
        [property: JsonPropertyName("total_pages")] int TotalPages
    );
    
    public record SDKItem(
        [property: JsonPropertyName("title")] string Title
    );
    
    public record FetchResponse(
        [property: JsonPropertyName("data")] List<SDKItem> Data,
        [property: JsonPropertyName("pagination")] Pagination Pagination
    );
    
    public class DotnetSDKit
    {
        public string FetchPage(int page)
        {
            string paramsJson = $"{{\"page\": \"{page}\"}}";
            return SDK.FetchForDotnet(paramsJson);
        }
    }
    
    class Program
    {
        static void Main()
        {
            var sdk = new DotnetSDKit();
            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
    
            Console.WriteLine("--- Bhilani Interop SDK ---");
    
            for (int pageNum = 1; pageNum <= 5; pageNum++)
            {
                try
                {
                    string response = sdk.FetchPage(pageNum);
                    var parsed = JsonSerializer.Deserialize<FetchResponse>(response, options);
    
                    int totalPages = parsed?.Pagination.TotalPages ?? 0;
    
                    if (parsed?.Data == null || parsed.Data.Count == 0 || pageNum > totalPages)
                    {
                        Console.WriteLine($"Page {pageNum}: Success (No Data - Server has {totalPages} pages)");
                    }
                    else
                    {
                        Console.WriteLine($"Page {pageNum}: Success");
                        foreach (var item in parsed.Data)
                        {
                            Console.WriteLine($"  - Title: {item.Title}");
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Page {pageNum}: Failed (Error: {e.Message})");
                }
            }
        }
    }

Concurrent Usage

    ramramjiramramjuramramji
    ramramjiramramjuramramji
    ramramjiramramjuramramji
