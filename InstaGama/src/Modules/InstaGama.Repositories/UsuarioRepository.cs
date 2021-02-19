using InstaGama.Domain.Entities;
using InstaGama.Domain.Interfaces;
using System;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace InstaGama.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly IConfiguration _configuration;

        public UsuarioRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<Usuario> PegarId(int id)
        {
            //criando o Id do usuário
            using (var con = new SqlConnection(_configuration["ConnectionString"]))
            {

                var sqlCmd = @$"SELECT 
                                u.Id, 
                                u.Nome, 
                                u.Email, 
                                u.Senha,
                                u.DataNascimento,
                                u.Foto,
                                g.Id as GeneroId, g.Descricao
                                    FROM Usuario U
                                    INNER JOIN Genero g ON g.Id = u.GeneroId
                                    WHERE u.Id= '{id}'";

                using (var cmd = new SqlCommand(sqlCmd, con))
                {
                    cmd.CommandType = CommandType.Text;
                    con.Open();

                    var reader = await cmd
                                           .ExecuteReaderAsync()
                                           .ConfigureAwait(false);

                    while (reader.Read())
                    {
                        var usuario = new Usuario(reader["Nome"].ToString(),
                                                        reader["Email"].ToString(),
                                                        reader["Senha"].ToString(),
                                            DateTime.Parse(reader["DataNascimento"].ToString()),
                                            new Genero(reader["Descricao"].ToString()),
                                            reader["Foto"].ToString());

                        usuario.SetId(int.Parse(reader["id"].ToString()));
                        usuario.Genero.SetId(int.Parse(reader["GeneroId"].ToString()));

                        return usuario;
                    }

                    return default;
                }
            }
        }


        public async Task<Usuario> PegarLoginAsync(string login)
        {
            using (var con = new SqlConnection(_configuration["ConnectionString"]))
            {
                var sqlCmd = @$"SELECT u.Id,
	                                 u.Nome,
	                                 u.Email,
	                                 u.Senha,
                                     u.DataNascimento,
                                     u.Foto,
	                                 g.Id as GeneroId,
	                                 g.Descricao
                                FROM 
	                                Usuario u
                                INNER JOIN 
	                                Genero g ON g.Id = u.GeneroId
                                WHERE 
	                                u.Email= '{login}'";

                using (var cmd = new SqlCommand(sqlCmd, con))
                {
                    cmd.CommandType = CommandType.Text;
                    con.Open();

                    var reader = await cmd
                                        .ExecuteReaderAsync()
                                        .ConfigureAwait(false);

                    while (reader.Read())
                    {
                        var usuario = new Usuario(reader["Nome"].ToString(),
                                            DateTime.Parse(reader["DataNascimento"].ToString()),
                                            new Genero(reader["Descricao"].ToString()),
                                            reader["Foto"].ToString());

                        usuario.InformacaoLoginUsuario(reader["Email"].ToString(), reader["Senha"].ToString());
                        usuario.SetId(int.Parse(reader["id"].ToString()));
                        usuario.Genero.SetId(int.Parse(reader["GeneroId"].ToString()));

                        return usuario;
                    }

                    return default;
                }
            }
        }


        public async Task<int>  InserirAsync(Usuario usuario)
        {
            using(var con = new SqlConnection(_configuration["ConnectionString"]))
            {
                var sqlCmd = @"INSERT INTO
                                  Usuario (GeneroId, Nome, Email, Senha, DataNascimento, Foto)
                                  VALUES (@generoId, @nome, @email, @senha,  @dataNascimento, @foto); SELECT scope_identity();";

                using (var cmd = new SqlCommand(sqlCmd, con))
                {
                    cmd.CommandType = CommandType.Text;

                    cmd.Parameters.AddWithValue("generoId", usuario.Genero.Id);
                    cmd.Parameters.AddWithValue("nome", usuario.Nome);
                    cmd.Parameters.AddWithValue("email", usuario.Email);
                    cmd.Parameters.AddWithValue("senha", usuario.Senha);
                    cmd.Parameters.AddWithValue("dataNascimento", usuario.DataNascimento);
                    cmd.Parameters.AddWithValue("foto", usuario.Foto);

                    con.Open();
                    var id = await cmd
                                    .ExecuteScalarAsync()
                                    .ConfigureAwait(false);

                    return int.Parse(id.ToString());
                }
            }
        }


    }
}
