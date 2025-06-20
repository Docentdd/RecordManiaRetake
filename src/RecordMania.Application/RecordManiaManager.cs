using RecordMania.Model;
using RecordMania.Repository;

namespace RecordMania.Application;

public class RecordManiaManager
{
    private readonly IRecordManiaRepository _repository;
    public RecordManiaManager(IRecordManiaRepository repository)
    {
        _repository = repository;
    }
    public List<RecordDTO> GetAllRecords()
    {
        return _repository.GetAllRecords();
    }

    public void AddRecord(Records record)
    {
        _repository.AddRecord(record);
    }
    public void AddRecordFirst(RecordDTOfrst record)
    {
        _repository.AddRecordFirs(record);
    }
    
}