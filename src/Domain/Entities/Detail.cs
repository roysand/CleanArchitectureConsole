namespace Domain.Entities;

public class Detail
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid MeasurementId { get; set; }
    public DateTime TimeStamp { get; set; }
    public string Location { get; set; } = null!;
    public string Name { get; set; } = null!;
    public string ObisCode { get; set; } = null!;
    public string Unit { get; set; } = null!;
    public string ValueStr { get; set; } = null!;
    public decimal ValueNum { get; set; }
}