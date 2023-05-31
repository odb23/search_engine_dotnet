using Quartz;
using SearchEngine.API;
using SearchEngine.API.ExtractionJob;
using SearchEngine.API.Interfaces;
using SearchEngine.API.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<IDocHandler, DocParseHandler>();
builder.Services.AddSingleton<IDocumentService, DocumentService>(); 
builder.Services.AddSingleton<IKeywordService, KeywordService>();
builder.Services.AddSingleton<ISearchService, SearchService>();
builder.Services.AddSingleton<IRanker, Ranker>();
builder.Services.AddSingleton<IIndexer, Indexer>();

// Local Data Storage configuration.
builder.Services.AddSingleton<IDbContext, DbContext>();

builder.Services.AddQuartz(q =>
{
    q.UseMicrosoftDependencyInjectionJobFactory();

    var jobKey = new JobKey("FileContentExtractorJob");
    q.AddJob<FileContentExtractorJob>(opt=> opt.WithIdentity(jobKey));

    q.AddTrigger(t => t
        .WithIdentity("FileContentExtractorTrigger")
        .ForJob(jobKey)
        .WithSimpleSchedule(x => x.WithIntervalInHours(2).RepeatForever()));
        //.WithCronSchedule("0 0 0/2 * * ?")); // Cron expression for every 2 hours
});

builder.Services.AddQuartzHostedService(q => q.WaitForJobsToComplete = true);


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

//var schedulerFactory = app.Services.GetRequiredService<ISchedulerFactory>();
//var scheduler = await schedulerFactory.GetScheduler();
//await scheduler.Start();

//var jobKey = new JobKey("FileContentExtractorJob");
//await scheduler.ScheduleJob(JobBuilder.Create<FileContentExtractorJob>().WithIdentity(jobKey).Build(),
//    TriggerBuilder.Create()
//        .WithIdentity("FileContentExtractorTrigger")
//        .ForJob(jobKey)
//        .Build());


app.Run();
