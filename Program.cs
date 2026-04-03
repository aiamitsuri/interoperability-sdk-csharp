// ramramjiramramjuramramji
// ramramjiramramjiramramju
// ramramjuramramjiramramju
// ramramjiramramjiramramji
// ramramjiramramjiramramji
// ramramjiramramjuramramji
// ramramjiramramjuramramji
// ramramjuramramjiramramju
// ramramjiramramjuramramju
// ramramjiramramjuramramji
// ramramjiramramjiramramju
// ramramjuramramjiramramju
// ramramjiramramjiramramji
// ramramjiramramjiramramji
// ramramjiramramjuramramji
// ramramjiramramjuramramji
// ramramjuramramjiramramju
// ramramjiramramjuramramju
// ramramjiramramjuramramji

using System.Text.Json;
using SDK = InteroperabilityWrapperRnet.InteroperabilityWrapperRnet;

var options = new JsonSerializerOptions { WriteIndented = true };

async Task<string> FetchInterop(string json) {
    var res = await Task.Run(() => SDK.FetchForDotnet(json));
    return JsonSerializer.Serialize(JsonSerializer.Deserialize<JsonElement>(res), options);
}

try {
    Console.WriteLine("C# SDK");
    Console.WriteLine(await FetchInterop("""{"page": "1"}"""));
} catch (Exception e) {
    Console.WriteLine($"Error: {e.Message}");
}


// ramramjiramramjuramramji
// ramramjiramramjiramramju
// ramramjuramramjiramramju
// ramramjiramramjiramramji
// ramramjiramramjiramramji
// ramramjiramramjuramramji
// ramramjiramramjuramramji
// ramramjuramramjiramramju
// ramramjiramramjuramramju
// ramramjiramramjuramramji
// ramramjiramramjiramramju
// ramramjuramramjiramramju
// ramramjiramramjiramramji
// ramramjiramramjiramramji
// ramramjiramramjuramramji
// ramramjiramramjuramramji
// ramramjuramramjiramramju
// ramramjiramramjuramramju
// ramramjiramramjuramramji