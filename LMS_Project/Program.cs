using BOL;
using BOL.Data;
using DAL;
using LMS_Project.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.CodeAnalysis.MSBuild;
using Microsoft.EntityFrameworkCore;
using System.IO;
using System.Security.Principal;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.AddDatabaseDeveloperPageExceptionFilter();

var str = builder.Configuration.GetConnectionString("constr");
builder.Services.AddDbContext<LMSDB_identityContext>(Options => Options.UseSqlServer(str));

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<LMSDB_identityContext>();
builder.Services.AddControllersWithViews();

//================================
builder.Services.AddScoped<ICategory, CategoryDAL>();
builder.Services.AddScoped<ICourse, CourseDAL>();
builder.Services.AddScoped<IFileData,FileDAL>();
builder.Services.AddScoped<ILecture, LectureDAL>();
builder.Services.AddScoped<IUser, UserDAL>();


//=============================



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
