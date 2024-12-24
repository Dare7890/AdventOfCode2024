using HistorianHysteria.Models;

namespace HistorianHysteria.Services
{
    public static class DistanceRetrieverService
    {
        private const string _DISTANCE_FILE_PATH = @"../../../../HistorianHysteria/Resource/Distance.txt";
        private const string _DISTANCE_SEPARATOR = "   ";

        public static DistanceListModel Retrieve()
        {
            var distanceListModel = new DistanceListModel();

            using (var stream = new FileStream(_DISTANCE_FILE_PATH, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                using (var streamReader = new StreamReader(stream))
                {
                    while (streamReader.Peek() >= 0)
                    {
                        var lineDistances = streamReader.ReadLine().Split(_DISTANCE_SEPARATOR);
                        distanceListModel.FirstList.Add(int.Parse(lineDistances[0]));
                        distanceListModel.SecondList.Add(int.Parse(lineDistances[1]));
                    }

                    return distanceListModel;
                }
            }
        }
    }
}
