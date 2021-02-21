using InstaGama.Domain.Entities;
using InstaGama.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace InstaGama.Repositories
{
    public class CurtidaRepository : ICurtidaRepository
    {

        private readonly IConfiguration _configuration;

        public CurtidaRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        public async Task<int> PegarQuantidadeCurtidasIdAsync(int postagemId)
        {
            using (var con = new SqlConnection(_configuration["ConnectionString"]))
            {
                var sqlCmd = @$"SELECT
                                    COUNT(*) AS Quantidade
                                FROM 
	                                Curtida
                                WHERE 
	                                PostagemId='{postagemId}';";

                using (var cmd = new SqlCommand(sqlCmd, con))
                {
                    cmd.CommandType = CommandType.Text;
                    con.Open();

                    var reader = await cmd
                                        .ExecuteReaderAsync()
                                        .ConfigureAwait(false);

                    while (reader.Read())
                    {
                        return int.Parse(reader["Quantidade"].ToString());
                    }

                    return default;
                }
            }
        }

        public async Task<int> InserirAsync(Curtida curtida)
        {
            using (var con = new SqlConnection(_configuration["ConnectionString"]))
            {

                var sqlCmd = @"INSERT INTO 
                                Curtida(UsuarioId, 
                                        PostagemId)
                                VALUES (@usuarioId,
                                        @postagemId);
                                SELECT scope_identity();";

                using (var cmd = new SqlCommand(sqlCmd, con))
                {
                    cmd.CommandType = CommandType.Text;

                    cmd.Parameters.AddWithValue("usuarioId", curtida.UsuarioId);
                    cmd.Parameters.AddWithValue("postagemId", curtida.PostagemId);

                    con.Open();
                    var id = await cmd
                                    .ExecuteScalarAsync()
                                    .ConfigureAwait(false);

                    return int.Parse(id.ToString());

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







        public Task ApagarAsync(int id)
        {
            throw new NotImplementedException();
        }


        public Task<Curtida> PegarUsuarioIdEPostagemIdAsync(int usuarioId, int postagemId)
        {
            throw new NotImplementedException();
        }

        public Task PegarUsuarioIdEPostagemIdAsync(object usuarioId, int postagemId)
        {
            throw new NotImplementedException();
        }

        
    }
}  
    
