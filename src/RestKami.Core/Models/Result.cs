namespace RestKami.Core.Models
{
    public sealed class Result
    {
        public string Url { get; set; }

        public int StatusCode { get; set; }

        public bool Value { get; set; }

        public string ErrorMessage { get; set; }

        public void SetResult(bool value, int statusCode)
        {
            Value = value;
            StatusCode = statusCode;
        }

        public void SetError(string errorMessage)
        {
            Value = false;
            ErrorMessage = errorMessage;
        }
    }
}