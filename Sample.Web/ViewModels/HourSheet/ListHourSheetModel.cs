using System;

namespace Sandbox.Web.ViewModels.HourSheet{
    
    public class ListHourSheetModel{
        public int Id { get; set; }
        public string ProjectName { get; set; }
        public string SubProjectName { get; set; }
        public string Description { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public TimeSpan TotalMinutes { get; set; }
        public DateTime? SyncedToTwinfieldAt { get; set; }
    }
}