using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Pass_It_Out.Authentication;
using Pass_It_Out.Context;
using Pass_It_Out.Data;
using Pass_It_Out.Services;
using Pass_It_Out.Services.FriendServices;
using Pass_It_Out.Services.MessageServices;
using Pass_It_Out.Services.PostServices;
using Pass_It_Out.Services.UserServices;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<Pass_It_Out_CTX>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("SQLConnectionString")));
builder.Services.AddRazorPages();
builder.Services.AddScoped<IPass_It_Out, Pass_It_Out_Service>();
builder.Services.AddScoped<IUser, UserService>();
builder.Services.AddScoped<IPost,PostService>();
builder.Services.AddScoped<IFriend, FriendService>();
builder.Services.AddScoped<IMessage,MessageService>();
builder.Services.AddScoped<UserAuthentication>();

builder.Services.AddSession(opt=>
{
    opt.IdleTimeout = TimeSpan.FromMinutes(30);
    opt.Cookie.Name = "UserId";
    opt.Cookie.HttpOnly = true;
    opt.Cookie.IsEssential = true;
});

//builder.Services.AddMvc(options =>
//{
//    options.Filters.Add(typeof(UserAuthentication));
//});


//builder.Services.AddMvc(options =>
//{
//    options.Filters.AddService<UserAuthentication>();
//});

var app = builder.Build();

var ConBuilder = new ConfigurationBuilder();
ConBuilder.SetBasePath(Directory.GetCurrentDirectory());
ConBuilder.AddJsonFile("appsettings.json");
IConfiguration configurationmanager = ConBuilder.Build();


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
app.UseSession();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=User}/{action=UserLogin}/{id?}");
app.MapRazorPages();

app.Run();
