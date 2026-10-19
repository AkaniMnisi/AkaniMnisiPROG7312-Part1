namespace SmartX.System.Services
{
    public class PredictiveEngine
    {
        private List<string> _userSearchHistory = new List<string>();

        public void RecordSearch(string searchTerm) => _userSearchHistory.Add(searchTerm);

        public string GenerateRecommendation(double currentMoisture, string deviceId)
        {
            if (currentMoisture < 20.0 && deviceId == "Moisture-Sensor-B")
            {
                int pumpASearches = _userSearchHistory.Count(s => s == "Pump A");
                if (pumpASearches >= 2)
                    return "Automated Insight: You usually turn on 'Pump A' when Moisture Sensor B drops below 20%.";
            }
            return "System Normal.";
        }
    }
}