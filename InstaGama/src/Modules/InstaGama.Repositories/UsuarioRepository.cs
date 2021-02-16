using InstaGama.Domain.Entities;
using InstaGama.Domain.Interfaces;
using System;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;


namespace InstaGama.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
       
<<<<<<< HEAD
        public Task<Usuario> GetById(int id)
=======
        public Task<Usuario> PegarId(int id)
>>>>>>> eff0343d402b427483f22b965d13a5b62e509ad3
        {
            throw new NotImplementedException();
        }

<<<<<<< HEAD
        public Task<Usuario> GetByLoginAsync(string login)
=======
        public Task<Usuario> PegarLoginAsync(string login)
>>>>>>> eff0343d402b427483f22b965d13a5b62e509ad3
        {
            throw new NotImplementedException();
        }

        public async Task<int>  InserirAsync(Usuario usuario)
        {
            using(var con = new SqlConnection(""))
            {
                var sqlCmd = @"INSERT INTO
                                  Usuario (GeneroId, Nome, Senha, DataNascimento, Foto)
                                  VALUES (@generoId, @nome, @dataNascimento, @foto); SELECT scope_identity();";

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
