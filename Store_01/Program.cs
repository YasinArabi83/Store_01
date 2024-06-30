using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Store_01.Models;
using Store_01.Reader;

var builder = WebApplication.CreateBuilder(args);



builder.Services.AddMvc();
builder.Services.AddRazorPages();

string? StoreCnn = builder.Configuration.GetConnectionString("StoreCnn");

builder.Services.AddDbContext<StoreContext>(c => c.UseSqlServer(StoreCnn));
builder.Services.AddDbContext<AAADbContext>(c => c.UseSqlServer(StoreCnn));
builder.Services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<AAADbContext>();

builder.Services.AddScoped<IProductReader, ProductReader>();
builder.Services.AddScoped<ITeamMemberReader, TeamMemberReader>();
builder.Services.AddScoped<IBlogReader, BlogReader>();


var app = builder.Build();
app.UseStaticFiles();
app.UseAuthentication();
app.UseAuthorization();
app.MapRazorPages();
app.MapDefaultControllerRoute();
app.Run();
