namespace SmartX.System.Services
{
    public class DataStorage
    {
        public Dictionary<string, string> RegisteredDevices { get; private set; } = new Dictionary<string, string>();
        public SortedDictionary<DateTime, string> HistoricalLogs { get; private set; } = new SortedDictionary<DateTime, string>();
        public HashSet<string> ActiveDisconnectAlerts { get; private set; } = new HashSet<string>();

        public void RegisterDevice(string macAddress, string deviceName)
        {
            RegisteredDevices[macAddress] = deviceName;
        }

        public void LogEvent(string macAddress, string message)
        {
            HistoricalLogs.Add(DateTime.Now, $"[{macAddress}] {message}");
        }

        public bool TriggerDisconnectAlert(string macAddress)
        {
            return ActiveDisconnectAlerts.Add(macAddress);
        }
    }
}