﻿
//2022-02-14
using System.ComponentModel.DataAnnotations; // For [key]
using System.ComponentModel.DataAnnotations.Schema; // For Table

namespace CareerCloud.Pocos 
{
    [Table("Applicant_Educations")]
    public class ApplicantEducationPoco : IPoco
    {   [Key] //It shows the Id is the primary key, For Entity framework
        public Guid Id { get; set; }
        public Guid Applicant { get; set; } 
        public String Major { get; set; }

        [Column("Certificate_Diploma")]
        public String CertificateDiploma { get; set; }
        [Column("Start_Date")]
        public DateTime? StartDate { get; set; }
        [Column("Completion_Date")]
        public DateTime? CompletionDate  { get; set; }
        [Column("Completion_Percent")]
        public byte? CompletionPercent { get; set; }
        [Column("Time_Stamp")]
        public byte[] TimeStamp { get; set;}

        public virtual ApplicantProfilePoco ApplicantProfile { get; set; }

    }
}