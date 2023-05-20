namespace SpaceXLaunchAPI.Models
{
    public class Launch
    {
        public string? Id { get; set; }
        public string? Name { get; set; }
        public string? Details { get; set; }
        public bool? Success { get; set; }
        public bool? Upcoming { get; set; }
        public DateTime? Date_Utc { get; set; }
        public DateTime? Static_Fire_Date_Utc { get; set; }
        public int? Flight_Number { get; set; }
        public bool Tbd { get; set; }
        public bool Net { get; set; }
        public int? Window { get; set; }
        public string? Rocket { get; set; }
        public string? RocketName { get; set; }
        public string? RocketCountry { get; set; }
        public string? RocketCompany { get; set; }
        public string? LaunchPad { get; set; }
        public string? LaunchPadName { get; set; }
        public string? LaunchPadFullName { get; set; }
        public string? LaunchPadRegion { get; set; }
    }
}
