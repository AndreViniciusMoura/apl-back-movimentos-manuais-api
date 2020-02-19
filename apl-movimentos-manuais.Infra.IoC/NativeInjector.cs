using apl_movimentos_manuais.Domain.Interfaces.Respositories;
using apl_movimentos_manuais.Domain.Interfaces.Services;
using apl_movimentos_manuais.Infra.Data.Repositories;
using apl_movimentos_manuais.Infra.Data.UnitOfWork;
using apl_movimentos_manuais.Infra.Persistence;
using apl_movimentos_manuais.Infra.Persistence.Context;
using apl_movimentos_manuais.Services;
using apl_movimentos_manuais.Services.Notificacoes;
using apl_movimentos_manuais.Services.Produtos;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace apl_movimentos_manuais.Infra.IoC
{
    public static class NativeInjector
    {
        public static IServiceCollection AddNativeInjector(this IServiceCollection services)
        {

            services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();

            #region Services

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<DbContext, MovimentosManuaisContext>();
            services.AddScoped<INotificadorService, NotificadorService>();
            //services.AddScoped(typeof(IMovimentoService<>), typeof(MovimentoService<>));
            //services.AddScoped<IMovimentoManualService, MovimentoManualService>();
            services.AddScoped<IProdutoService, ProdutoService>();
            //services.AddScoped<IProdutoCosifService, ProdutoCosifService>();

            #endregion

            #region Repositories

            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            services.AddScoped<IMovimentoManualRepository, MovimentoManualRepository>();

            #endregion

            return services;
        }
    }
}

