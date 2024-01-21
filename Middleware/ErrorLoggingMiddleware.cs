namespace AuthenticationAPI.Middleware
{
    public class ErrorLoggingMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorLoggingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                // Log the exception to a file
                await LogToFile(ex);
                throw; // Optional: depending on whether you want to propagate the error or handle it
            }
        }

        private async Task LogToFile(Exception ex)
        {
            var logFilePath = "logs.txt";
            var message = $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] Error: {ex.Message}{Environment.NewLine}{ex.StackTrace}{Environment.NewLine}";

            // Append the error message to the logs.txt file
            // The 'await using' statement ensures the file is properly closed after writing
            await using (var streamWriter = new StreamWriter(logFilePath, true))
            {
                await streamWriter.WriteLineAsync(message);
            }
        }

    }

}
