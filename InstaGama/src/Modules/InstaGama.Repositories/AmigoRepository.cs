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
    public class AmigoRepository : IAmigoRepository
    {
        private readonly IConfiguration _configuration;

        public AmigoRepository(IConfiguration configuration)
        {
            _configuration = configuration;

        }
       
        public async Task<int> InserirAsync(Amigo amigo)
        {
            using (var con = new SqlConnection(_configuration["ConnectionString"]))
            {
                
                var sqlCmd = @"INSERT INTO
                             AMIGO(UsuarioId, 
                                    UsuarioAmigoId)
                             VALUES(@usuarioId,
                                    @usuarioAmigoId);
                             SELECT scope_identity();";

                using (var cmd = new SqlCommand(sqlCmd, con))
                {
                     cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("usuarioId", amigo.UsuarioId);
                    cmd.Parameters.AddWithValue("usuarioAmigoId", amigo.UsuarioAmigoId);

                    con.Open();
                    var id = await cmd
                                    .ExecuteScalarAsync()
                                    .ConfigureAwait(false);
                    return int.Parse(id.ToString());
                }

            }
        }

        //retornar uma lista de amigos
        public async Task<List<Amigo>> ObterListaAmigoPorIdAsync(int usuarioId)
        {
            using (var con = new SqlConnection(_configuration["ConnectionString"]))
            {
                //comando de retorno de todos os amigos pelo Id do Usuario principal
                var sqlCmd = @$"SELECT a.id, a.UsuarioId, a.UsuarioAmigoId 
                                FROM Amigo a
                                WHERE a.UsuarioId='{usuarioId}';";


                using (var cmd = new SqlCommand(sqlCmd, con))
                {
                    //Atribuindo os valores para o parametro - preparando para recupear as inf
                    cmd.CommandType = CommandType.Text;
                    
                    //executar a operação
                    con.Open();
                    var reader = await cmd
                                    .ExecuteReaderAsync()
                                    .ConfigureAwait(false);
                    var listaAmigos = new List<Amigo>();

                    while (reader.Read())
                    {
                        var amigo = new Amigo(int.Parse(reader["UsuarioId"].ToString()), 
                                              int.Parse(reader["UsuarioAmigoId"].ToString()),
                                              int.Parse(reader["UsuarioAmigoId"].ToString()));

                        listaAmigos.Add(amigo);
                    }
                    return listaAmigos;
                }
            }

        }
    }
}
