using InstaGama.Application.AppPostagem.Input;
using InstaGama.Application.AppPostagem.Output;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace InstaGama.Application.AppPostagem.Interfaces
{
    public interface IPostagemAppService
    {
        Task<PostagemViewModel> InserirAsync(PostagemInput postagemInput);
        Task<List<PostagemViewModel>> ObterListaPostagemPorUsuarioIdAsync(int usuarioId);
       
    }
}
