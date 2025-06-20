using Microsoft.AspNetCore.Mvc;
using RecordMania.Application;
using RecordMania.Model;

namespace RecordMania.API.Controllers;
[ApiController]
[Route("api/records")]
public class RecordManiaController : ControllerBase
{ 
    private readonly RecordManiaManager _recordManiaManager;
    
    public RecordManiaController(RecordManiaManager recordManiaManager)
    {
        _recordManiaManager = recordManiaManager;
    }
    [HttpGet]
    public IActionResult GetAllRecords()
    {
        var records = _recordManiaManager.GetAllRecords();
        return Ok(records);
    }
    [HttpPost]
    public IActionResult AddRecord([FromBody] Records record)
    {
        if (record == null)
        {
            return BadRequest("Record data is required.");
        }
        
        _recordManiaManager.AddRecord(record);
        return CreatedAtAction(nameof(GetAllRecords), new { id = record.Id }, record);
    }
    [HttpPost("first")]
    public IActionResult AddRecordFirst([FromBody] RecordDTOfrst record)
    {
        if (record == null)
        {
            return BadRequest("Record data is required.");
        }
        
        _recordManiaManager.AddRecordFirst(record);
        return CreatedAtAction(nameof(GetAllRecords), new { id = record.Id }, record);
    }
    [HttpGet("details")]
    public IActionResult GetAllRecordsWithDetails()
    {
        var records = _recordManiaManager.GetAllRecordsWithDetails();
        return Ok(records);
    }
}