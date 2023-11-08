using MedicalDiacnosCenter.Domain.Commons;

namespace MedicalDiacnosCenter.Domain.Entities;

public class Asset : Auditable
{
    public string Path { get; set; }
}
