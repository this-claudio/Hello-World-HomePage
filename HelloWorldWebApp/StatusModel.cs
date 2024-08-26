namespace HelloWorld.Model
{
    public class StatusModel
    {
        public StatusModel(string machineName, string operationSystem, bool isRunning, string processCode)
        {
            MachineName = machineName;
            OperationSystem = operationSystem;
            IsRunning = isRunning;
            ProcessCode = processCode;
        }

        public string MachineName { get; set; }
        public string OperationSystem { get; set; }
        public bool IsRunning { get; set; }
        public string ProcessCode { get; set; }

        
    }
}