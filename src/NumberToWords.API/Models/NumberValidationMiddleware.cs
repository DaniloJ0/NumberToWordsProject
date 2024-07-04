using Newtonsoft.Json;

namespace NumberToWords.API.Models
{
    public class NumberValidationMiddleware
    {
        private readonly RequestDelegate _next;

        public NumberValidationMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            if (context.Request.Path.StartsWithSegments("/NumberToWords") && context.Request.Method == "POST")
            {
                context.Request.EnableBuffering();

                using (var reader = new StreamReader(context.Request.Body, leaveOpen: true))
                {
                    var body = await reader.ReadToEndAsync();
                    context.Request.Body.Position = 0;

                    try
                    {
                        var numberRequest = JsonConvert.DeserializeObject<NumberRequest>(body);

                        if (numberRequest == null || !long.TryParse(numberRequest.Number.ToString(), out _))
                        {
                            context.Response.StatusCode = StatusCodes.Status400BadRequest;
                            await context.Response.WriteAsync("Number must be a valid long integer without points or commas.");
                            return;
                        }
                    }
                    catch (JsonException)
                    {
                        context.Response.StatusCode = StatusCodes.Status400BadRequest;
                        await context.Response.WriteAsync("Invalid JSON format.");
                        return;
                    }
                }
            }

            await _next(context);
        }
    }

}
