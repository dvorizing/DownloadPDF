using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

// הוספת שירותים למיכל
builder.Services.AddControllers(); // מאפשר להשתמש בקונטרולים
builder.Services.AddEndpointsApiExplorer(); // מאפשר חקר של נקודות קצה
builder.Services.AddSwaggerGen(); // מאפשר ליצור תיעוד אוטומטי ל-API

var app = builder.Build();

// הגדרת צינור הבקשות HTTP
if (app.Environment.IsDevelopment())
{
    app.UseSwagger(); // מפעיל את Swagger
    app.UseSwaggerUI(); // מפעיל את ממשק המשתמש של Swagger
}

app.UseHttpsRedirection(); // מפנה ל-HTTPS
app.UseAuthorization(); // מוסיף תמיכה באימות

app.MapControllers(); // מפה את הקונטרולים

app.Run(); // запускает приложение
