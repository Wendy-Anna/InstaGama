using InstaGama.Domain.Entities;
using InstaGama.Domain.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace InstaGama.Repositories
{
    public class PostagemRepository : IPostagemRepository
    {
        private readonly IConfiguration _configuration;

        public PostagemRepository(IConfiguration configuration)
        {
            _configuration = configuration;

        }


        public async Task<int> InserirAsync(Postagem postagem)
        {
            using (var con = new SqlConnection(_configuration["ConnectionString"]))
            {

                var sqlCmd = @"INSERT INTO
                             POSTAGEM(Texto,
                                    UsuarioId, 
                                    Criacao)
                             VALUES(@texto,
                                    @usuarioId, 
                                    @criacao);
                             SELECT scope_identity();";

                using (var cmd = new SqlCommand(sqlCmd, con))
                {
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.Parameters.AddWithValue("texto", postagem.Texto);
                    cmd.Parameters.AddWithValue("usuarioId", postagem.UsuarioId);
                    cmd.Parameters.AddWithValue("criacao", DateTime.Now);

                    con.Open();

                    var id = await cmd.ExecuteScalarAsync().ConfigureAwait(false);
                    return int.Parse(id.ToString());
                }
            }

        }
        public async Task<List<Postagem>> ObterListaPostagemPorUsuarioIdAsync(int usuarioId)
        {
            using (var con = new SqlConnection(_configuration["ConnectionString"]))
            {
                var sqlCmd = @$"SELECT p.Id, p.UsuarioId, p.texto, p.criacao 
                                   FROM POSTAGEM p
                                   WHERE p.UsuarioId='{usuarioId}';";


                using (var cmd = new SqlCommand(sqlCmd, con))
                {
                    cmd.CommandType = CommandType.Text;

                    con.Open();
                    var reader = await cmd
                                    .ExecuteReaderAsync()
                                    .ConfigureAwait(false);
                    var listaPostagem = new List<Postagem>();

                    while (reader.Read())
                    {
                        var postagem = new Postagem(int.Parse(reader["Id"].ToString()),
                                                     reader["Texto"].ToString(),
                                                     DateTime.Parse(reader["Criacao"].ToString()),
                                                     int.Parse(reader["UsuarioId"].ToString()));


                        listaPostagem.Add(postagem);
                    }
                    return listaPostagem;
                }

            }
        }

        public async Task<Postagem> ObterPostagemPorIdAsync(int postagemId)
        {
            using (var con = new SqlConnection(_configuration["ConnectionString"]))
            {
                var sqlCmd = @$"SELECT p.Id, p.UsuarioId, p.texto, p.criacao 
                                   FROM POSTAGEM p
                                   WHERE p.Id = '{postagemId}';";


                using (var cmd = new SqlCommand(sqlCmd, con))
                {

                    cmd.CommandType = CommandType.Text;


                    con.Open();
                    var reader = await cmd
                                    .ExecuteReaderAsync()
                                    .ConfigureAwait(false);

                    while (reader.Read())
                    {
                        var postagem = new Postagem(int.Parse(reader["Id"].ToString()),
                                         reader["Texto"].ToString(),
                                         DateTime.Parse(reader["Criacao"].ToString()),
                                         int.Parse(reader["UsuarioId"].ToString()));

                        return postagem;
                    }
                    return default;
                }

            }
        }

      
    }
}
