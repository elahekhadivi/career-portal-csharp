using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerCloud.BusinessLogicLayer
{
    public class SystemCountryCodeLogic 
    {
		protected IDataRepository<SystemCountryCodePoco> _repository;
        public SystemCountryCodeLogic(IDataRepository<SystemCountryCodePoco> repository)
        {
			_repository = repository;
		}
		public virtual SystemCountryCodePoco Get(Guid code)
		{
			return _repository.GetSingle(c => c.Code == code.ToString());
		}

		public virtual List<SystemCountryCodePoco> GetAll()
		{
			return _repository.GetAll().ToList();
		}
		public void Add(SystemCountryCodePoco[] pocos)
		{
			Verify(pocos);
			foreach (SystemCountryCodePoco poco in pocos)
			{
				if (poco.Code == Guid.Empty.ToString())
				{
					poco.Code = Guid.NewGuid().ToString();
				}
			}

			_repository.Add(pocos);
		}

		public void Update(SystemCountryCodePoco[] pocos)
		{
			Verify(pocos);
			_repository.Update(pocos);
		}

		public void Delete(SystemCountryCodePoco[] pocos)
		{
			_repository.Remove(pocos);
		}
		protected void Verify(SystemCountryCodePoco[] pocos)
		{
			List<ValidationException> errors = new List<ValidationException>();
			foreach (SystemCountryCodePoco poco in pocos)
			{
				if (string.IsNullOrEmpty(poco.Code))
				{
					errors.Add(new ValidationException(900, "Cannot be empty"));
				}

				if (string.IsNullOrEmpty(poco.Name))
				{
					errors.Add(new ValidationException(901, "Cannot be empty"));
				}

				if (errors.Count > 0)
				{
					throw new AggregateException(errors);
				}
			}
		}


	}
}
