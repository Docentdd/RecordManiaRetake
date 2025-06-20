using RecordMania.Model;

namespace RecordMania.Repository;

public interface IRecordManiaRepository
{
    List<RecordDTO> GetAllRecords();
    List<Records> GetAllRecordsWithDetails();
    void AddRecord(Records record);
    void AddRecordFirs(RecordDTOfrst record);
}