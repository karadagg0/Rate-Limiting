using Microsoft.AspNetCore.RateLimiting;
using System.Threading.RateLimiting;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle;
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

#region Fixed Window Alghoritm
//It is an algorithm that limits requests to fixed values ​​in a fixed time interval

// In a 10-second window, a maximum of 5 requests are allowed. If more than 5 requests occur within 10 seconds, the excess requests are queued.
// The system processes the oldest requests first and returns responses accordingly.

/*builder.Services.AddRateLimiter(options =>
{
    options.AddFixedWindowLimiter("FixedWindow", _options =>
    {
        _options.Window = TimeSpan.FromSeconds(10);
        _options.PermitLimit = 5;
        _options.QueueLimit = 2;
        _options.QueueProcessingOrder = QueueProcessingOrder.OldestFirst;
    });
});*/

#endregion

#region Sliding Window Alghoritm
//The Sliding Window rate-limiting algorithm tracks requests within a moving time window divided into segments. As time passes, the window slides forward, removing old requests and adding new ones.
//It smooths rate-limiting by allowing requests to "borrow" from previous segments, avoiding sudden cut-offs.
/*builder.Services.AddRateLimiter(options =>
{
    options.AddSlidingWindowLimiter("SlidingWindow", _options =>
    {
        _options.Window = TimeSpan.FromSeconds(12);
        _options.PermitLimit = 3;
        _options.QueueLimit = 2;
        _options.QueueProcessingOrder = QueueProcessingOrder.OldestFirst;
        _options.SegmentsPerWindow = 2;
    });
});*/

#endregion

#region Concurrency Alghoritm
/*builder.Services.AddRateLimiter(options =>
{
    options.AddConcurrencyLimiter("Concurrency", _options =>
    {
        _options.PermitLimit = 5;
        _options.QueueLimit = 2;
        _options.QueueProcessingOrder = QueueProcessingOrder.OldestFirst;
    });
});
*/
#endregion

#region Token Bucket Alghoritm
//The Token Bucket algorithm is a rate-limiting mechanism that controls the amount of data or requests processed over time. Tokens are added to a bucket at a constant rate, and each request requires a token to be processed.
//If the bucket has no tokens, the request is delayed or rejected until tokens are replenished.
builder.Services.AddRateLimiter(options =>
{
    options.AddTokenBucketLimiter("TokenBucket", _options =>
    {
        _options.TokenLimit = 10;
        _options.TokensPerPeriod = 5;
        _options.ReplenishmentPeriod = TimeSpan.FromSeconds(10);
        _options.QueueProcessingOrder = QueueProcessingOrder.OldestFirst;
        _options.QueueLimit = 2;
    });
});

#endregion


var app = builder.Build();
app.UseRateLimiter();
app.MapControllers();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.Run();  


