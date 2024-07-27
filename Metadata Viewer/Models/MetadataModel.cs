namespace Metadata_Viewer.Models
{
    public class MetadataModel
    {
        public required string ApplicationName { get; set; }

        public required string ApplicationBasePath { get; set; }

        public required string TargetFramework { get; set; }

        public string Version { get; set; } = string.Empty;
    }
}
