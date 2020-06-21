namespace InterviewTask.Web.App
{
    using BindingModels.Company;
    using BindingModels.Employee;
    using BindingModels.Office;
    using InterviewTask.Data;
    using InterviewTask.Data.Models.User;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using Services.Company;
    using Services.Employee;
    using Services.Mapping;
    using Services.Models.Company;
    using Services.Models.Employee;
    using Services.Models.Office;
    using Services.Models.User;
    using Services.Office;
    using Services.User;
    using System.Globalization;
    using System.Reflection;
    using ViewModels.Company;
    using ViewModels.Employee;
    using ViewModels.Office;
    using ViewModels.User;

    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<InterviewTaskDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<InterviewTaskUser, IdentityRole>()
               .AddEntityFrameworkStores<InterviewTaskDbContext>()
               .AddDefaultTokenProviders();

            services.AddControllersWithViews();
            services.AddRazorPages();

            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 3;
                options.Password.RequiredUniqueChars = 0;
                options.User.RequireUniqueEmail = true;
            });

            services.AddTransient<ICompanyService, CompanyService>();
            services.AddTransient<IOfficeService, OfficeService>();
            services.AddTransient<IEmployeeService, EmployeeService>();
            services.AddTransient<IUserService, UserService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            AutoMapperConfig.RegisterMappings(
               typeof(CompanyBindingModel).GetTypeInfo().Assembly,
               typeof(CompanyServiceModel).GetTypeInfo().Assembly,
               typeof(CompanyViewModel).GetTypeInfo().Assembly,
               typeof(OfficeViewModel).GetTypeInfo().Assembly,
               typeof(OfficeBindingModel).GetTypeInfo().Assembly,
               typeof(OfficeServiceModel).GetTypeInfo().Assembly,
               typeof(EmployeeServiceModel).GetTypeInfo().Assembly,
               typeof(EmployeeBindingModel).GetTypeInfo().Assembly,
               typeof(EmployeeViewModel).GetTypeInfo().Assembly,
               typeof(UserServiceModel).GetTypeInfo().Assembly,
               typeof(UserDetailsViewModel).GetTypeInfo().Assembly);

            CultureInfo.DefaultThreadCurrentCulture = CultureInfo.InvariantCulture;
            CultureInfo.DefaultThreadCurrentUICulture = CultureInfo.InvariantCulture;

            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                using (var context = serviceScope.ServiceProvider.GetRequiredService<InterviewTaskDbContext>())
                {
                    context.Database.EnsureCreated();

                    // context.SaveChanges();
                }
            }

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}
