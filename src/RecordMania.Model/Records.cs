namespace RecordMania.Model;

public class Records
{
    public int Id { get; set; }
    public Teacher Teacher { get; set; }
    public int TeacherId { get; set; }
    public RecordType RecordType { get; set; }
    public int RecordTypeId { get; set; }
    public Task Task { get; set; }
    public int TaskId { get; set; }
    public decimal ExecutionTime { get; set; }
    public DateTime CreationTime { get; set; }
    
    
}