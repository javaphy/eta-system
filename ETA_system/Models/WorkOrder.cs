using System;

namespace ETA_system.Models
{
    /// <summary>
    /// This is an example of a 'POCO'. Please Google and take a look (and remove this comment when you are done)
    /// </summary>
    public class WorkOrder
    {
        public virtual int Id { get; set; }
        public virtual string OrderNumber { get; set; }
        public virtual string CustomerName { get; set; }
        public virtual string MachineModel { get; set; }
        public virtual string MachineSerialNumber { get; set; }
        public virtual StatusTypes Status { get; set; }
        public virtual string Province { get; set; }
        public virtual DateTime PlaceOrderTime { get; set; }
        public virtual DateTime PrintOrderTime { get; set; }
        public virtual DateTime ReceivedInPreflightTime { get; set; }
        public virtual DateTime EstimatedTimeOfComplete { get; set; }
        public virtual DateTime PlannedDeliveryTime { get; set; }
        public virtual DateTime? ActualPreflightCompleteTime { get; set; }
        public virtual string TechName { get; set; }
        public virtual string Comments { get; set; }


        public enum StatusTypes
        {
            Picking = 1,
            Waiting = 2,
            Processing = 3,
            Pending = 4,
            Complete = 5,
        }
    }
}