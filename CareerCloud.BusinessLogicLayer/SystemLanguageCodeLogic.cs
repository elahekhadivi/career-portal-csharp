﻿using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerCloud.BusinessLogicLayer
{
    public class SystemLanguageCodeLogic
    {
		protected IDataRepository<SystemLanguageCodePoco> _repository;
		public SystemLanguageCodeLogic(IDataRepository<SystemLanguageCodePoco> repository)
		{
			_repository = repository;
		}
		public virtual SystemLanguageCodePoco Get(string LanguageId)
		{
			return _repository.GetSingle(c => c.LanguageID == LanguageId);
		}

		public virtual List<SystemLanguageCodePoco> GetAll()
		{
			return _repository.GetAll().ToList();
		}
		public void Add(SystemLanguageCodePoco[] pocos)
		{
			Verify(pocos);
			foreach (SystemLanguageCodePoco poco in pocos)
				{
					if (poco.LanguageID == Guid.Empty.ToString())
					{
						poco.LanguageID = Guid.NewGuid().ToString();
					}
				}

			_repository.Add(pocos);
		}

		public void Update(SystemLanguageCodePoco[] pocos)
		{
			Verify(pocos);
			_repository.Update(pocos);
		}

		public void Delete(SystemLanguageCodePoco[] pocos)
		{
			_repository.Remove(pocos);
		}
		protected void Verify(SystemLanguageCodePoco[] pocos)
		{
			List<ValidationException> errors = new List<ValidationException>();
			foreach (SystemLanguageCodePoco poco in pocos)
			{
				if (string.IsNullOrEmpty(poco.LanguageID))
				{
					errors.Add(new ValidationException(1000, "Cannot be empty"));
				}

				if (string.IsNullOrEmpty(poco.Name))
				{
					errors.Add(new ValidationException(1001, "Cannot be empty"));
				}

				if (string.IsNullOrEmpty(poco.NativeName))
				{
					errors.Add(new ValidationException(1002, "Cannot be empty"));
				}

				if (errors.Count > 0)
				{
					throw new AggregateException(errors);
				}
			}
		}
	}
}
