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

        public async Task DeleteAsync(int id)
        {
            using (var con = new SqlConnection(_configuracao["ConnectionString"]))
            {
                var sqlCmd = $@"DELETE from Comentario  WHERE id = {id}";

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
                    con.Open();

                    var id = await cmd.ExecuteReaderAsync().ConfigureAwait(false);
                    return int.Parse(id.ToString());
                }
            }
        }

        public async Task<Comentario> PegarComentarioIdAsync(int id)
        {
            using (var con = new SqlConnection(_configuracao["ConnectionString"]))
            {
                var sqlCmd = @$"SELECT * FROM
	                                Comentario
                                WHERE 
	                                PostagemId= '{id}'";

                using (var cmd = new SqlCommand(sqlCmd, con))
                {
                    cmd.CommandType = CommandType.Text;
                    con.Open();

                    var reader = await cmd
                                        .ExecuteReaderAsync()
                                        .ConfigureAwait(false);


                    while (reader.Read())
                    {
                        var comentario = new Comentario(int.Parse(reader["Id"].ToString()),
                                                    int.Parse(reader["PostagemId"].ToString()),
                                                    int.Parse(reader["UsuarioId"].ToString()),
                                                    reader["Texto"].ToString(),
                                                    DateTime.Parse(reader["Criacao"].ToString()));
                        return comentario;
                    }

                    return default;
                }
            }

        }

        public async Task<List<Comentario>> PegarPostagemIdAsync(int postagemId)
        {
            using (var con = new SqlConnection(_configuracao["ConnectionString"]))
            {
                var sqlCmd = $@"SELECT Id,
                                       UsuarioId,
                                       PostagemId,
                                       Texto,
                                       Criacao
                             FROM
                                       Comentarios
                             WHERE
                                       PostagemId= '{postagemId}'";
                using (var cmd = new SqlCommand(sqlCmd, con))
                {
                    cmd.CommandType = CommandType.Text;
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
    }
}

