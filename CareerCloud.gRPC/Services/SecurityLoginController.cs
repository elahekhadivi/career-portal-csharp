using CareerCloud.BusinessLogicLayer;
using CareerCloud.EntityFrameworkDataAccess;
using CareerCloud.Pocos;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using static CareerCloud.gRPC.SecurityLoginService;

namespace CareerCloud.gRPC.Services
{
    public class SecurityLoginController: SecurityLoginServiceBase
    {
        private readonly SecurityLoginLogic _logic;

        public SecurityLoginController()
        {
            _logic = new SecurityLoginLogic(new EFGenericRepository<SecurityLoginPoco>());
        }

        public override Task<SecurityLogin> GetCompanyJob(SecurityLoginIdRequest request, ServerCallContext context)
        {
            Guid id = Guid.Parse(request.Id);
            return new Task<SecurityLogin>(() => translateToProto(_logic.Get(id)));
        }

        public override Task<SecurityLogins> GetCompanyJobs(Empty request, ServerCallContext context)
        {
            List<SecurityLogin> protos = new List<SecurityLogin>();

            foreach (var item in _logic.GetAll())
            {
                protos.Add(translateToProto(item));
            }

            SecurityLogins SecLogs = new SecurityLogins();
            SecLogs.SecLog.AddRange(protos);

            return new Task<SecurityLogins>(() => SecLogs);
        }

        public override Task<Empty> AddCompanyJobs(SecurityLogins request, ServerCallContext context)
        {
            List<SecurityLoginPoco> pocos = new List<SecurityLoginPoco>();

            foreach (var item in request.SecLog)
            {
                pocos.Add(translateToPoco(item));
            }
            _logic.Add(pocos.ToArray());
            return Task.FromResult<Empty>(null);
        }

        public override Task<Empty> UpdateCompanyJobs(SecurityLogins request, ServerCallContext context)
        {
            List<SecurityLoginPoco> pocos = new List<SecurityLoginPoco>();

            foreach (var item in request.SecLog)
            {
                pocos.Add(translateToPoco(item));
            }
            _logic.Update(pocos.ToArray());
            return Task.FromResult<Empty>(null);
        }

        public override Task<Empty> DeleteCompanyJobs(SecurityLogins request, ServerCallContext context)
        {
            List<SecurityLoginPoco> pocos = new List<SecurityLoginPoco>();

            foreach (var item in request.SecLog)
            {
                pocos.Add(translateToPoco(item));
            }
            _logic.Delete(pocos.ToArray());
            return Task.FromResult<Empty>(null);
        }
        private SecurityLogin translateToProto(SecurityLoginPoco poco)
        {
            return new SecurityLogin()
            {
                Id = poco.Id.ToString(),
                Login = poco.Login.ToString(),
                Password = poco.Password.ToString(),
                Created = poco.Created == null ? null : Timestamp.FromDateTime((DateTime)poco.Created),
                PasswordUpdate = poco.PasswordUpdate == null ? null : Timestamp.FromDateTime((DateTime)poco.PasswordUpdate),
                AgreementAccepted = poco.AgreementAccepted == null ? null : Timestamp.FromDateTime((DateTime)poco.AgreementAccepted),
                IsLocked = poco.IsLocked,
                IsInactive = poco.IsInactive,
                EmailAddress = poco.EmailAddress,
                PhoneNumber = poco.PhoneNumber,
                FullName = poco.FullName,
                ForceChangePassword = poco.ForceChangePassword,
                PrefferredLanguage = poco.PrefferredLanguage,
            };

        }

        private SecurityLoginPoco translateToPoco(SecurityLogin proto)
        {
            return new SecurityLoginPoco()
            {
                Id = Guid.Parse(proto.Id),
                Login = proto.Login,
                Password = proto.Password,
                Created = proto.Created.ToDateTime(),
                PasswordUpdate = proto.PasswordUpdate.ToDateTime(),
                AgreementAccepted = proto.AgreementAccepted.ToDateTime(),
                IsLocked = proto.IsLocked,
                IsInactive = proto.IsInactive,
                EmailAddress = proto.EmailAddress,
                PhoneNumber = proto.PhoneNumber,
                FullName = proto.FullName,
                ForceChangePassword = proto.ForceChangePassword,
                PrefferredLanguage = proto.PrefferredLanguage,
            };

        }
    }
}
