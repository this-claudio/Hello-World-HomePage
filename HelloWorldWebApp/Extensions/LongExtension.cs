namespace HelloWorldApp.Extentions
{
    public static class LongExtension
    {
        public static string FormatBytes(this long bytes)
        {
            const long OneKB = 1024;
            const long OneMB = OneKB * 1024;
            const long OneGB = OneMB * 1024;

            if (bytes >= OneGB)
                return $"{bytes / (double)OneGB:F2} GB";
            if (bytes >= OneMB)
                return $"{bytes / (double)OneMB:F2} MB";
            if (bytes >= OneKB)
                return $"{bytes / (double)OneKB:F2} KB";
            return $"{bytes} Bytes";
        }
    }
}
