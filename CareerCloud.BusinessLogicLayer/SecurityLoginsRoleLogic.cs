﻿using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerCloud.BusinessLogicLayer
{
    public class SecurityLoginsRoleLogic : BaseLogic<SecurityLoginsRolePoco>
    {
        public SecurityLoginsRoleLogic(IDataRepository<SecurityLoginsRolePoco> repo)
           : base(repo)
        {
        }

        public override void Update(SecurityLoginsRolePoco[] pocos)
        {
            Verify(pocos);
            base.Update(pocos);
        }

        protected override void Verify(SecurityLoginsRolePoco[] pocos)
        {
            List<ValidationException> errors = new List<ValidationException>();
            foreach (SecurityLoginsRolePoco poco in pocos)
            {
                if (errors.Count > 0)
                {
                    throw new AggregateException(errors);
                }
            }
        }

    }
}
