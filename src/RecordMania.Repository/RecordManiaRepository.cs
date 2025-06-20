using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using RecordMania.Model;

namespace RecordMania.Repository;

public class RecordManiaRepository : IRecordManiaRepository
{
    private readonly string _connectionString;
    
    public RecordManiaRepository(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("DefaultConnection");
    }
    public List<RecordDTO> GetAllRecords()
    {
        List<RecordDTO> records = new List<RecordDTO>();
        using var connection = new SqlConnection(_connectionString);
        connection.Open();
        
        var command = new SqlCommand("SELECT * FROM Records", connection);
        
        using var reader = command.ExecuteReader();

        while (reader.Read())
        {
            records.Add(new RecordDTO
            {
                Id = reader.GetInt32(0),
            });
        }

        return records;
    }

    public void AddRecord(Records record)
    {
        using var connection = new SqlConnection(_connectionString);
        
        var command = new SqlCommand("INSERT INTO Records (TaskId, RecordTypeId, TeacherId, ExecutionTime, CreationTime) VALUES (@TaskId, @RecordTypeId, @TeacherId, @ExecutionTime, @CreationTime)", connection);
        command.Parameters.AddWithValue("@TaskId", record.TaskId);
        command.Parameters.AddWithValue("@RecordTypeId", record.RecordTypeId);
        command.Parameters.AddWithValue("@TeacherId", record.TeacherId);
        command.Parameters.AddWithValue("@ExecutionTime", record.ExecutionTime);
        command.Parameters.AddWithValue("@CreationTime", record.CreationTime);
        
        connection.Open();
        command.ExecuteNonQuery();
    }
}