using System;

public class CurtidasRepository 
{
    private readonly IConfiguration _configuration;

    public CurtidasRepository(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public async Task DeleteAsync(int id)
    {
        using (var con = new SqlConnection(_configuration["ConnectionString"]))
        {
            var sqlCmd = $@"DELETE 
                                FROM
                                Curtidas
                               WHERE 
                                Id={id}";

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

    public async Task<Curtidas> GetByUsuarioIdAndPostagemIdAsync(int usuarioId, int postagemId)
    {
        using (var con = new SqlConnection(_configuration["ConnectionString"]))
        {
            var sqlCmd = @$"SELECT Id,
	                                   UsuarioId
                                       PostagemId
                                FROM 
	                                Curtidas
                                WHERE 
	                                UsuarioId= '{usuarioId}'
                                AND 
                                    PostagemId= '{postagemId}'";

            using (var cmd = new SqlCommand(sqlCmd, con))
            {
                cmd.CommandType = CommandType.Text;
                con.Open();

                var reader = await cmd
                                    .ExecuteReaderAsync()
                                    .ConfigureAwait(false);

                while (reader.Read())
                {
                    var curtidas = new Curtidas(int.Parse(reader["Id"].ToString()),
                                            int.Parse(reader["PostagemId"].ToString()),
                                            int.Parse(reader["UsuarioId"].ToString()));

                    return curtidas;
                }

                return default;
            }
        }
    }

    public async Task<int> GetQuantityOfCurtidasByPostagemIdAsync(int postagemId)
    {
        using (var con = new SqlConnection(_configuration["ConnectionString"]))
        {
            var sqlCmd = @$"SELECT
                                    COUNT(*) AS Quantidade
                                FROM 
	                                Curtidas
                                WHERE 
	                                PostagemId={postagemId}";

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

    public async Task<int> InsertAsync(Curtidas curtidas)
    {
        using (var con = new SqlConnection(_configuration["ConnectionString"]))
        {
            var sqlCmd = @"INSERT INTO
                                Curtidas (UsuarioId,
                                           PostagemId)
                                VALUES (@usuarioId,
                                        @postagemId); SELECT scope_identity();";

            using (var cmd = new SqlCommand(sqlCmd, con))
            {
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("usuarioId", curtidas.UsuarioId);
                cmd.Parameters.AddWithValue("postagemId", curtidas.PostagemId);

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
