namespace SmartX_System.Models
{
    public class TelemetryPacket<T>
    {
        public string SensorId { get; set; } = string.Empty;
        public string MacAddress { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public T? Payload { get; set; } 
        public DateTime Timestamp { get; set; } = DateTime.UtcNow;
        
        public List<string> AttachedLogs { get; set; } = new List<string>();
    }
}