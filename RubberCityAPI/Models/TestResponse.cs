namespace RubberCityAPI.Models
{
    public class TestResponse
    {
        public string message { get; set; }

        public TestResponse(string text)
        {
            message = text;
        }
    }
}
