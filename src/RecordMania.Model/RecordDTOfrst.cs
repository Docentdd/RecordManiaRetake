namespace RecordMania.Model;

public class RecordDTOfrst
{
    public int Id { get; set; }
    public int TeacherId { get; set; }
    public int RecordTypeId { get; set; }
    public Task Task { get; set; }
    public int TaskId { get; set; }
    public long ExecutionTime { get; set; }
    public DateTime CreationTime { get; set; }
}