namespace AdminManager.Models
{
    public class PagingModel
    {
        public object Data { get; set; } = null!;
        public int Total { get; set; }
    }

    public class BilPagingModel
    {
        public object Data { get; set; } = null!;
        public int Total { get; set; }
        public double Income { get; set; }
        public double EstimateIncome { get; set; }
    }
}
