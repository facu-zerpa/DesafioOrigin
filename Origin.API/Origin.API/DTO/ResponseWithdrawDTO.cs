namespace Origin.API.DTO
{
    public class ResponseWithdrawDTO
    {
        public string Number { get; set; }
        public DateTime DateOperation { get; set; }
        public double? Amount { get; set; }
        public double Balance { get; set; }
    }
}
