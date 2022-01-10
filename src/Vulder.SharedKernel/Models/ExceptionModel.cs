using Newtonsoft.Json;

namespace Vulder.SharedKernel.Models;

public class ExceptionModel
{
    [JsonProperty("statusCode")]
    public int StatusCode { get; set; }

    [JsonProperty("error")]
    public string ErrorMessage { get; set; }
}