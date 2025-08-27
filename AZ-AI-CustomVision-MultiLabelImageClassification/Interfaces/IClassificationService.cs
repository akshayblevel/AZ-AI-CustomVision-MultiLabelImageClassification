namespace AZ_AI_CustomVision_MultiLabelImageClassification.Interfaces
{
    public interface IClassificationService
    {
        Task<string?> ClassifyImageAsync(string imageUrl);
    }
}
