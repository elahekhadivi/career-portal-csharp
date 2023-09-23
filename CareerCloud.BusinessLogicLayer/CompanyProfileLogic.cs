using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CareerCloud.BusinessLogicLayer
{
    public class CompanyProfileLogic : BaseLogic<CompanyProfilePoco>
    {
        public CompanyProfileLogic(IDataRepository<CompanyProfilePoco> repository) : base(repository)
        {
        }

        public override void Add(CompanyProfilePoco[] pocos)
        {
            Verify(pocos);
            base.Add(pocos);
        }
        public override void Update(CompanyProfilePoco[] pocos)
        {
            Verify(pocos);
            base.Update(pocos);
        }

        protected override void Verify(CompanyProfilePoco[] pocos)
        {
            List<ValidationException> errors = new List<ValidationException>();
            foreach (CompanyProfilePoco poco in pocos)
            {
               
                if (string.IsNullOrEmpty(poco.CompanyWebsite) || !Regex.IsMatch(poco.CompanyWebsite, @"^((https?|ftp|smtp):\/\/)?(www.)?[a-z0-9]+\.[a-z]{2,5}(:[0-9]{1,5})?(\/.*)?$", RegexOptions.IgnoreCase))
                {
                    errors.Add(new ValidationException(600, "Valid websites must end with the following extensions – .ca, .com, .biz"));
                }

                if (string.IsNullOrEmpty(poco.ContactPhone) || !Regex.IsMatch(poco.ContactPhone, @"^(\+\d{1,2}\s)?\(?\d{3}\)?[\s.-]\d{3}[\s.-]\d{4}$", RegexOptions.IgnoreCase))
                {
                    errors.Add(new ValidationException(601, "Must correspond to a valid phone number (e.g. 416-555-1234)"));
                }
               
                if (errors.Count > 0)
                {
                    throw new AggregateException(errors);
                }
            }
        }
    }
}
