using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;
using System.Text;

namespace apl_movimentos_manuais.Services
{
    public class ConfigureSwaggerOptions : IConfigureOptions<SwaggerGenOptions>
    {
        #region Propriedades

        readonly IApiVersionDescriptionProvider _provider;

        #endregion

        #region Construtor

        public ConfigureSwaggerOptions(IApiVersionDescriptionProvider provider)
        {
            _provider = provider;
        }

        #endregion

        #region Metodos

        public void Configure(SwaggerGenOptions options)
        {
            foreach (var description in _provider.ApiVersionDescriptions)
            {
                options.SwaggerDoc(description.GroupName, CreateInfoForApiVersion(description));
            }
        }

        private static Info CreateInfoForApiVersion(ApiVersionDescription description)
        {
            var info = new Info()
            {
                Title = "API - Movimentos Manuais",
                Version = description.ApiVersion.ToString(),
                Description = "Esta API faz parte do curso REST com ASP.NET Core WebApi.",
                Contact = new Contact() { Name = "André Moura", Email = "andre.vinicius.moura@outlook.com" },
                TermsOfService = "https://opensource.org/linceses/MIT",
                License = new License() { Name = "MIT", Url = "https://opensource.org/linceses/MIT" }
            };

            if (description.IsDeprecated)
            {
                info.Description += "- Esta versão está obsoleta!";
            }

            return info;
        }

        #endregion

    }
}
