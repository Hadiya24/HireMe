namespace HireMe.Models
{
    public enum JobStatus
    {
        Open,
        Closed,
        Pending
    }

    public class Job
    {
        public int Id { get; set; }
        public string JobTitle { get; set; }
        public string JobDescription { get; set; }
        public string Location { get; set; }
        public string EmploymentType { get; set; }
        public decimal MinSalary { get; set; }
        public decimal MaxSalary { get; set; }
        public DateTime PostedOn { get; set; }
        public DateTime Deadline { get; set; }
        public string Requirements { get; set; }
        public string Tags { get; set; }
        public JobStatus Status { get; set; }

        public string EmployerId { get; set; }
        public ApplicationUser Employer { get; set; }


    }

}
