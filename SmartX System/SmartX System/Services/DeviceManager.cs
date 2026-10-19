using SmartX.Shared.Models; 
namespace SmartX.System.Services 
{
    public class DeviceManager
    {
        public Queue<TelemetryData> StandardQueue { get; private set; } = new Queue<TelemetryData>();
        public PriorityQueue<TelemetryData, int> CriticalQueue { get; private set; } = new PriorityQueue<TelemetryData, int>();
        public Stack<string> CommandHistoryStack { get; private set; } = new Stack<string>();

        public void RouteIncomingData(TelemetryData data)
        {
            if (data.IsCritical)
                CriticalQueue.Enqueue(data, 100);
            else
                StandardQueue.Enqueue(data);
        }

        public void ExecuteCommand(string command)
        {
            CommandHistoryStack.Push(command);
        }

        public string UndoLastCommand()
        {
            if (CommandHistoryStack.Count > 0)
                return $"SUCCESS: Reverted command: {CommandHistoryStack.Pop()}";

            return "ERROR: No commands to undo.";
        }
    }
}