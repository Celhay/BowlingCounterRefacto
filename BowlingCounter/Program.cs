using BowlingCounter;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;

// var configuration =  new ConfigurationBuilder().AddJsonFile($"appsettings.json");
// var config = configuration.Build();

var game = new GameService(new LoggerFactory());

game.Start();


