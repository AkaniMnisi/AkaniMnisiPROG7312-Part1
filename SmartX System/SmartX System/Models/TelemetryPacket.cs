namespace SmartX_System.Models
{
    public class TelemetryPacket<T>
    {
        public string SensorId { get; set; } = string.Empty;
        public string MacAddress { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public T? Payload { get; set; } // Generic type T (No boxing/unboxing)
        public DateTime Timestamp { get; set; } = DateTime.UtcNow;

        // Contextual attachment feature
        public List<string> AttachedLogs { get; set; } = new List<string>();
    }
}