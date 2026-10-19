namespace SmartX.Shared.Models 
{
    public class TelemetryData
    {
        public string DeviceMacAddress { get; set; } = string.Empty;
        public string SensorType { get; set; } = string.Empty;
        public double Value { get; set; }
        public bool IsCritical { get; set; }
    }

    public class ManualCommand
    {
        public string CommandName { get; set; } = string.Empty;
    }
}