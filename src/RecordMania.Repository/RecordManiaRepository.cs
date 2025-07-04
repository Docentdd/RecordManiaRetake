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
        
        var command = new SqlCommand("INSERT INTO Records (TeacherId,RecordTypeId, TaskId, ExecutionTime, CreationTime) VALUES (@TeacherId,@RecordTypeId,@TaskId, @ExecutionTime, @CreationTime)", connection);
        command.Parameters.AddWithValue("@TeacherId", record.TeacherId);
        command.Parameters.AddWithValue("@RecordTypeId", record.RecordTypeId);
        command.Parameters.AddWithValue("@TaskId", record.TaskId);
        command.Parameters.AddWithValue("@ExecutionTime", record.ExecutionTime);
        command.Parameters.AddWithValue("@CreationTime", record.CreationTime);
        
        connection.Open();
        command.ExecuteNonQuery();
    }
    
    public void AddRecordFirs(RecordDTOfrst record)
    {
        using var connection = new SqlConnection(_connectionString);
        
        var command = new SqlCommand("INSERT INTO Records (TeacherId,RecordTypeId, TaskId, ExecutionTime, CreationTime) VALUES (@TeacherId,@RecordTypeId,@TaskId, @ExecutionTime, @CreationTime)", connection);
        command.Parameters.AddWithValue("@TeacherId", record.TeacherId);
        command.Parameters.AddWithValue("@RecordTypeId", record.RecordTypeId);
        command.Parameters.AddWithValue("@TaskId", record.TaskId);
        command.Parameters.AddWithValue("@ExecutionTime", record.ExecutionTime);
        command.Parameters.AddWithValue("@CreationTime", record.CreationTime);
        
        connection.Open();
        command.ExecuteNonQuery();
    }
    public List<Records> GetAllRecordsWithDetails()
    {
        List<Records> records = new List<Records>();
        using var connection = new SqlConnection(_connectionString);
        connection.Open();
        
        var command = new SqlCommand("SELECT * FROM Records /*JOIN TEACHER ON TeacherId = Teacher.Id JOIN Task on TaskId = Task.Id JOIN RecordType On RecordTypeId = RecordType.Id*/", connection);
        
        using var reader = command.ExecuteReader();

        while (reader.Read())
        {
            records.Add(new Records
            {
                Id = reader.GetInt32(0),
                TeacherId = reader.GetInt32(1),
                RecordTypeId = reader.GetInt32(2),
                TaskId = reader.GetInt32(3),
                ExecutionTime = reader.GetDecimal(4),
                CreationTime = reader.GetDateTime(5)
            });
        }

        return records;
    }
    
    
}