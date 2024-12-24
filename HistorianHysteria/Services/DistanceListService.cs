using HistorianHysteria.Models;

namespace HistorianHysteria.Services
{
    public class DistanceListService
    {
        public static int CalculateDistance(DistanceListModel distanceListModel)
        {
            if (distanceListModel == null)
            {
                return 0;
            }

            return distanceListModel.FirstList.OrderBy(l => l)
                .Zip(second: distanceListModel.SecondList.OrderBy(l => l), 
                    resultSelector: (first, second) => Math.Abs(first - second))
                .Sum();
        }

        public static int CalculateSimilarityScore(DistanceListModel distanceListModel)
        {
            if (distanceListModel == null)
            {
                return 0;
            }

            var score = 0;
            var dict = distanceListModel.SecondList.Distinct().ToDictionary(
                keySelector: l => l,
                elementSelector: el => distanceListModel.SecondList.Count(l => l == el));

            foreach (var distance in distanceListModel.FirstList)
            {
                if (dict.TryGetValue(distance, out int amount))
                {
                    score += distance * amount;
                }
            }

            return score;
        }
    }
}
