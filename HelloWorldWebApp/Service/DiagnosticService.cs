using System.Diagnostics;

namespace HelloWorldApp.Service
{
    public static class DiagnosticService
    {
        public static double GetCpuUsage()
        {
            if (OperatingSystem.IsWindows())
            {
                var cpuCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total");
                cpuCounter.NextValue();
                System.Threading.Thread.Sleep(500); // Pausa para leitura precisa
                return cpuCounter.NextValue();
            }
            else if (OperatingSystem.IsLinux())
            {
                var lines = File.ReadAllLines("/proc/stat");
                var cpuLine = lines.FirstOrDefault(line => line.StartsWith("cpu "));
                if (cpuLine == null) return 0.0;

                var parts = cpuLine.Split(' ', StringSplitOptions.RemoveEmptyEntries).Skip(1).Select(long.Parse).ToArray();
                var idle = parts[3];
                var total = parts.Sum();

                System.Threading.Thread.Sleep(500);

                lines = File.ReadAllLines("/proc/stat");
                cpuLine = lines.FirstOrDefault(line => line.StartsWith("cpu "));
                if (cpuLine == null) return 0.0;

                parts = cpuLine.Split(' ', StringSplitOptions.RemoveEmptyEntries).Skip(1).Select(long.Parse).ToArray();
                var idleAfter = parts[3];
                var totalAfter = parts.Sum();

                var totalDiff = totalAfter - total;
                var idleDiff = idleAfter - idle;

                return (1.0 - (double)idleDiff / totalDiff) * 100;
            }
            else
            {
                throw new PlatformNotSupportedException("CPU usage retrieval is not supported on this OS.");
            }
        }

        public static (long total, long used) GetMemoryInfo()
        {
            if (OperatingSystem.IsLinux())
            {
                var memInfo = File.ReadAllLines("/proc/meminfo")
                    .ToDictionary(line => line.Split(':')[0], line => long.Parse(line.Split(':')[1].Trim().Split(' ')[0]) * 1024);

                long totalMemory = memInfo["MemTotal"];
                long freeMemory = memInfo["MemFree"] + memInfo["Buffers"] + memInfo["Cached"];
                long usedMemory = totalMemory - freeMemory;

                return (totalMemory, usedMemory);
            }
            else if (OperatingSystem.IsWindows())
            {
                var totalMemory = GC.GetGCMemoryInfo().TotalAvailableMemoryBytes;
                PerformanceCounter memoryCounter = new PerformanceCounter("Memory", "Available MBytes");
                float availableMemory = memoryCounter.NextValue();
                return (totalMemory, totalMemory-((long)availableMemory * 1024 * 1024));
            }
            else
            {
                throw new PlatformNotSupportedException("Memory information retrieval is not supported on this OS.");
            }
            
        }

        public static (long total, long used) GetStorageInfo()
        {
            var drives = DriveInfo.GetDrives()
                .Where(d => d.IsReady && (d.DriveType == DriveType.Fixed || d.DriveType == DriveType.Removable));

            long totalSpace = 0;
            long usedSpace = 0;

            foreach (var drive in drives)
            {
                totalSpace += drive.TotalSize;
                usedSpace += drive.TotalSize - drive.AvailableFreeSpace;
            }

            return (totalSpace, usedSpace);
        }
    }
}
