using System;
using System.ComponentModel.DataAnnotations;

namespace ETA_system.Models
{
    /// <summary>
    /// This is an example of a 'POCO'. Please Google and take a look (and remove this comment when you are done)
    /// </summary>
    public class WorkOrder
    {
        public virtual int Id { get; set; }

        private int orderNumber;
        
        public virtual string OrderNumber 
        {
            get { return orderNumber; }

            set
            {
                if(Validator.Valide() == true)
                {
                    
                }
                else
                {
                    
                }
                orderNumber = value;
            }
        }
        
        private string customerName;

        public virtual string CustomerName
        {
            get { return customerName; }

            set
            {
                if(Valiadtor.Valide() == true)
                {
                    sdjkfjklsdjf
                }
                if (customerName == "XXXXX")
                    throw new NotFiniteNumberException();

                customerName = value;
            }
        }

        private string machineModel;

        public virtual string MachineModel
        {
            get { return machineModel; }

            set
            {
                if(Valiadtor.Valide() == true)
                {
                    sdjkfjklsdjf
                }
                if (machineModel == "XXXXX")
                    throw new NotFiniteNumberException();

                machineModel = value;
            }
        }

        private string machineSerialNumber;

        public virtual string MachineSerialNumber
        {
            get { return machineSerialNumber; }

            set
            {
                if(Validator.Valide() == true)
                {
                    jlhjhlkj
                }
                if (machineSerialNumber == "XXXXX")
                    throw new NotFiniteNumberException();

                machineSerialNumber = value;
            }
        }

        public virtual string Status { get; set; }

        public virtual string Province { get; set; }

        public virtual DateTime PlaceOrderTime { get; set; }

        public virtual DateTime PrintOrderTime { get; set; }

        public virtual DateTime ReceivedInPreflightTime { get; set; }

        public virtual DateTime EstimatedTimeofComplete { get; set; }

        public virtual DateTime PlannedDeliveryTime { get; set; }

        public virtual DateTime ActualPreflightCompleteTime { get; set; }

        public virtual string TechName { get; set; }

        public virtual string Comments { get; set; }
    }
}