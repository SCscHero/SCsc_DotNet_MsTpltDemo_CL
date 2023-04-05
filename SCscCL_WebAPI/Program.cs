
using System;
using Microsoft.OpenApi.Models;
using SCscCL_WebAPI.Model;
using Swashbuckle.AspNetCore.Filters;
using System.Reflection;
using System.Runtime.InteropServices;
using SCscCL_WebAPI.Extension.CustomMiddlewares;
using SCscCL_WebAPI;

var builder = WebApplication.CreateBuilder(args);
var ApiName = "SCscCL_WebAPI";
var basePath = AppContext.BaseDirectory;



// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    // ������ȫ���İ汾�����ĵ���Ϣչʾ
    typeof(ApiVersions).GetEnumNames().ToList().ForEach(version =>
    {
        c.SwaggerDoc(version, new OpenApiInfo
        {
            Version = version,
            Title = $"{ApiName} �ӿ��ĵ�����{RuntimeInformation.FrameworkDescription}",
            Description = $"{ApiName} HTTP API " + version,
            Contact = new OpenApiContact { Name = ApiName, Email = "scschero@foxmail.com" },
            //License = new OpenApiLicense { Name = ApiName + " �ٷ��ĵ�", Url = new Uri("") }
        });
        c.OrderActionsBy(o => o.RelativePath);
    });

    try
    {
        var xmlPath = Path.Combine(basePath, $"SCscCL_WebAPI.xml");
        c.IncludeXmlComments(xmlPath, true);
    }
    catch (Exception ex)
    {
        Console.WriteLine("xml missing!");
    }

    // ������ȨС��
    c.OperationFilter<AddResponseHeadersFilter>();
    c.OperationFilter<AppendAuthorizeToSummaryOperationFilter>();

    // ��header�����token�����ݵ���̨
    c.OperationFilter<SecurityRequirementsOperationFilter>();

    // Jwt Bearer ��֤�������� oauth2
    c.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
    {
        Description = "JWT��Ȩ(���ݽ�������ͷ�н��д���) ֱ�����¿�������Bearer {token}��ע������֮����һ���ո�\"",
        Name = "Authorization",//jwtĬ�ϵĲ�������
        In = ParameterLocation.Header,//jwtĬ�ϴ��Authorization��Ϣ��λ��(����ͷ��)
        Type = SecuritySchemeType.ApiKey
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
    app.UseSwagger();
    // ��swagger��ҳ�����ó������Զ����ҳ�棬�ǵ�����ַ�����д����{��Ŀ��.index.html}


    //TODO:??????????//
        //GetType().GetTypeInfo().Assembly.
    app.UseSwaggerMildd(() => new WeatherForecast().GetType().GetTypeInfo().Assembly.GetManifestResourceStream("SCscCL_WebAPI.index.html"));

//}
app.UseStaticFiles();
app.UseCookiePolicy();
app.UseStatusCodePages();


//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
