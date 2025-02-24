using DesignPatternsPlayground;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
ProgramPreparation.PrepareServices(ref builder);
ProgramPreparation.RunApp(builder);
