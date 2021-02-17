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
    public class GeneroRepository : IGeneroRepository
    {

        private readonly IConfiguration _configuration;

        public GeneroRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<Genero> PegarIdAsync(int id)
        {
            using(var con = new SqlConnection(_configuration["ConnectionString"]))
            {
                var sqlCmd = @$"SELECT Id, Descricao
                                    FROM Genero g ON g.Id = u.GeneroId
                                    WHERE u.Id= {id}";

                using (var cmd = new SqlCommand(sqlCmd, con))
                {
                    cmd.CommandType = CommandType.Text;
                    con.Open();

                    var reader = await cmd
                                           .ExecuteReaderAsync()
                                           .ConfigureAwait(false);

                    while (reader.Read())
                    {
                        var genero = new Genero(reader["Descricao"].ToString());

                        genero.SetId(int.Parse(reader["id"].ToString()));
                        

                        return genero;
                    }

                    return default;
                }
            }
        }
    }
}
