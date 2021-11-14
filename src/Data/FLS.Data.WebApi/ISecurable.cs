namespace FLS.Data.WebApi
{
    public interface ISecurable
    {
        bool CanUpdateRecord { get; set; }

        bool CanDeleteRecord { get; set; }
    }
}
