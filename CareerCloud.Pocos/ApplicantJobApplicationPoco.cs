using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations; // For [key]
using System.ComponentModel.DataAnnotations.Schema; // For Table

namespace CareerCloud.Pocos
{
    [Table("Applicant_Job_Applications")]
    public class ApplicantJobApplicationPoco : IPoco
    {
        [Key] //It shows the Id is the primary key, For Entity framework
        public Guid Id { get; set; }
        public Guid Applicant { get; set; }
        public Guid Job { get; set; }

        [Column("Application_Date")]
        public DateTime ApplicationDate { get; set; }

        [Column("Time_Stamp")]
        public byte[] TimeStamp { get; set; }

        public virtual ApplicantProfilePoco ApplicantProfile { get; set; }
        public virtual CompanyJobPoco CompanyJob { get; set; }
    }
}
