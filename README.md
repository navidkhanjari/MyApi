#تکنولوژی، ابزار ها و قابلیت ها
لایه بندی اصولی پروژه (Project Layering and Architecture) -  Repository و UOW 
احراز هویت (Authentication)
-ASP.NET Core Identity : احراز هویت توسط Identity 
-(Json Web Token) JWT : احراز هویت توسط Jwt + یکپارچه سازی آن با Identity
-(Json Web Encryption) JWE : ایمن سازی توکن ها بوسیله رمزنگاری توکن (JWE)
-Security Stamp : جلوگیری از اعتبارسنجی توکن به هنگام تغییر دسترسی های کاربر جهت امنیت بیشتر
-Claims : کار با Claim ها و تولید خودکار آنها توسط ClaimsFactory
-Logging (ثبت خطا ها)
-Elmah : استفاده از Elmah برای لاگ خطا ها در Memory, XML File و Database
-NLog : استفاده از NLog برای لاگ خطا ها در File و Console
-Custom Middleware : میدلویر سفارشی جهت لاگ تمامی خطا (Exception) ها
-Custom Exception : Exception برای مدیریت ساده تر خطا ها
-Sentry : ثبت خطا ها در سیستم مدیریت لاگ sentry.io 
#تزریق وابستگی (Dependency Injection)
-ASP.NET Core IOC Container : استفاده از Ioc container داخلی Asp Core
-Autofac : استفاده از محبوب ترین کتابخانه Autofac (Ioc Container)
-Auto Registeration : ثبت خودکار سرویس ها توسط یک تکنیک خلاقانه با کمک Autofac
#ارتباط با دیتابیس (Data Access)
-Entity Framework Core : استفاده از EF Core
-Auto Entity Registration : ثبت Entity های DbContext به صورت خودکار توسط Reflection
-Pluralizing Table Name : جمع بندی نام جداول EF Core به صورت خودکار توسط کتابخانه Pluralize.NET و Reflection
-Automatic Configuration : اعمال کانفیگ های EntityTypeConfiguration (FluentApi) به صورت خودکار توسط Reflection
-Sequential Guid : بهینه سازی مقدار دهی identity برای Guid به صورت خودکار توسط Reflection
-Repository : Repository در EF Core
-Data Intitializer :Seed 
-Auto Migrate : آپدیت Database به آخرین Migration به صورت خودکار
-Clean String : اصلاح و یک دست سازی حروف "ی" و "ک" عربی به فارسی و encoding اعداد فارسی در DbContext به صورت خودکار به هنگام SaveChanges
-Versioning 
#ابزار (Swashbuckle) Swagger
-Swagger UI : ساخت یک ظاهر شکیل به همراه داکیومنت Aciton ها و Controller های پروژه و امکان تست API ها توسط Swagger UI
-Versioning : یکپارچه سازی اصولی Swagger با سیستم نسخه گذاری (Versioning)
-JWT Authentication : یکپارچه سازی Swagger با سیستم احراز هویت بر اساس Jwt
-OAuth Authentication : یکپارچه سازی Swagger با سیستم احراز هویت بر اساس OAuth
-Auto Summary Document Generation : تولید خودکار داکیومنت (توضیحات) برای API های پروژه
-Advanced Customization : سفارشی سازی های پیشرفته در Swagger
#دیگر قابلیت ها
-API Standard Resulting : استاندارد سازی و یک دست سازی خروجی API ها توسط ActionFilter
-Automatic Model Validation : اعتبار سنجی خودکار
-AutoMapper : جهت Mapping اشیاء توسط کتابخانه محبوب AutoMapper
-Auto Mapping : سفارشی سازی وایجاد یک معماری حرفه ای برای Mapping اشیا توسط Reflection
-Generic Controller : ساخت کنترلر برای عملیات CRUD بدون کد نویسی توسط ارث بری از CrudController
-Site Setting : مدیریت تنظیمات پروژ توسط Configuration و ISnapshotOptions
-Postman : آشنایی و کار با Postman جهت تست API ها
-Minimal Mvc : حذف سرویس های اضافه MVC برای افزایش پرفرمنس در API نویسی
