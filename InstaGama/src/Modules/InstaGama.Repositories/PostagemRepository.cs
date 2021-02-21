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

        public async Task AtualizarAsync(int id, Postagem postagem)
        {
            try
            {
                using (var con = new SqlConnection(_configuration["ConnectionString"]))
                {
                    var sqlCmd = $@"UPDATE Postagem SET Texto = @texto,                                            
                                       WHERE id = {postagem.Id}";

                    using (var cmd = new SqlCommand(sqlCmd, con))
                    {
                        cmd.CommandType = CommandType.Text;

                        cmd.Parameters.AddWithValue("texto", postagem.Texto);
                        
                        

                        con.Open();
                        await cmd
                                        .ExecuteScalarAsync()
                                        .ConfigureAwait(false);
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task DeleteAsync(int id)
        {
            using (var con = new SqlConnection(_configuration["ConnectionString"]))
            {
                var sqlCmd = $@"DELETE from Postagem  WHERE id = {id}";

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

        public async Task<Postagem> PegarPostagemIdAsync(int postagemId)
        {
            using (var con = new SqlConnection(_configuration["ConnectionString"]))
            {
                var sqlCmd = @$"SELECT *
                                FROM 
	                                Postagem
                                WHERE 
	                                Id= '{postagemId}'";

                using (var cmd = new SqlCommand(sqlCmd, con))
                {
                    cmd.CommandType = CommandType.Text;
                    con.Open();

                    var reader = await cmd
                                        .ExecuteReaderAsync()
                                        .ConfigureAwait(false);

                    while (reader.Read())
                    {
                        var postagem = new Postagem(reader["Texto"].ToString(), 
                                             int.Parse(reader["usuarioId"].ToString())
                                                    );
                        return postagem;

                    }

                    return default;
                }
            }
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
                    cmd.Parameters.AddWithValue("criacao", postagem.Criacao);

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
                var sqlCmd = @$"SELECT p.UsuarioId, p.texto, p.criacao 
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

        public async Task<List<Postagem>> ObterListaPostagem()
        {
            using (var con = new SqlConnection(_configuration["ConnectionString"]))
            {
                var sqlCmd = @$"SELECT p.UsuarioId, p.texto, p.criacao 
                                   FROM POSTAGEM p ';";


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


    }
}
