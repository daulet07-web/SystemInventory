namespace SI.Domain.Models
{
    public class Device
    {
        public int Id { get; set; }
        public string AssetId { get; set; }
        public string Name { get; set; }
        public string Fqdn { get; set; }
        public string Domain { get; set; }
        public string Type { get; set; }
        public string Environment { get; set; }
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public string SerialNumber { get; set; }
        public string RackLocation { get; set; }
        public string Datacenter { get; set; }
        public string Status { get; set; }
        public string CpuModel { get; set; }
        public string CpuCores { get; set; }
        public string CpuThreads { get; set; }
        public string RamGb { get; set; }
        public string StorageGb { get; set; }
        public string StorageType { get; set; }
        public string OsName { get; set; }
        public string OsVersion { get; set; }
        public string OsBuild { get; set; }
        public string KernelVersion { get; set; }
        public DateTime PurchaseDate { get; set; }
        public DateTime WarrantyEndDate { get; set; }
        public DateTime EolDate { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string Notes { get; set; }
        public int InventoryItemId { get; set; }
        //public InventoryItem InventoryItem { get; set; }
    }
}
