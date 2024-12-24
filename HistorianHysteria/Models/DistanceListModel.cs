namespace HistorianHysteria.Models
{
    public sealed class DistanceListModel
    {
        public ICollection<int> FirstList { get; set; } = [];

        public ICollection<int> SecondList { get; set; } =  [];
    }
}
