namespace ShamrockCore.Data.Model
{
    public record BatteryInfo
    {
        public int Battery {  get; set; }
        public long Scale { get; set; }
        public int Status { get; set; }
    }
}
