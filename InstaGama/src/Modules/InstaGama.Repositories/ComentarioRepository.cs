using InstaGama.Domain.Entities;
using InstaGama.Domain.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace InstaGama.Repositories
{
    public class ComentarioRepository : IComentarioRepository
    {
        private readonly IConfiguration _configuracao;
        public ComentarioRepository(IConfiguration configuracao)
        {
            _configuracao = configuracao;
        }

        public async Task<int> InserirAsync(Comentario comentario)
        {
            using (var con = new SqlConnection(_configuracao["ConnectionString"]))
            {
                var sqlCmd = @"INSERT INTO COMENTARIO(
                                       UsuarioId,
                                       PostagemId,
                                       Texto,
                                       Criacao)
                                VALUES (@UsuarioId,
                                       @PostagemId,
                                       @Texto,
                                       @Criacao);
                                SELECT scope_IDENTITY();";

                using (var cmd = new SqlCommand(sqlCmd, con))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("UsuarioId", comentario.UsuarioId);
                    cmd.Parameters.AddWithValue("PostagemId", comentario.PostagemId);
                    cmd.Parameters.AddWithValue("Texto", comentario.Texto);
                    cmd.Parameters.AddWithValue("Criacao", comentario.Criacao);

                    con.Open();
                    var id = await cmd
                                    .ExecuteScalarAsync()
                                    .ConfigureAwait(false);
                    return int.Parse(id.ToString());
                }
            }
        }

        public async Task<List<Comentario>> ObterListaComentarioPorPostagemIdAsync(int postagemId)
        {
            using (var con = new SqlConnection(_configuracao["ConnectionString"]))
            {
                var sqlCmd = $@"SELECT Id,
                                       UsuarioId,
                                       PostagemId,
                                       Texto,
                                       Criacao
                                    FROM
                                       COMENTARIO
                                    WHERE
                                       PostagemId= '{postagemId}'";
                using (var cmd = new SqlCommand(sqlCmd, con))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("id", postagemId);
                    con.Open();

                    var cabecalho = await cmd
                                           .ExecuteReaderAsync()
                                           .ConfigureAwait(false);

                    var comentariosPorPostagem = new List<Comentario>();

                    while (cabecalho.Read())
                    {
                        var comentario = new Comentario(int.Parse(cabecalho["Id"].ToString()),
                                                   int.Parse(cabecalho["PostagemId"].ToString()),
                                                   int.Parse(cabecalho["UsuarioId"].ToString()),
                                                   cabecalho["Texto"].ToString(),
                                                   DateTime.Parse(cabecalho["Criacao"].ToString()));

                        comentariosPorPostagem.Add(comentario);


                    }
                    return comentariosPorPostagem;
                }
            }

        }


        public async Task DeletarComentario(int id)
        {

            using (var con = new SqlConnection(_configuracao["ConnectionString"]))
            {

                var sqlCmd = $@"DELETE 
                               FROM COMENTARIO
                               WHERE id ='{id}'";

                using (var cmd = new SqlCommand(sqlCmd, con))
                {
                    cmd.CommandType = CommandType.Text;
                    con.Open();

                    await cmd
                        .ExecuteScalarAsync()
                        .ConfigureAwait(false);

                }


            }
            
        }

        
    }
}

