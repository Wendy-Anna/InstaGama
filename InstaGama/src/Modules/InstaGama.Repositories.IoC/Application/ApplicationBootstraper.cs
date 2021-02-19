using InstaGama.Application.AppAmigo.Interfaces;
using InstaGama.Application.AppAmigos;
using InstaGama.Application.AppCurtida.Interface;
using InstaGama.Application.AppPostage;
using InstaGama.Application.UsuarioApp;
using InstaGama.Application.UsuarioApp.Interface;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace InstaGama.Repositories.IoC.Application
{
    internal class ApplicationBootstraper
    {
        internal void ChildServiceRegister(IServiceCollection services)
        {
            services.AddScoped<IUsuarioAppService, UsuarioAppService>();
            services.AddScoped<IAmigoAppService, AmigoAppService>();
            services.AddScoped<ICurtidaAppService, CurtidaAppService>();

        }
    }
}
