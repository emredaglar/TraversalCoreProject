using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using BusinessLayer.Container;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using DocumentFormat.OpenXml.Office2016.Drawing.ChartDrawing;
using DTOLayer.DTOs.AnnouncementDTOs;
using EntityLayer.Concrete;
using FluentValidation;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc.Razor;
using TraversalCoreProject.CQRS.Handlers.DestinationHandlers;
using TraversalCoreProject.CQRS.Handlers.GuideHandlers;
using TraversalCoreProject.Mapping.AutoMapperProfile;
using TraversalCoreProject.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<GetAllDestinationQueryHandler>();
builder.Services.AddScoped<GetDestionationByIDQueryHandler>();
builder.Services.AddScoped<CreateDestinationCommandHandler>();
builder.Services.AddScoped<RemoveDestinationHandler>();
builder.Services.AddScoped<UpdateDestinationCommandHandler>();
builder.Services.AddScoped<GetAllGuideHandler>();

builder.Services.AddMediatR(typeof(Program));

// Add services to the container.
builder.Services.AddDbContext<Context>();
builder.Services.AddIdentity<AppUser, AppRole>()
	.AddEntityFrameworkStores<Context>()
	.AddErrorDescriber<CustomIdentityValidator>();

builder.Services.AddHttpClient();

//Extensions Ekleme----------------------------
Extensions.ContainerDependencies(builder.Services);
Extensions.CustomValidator(builder.Services);
//Extensions Ekleme----------------------------

builder.Services.AddAutoMapper(typeof(MapProfile));

builder.Services.AddControllersWithViews().AddFluentValidation();

builder.Services.AddMvc(config =>
{
	var policy = new AuthorizationPolicyBuilder()
		.RequireAuthenticatedUser()
		.Build();
	config.Filters.Add(new AuthorizeFilter(policy));
});

builder.Services.AddLocalization(opt =>
{
	opt.ResourcesPath = "Resources";
});
builder.Services.AddMvc().AddMvcLocalization(LanguageViewLocationExpanderFormat.Suffix).AddDataAnnotationsLocalization();
builder.Services.ConfigureApplicationCookie(options =>
{
	options.LoginPath = "/Login/SignIn/";
});
//Loglama----------------------
builder.Services.AddLogging(log =>
{
	log.ClearProviders();
	log.AddFile($"{Directory.GetCurrentDirectory()}\\LogFile\\log.txt", LogLevel.Error);
});
//Loglama----------------------
builder.Services.AddControllersWithViews();

var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Home/Error");
	app.UseHsts();
}
else
{
	app.UseDeveloperExceptionPage();
}


app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseAuthentication();
app.UseRouting();
app.UseAuthorization();
var suppertedCultures = new[] { "en", "fr", "es", "gr", "tr", "de" };
var localizationOptions=new RequestLocalizationOptions().SetDefaultCulture(suppertedCultures[4]).AddSupportedCultures(suppertedCultures).AddSupportedUICultures(suppertedCultures);
app.UseRequestLocalization(localizationOptions);
// Area ve Default Route sýrasý önemli!
app.UseEndpoints(endpoints =>
{
	endpoints.MapControllerRoute(
		name: "areas",
		pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

	endpoints.MapControllerRoute(
		name: "default",
		pattern: "{controller=Home}/{action=Index}/{id?}");
});

app.Run();
