using InstaGama.Application.AppAmigo.Interfaces;
using InstaGama.Application.AppAmigos;

using InstaGama.Application.AppCurtida.Interface;
using InstaGama.Application.AppPostage;

using InstaGama.Application.AppPostagem;
using InstaGama.Application.AppPostagem.Interfaces;


using InstaGama.Application.AppUsuario;
using InstaGama.Application.AppUsuario.Interface;

using InstaGama.Application.UsuarioApp;
using InstaGama.Application.UsuarioApp.Interface;
using Microsoft.Extensions.DependencyInjection;

namespace InstaGama.Repositories.IoC.Application
{
    internal class ApplicationBootstraper
    {
        internal void ChildServiceRegister(IServiceCollection services)
        {
            services.AddScoped<IUsuarioAppService, UsuarioAppService>();
            services.AddScoped<ILoginAppService, LoginAppService>();
            services.AddScoped<IAmigoAppService, AmigoAppService>();

            services.AddScoped<ICurtidaAppService, CurtidaAppService>();

            services.AddScoped<IPostagemAppService, PostagemAppService>();


        }
    }
}
