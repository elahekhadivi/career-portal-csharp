using CareerCloud.BusinessLogicLayer;
using CareerCloud.EntityFrameworkDataAccess;
using CareerCloud.Pocos;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using static CareerCloud.gRPC.ApplicantProfileService;

namespace CareerCloud.gRPC.Services
{
    public class ApplicantProfileController : ApplicantProfileServiceBase

    {
        private readonly ApplicantProfileLogic _logic;

        public ApplicantProfileController()
        {
            _logic = new ApplicantProfileLogic(new EFGenericRepository<ApplicantProfilePoco>());
        }

        public override Task<ApplicantProfile> GetApplicantProfile(IdApplicantProfileRequest request, ServerCallContext context)
        {
            Guid id = Guid.Parse(request.Id);
            return new Task<ApplicantProfile>(() => translateToProto(_logic.Get(id)));

        }

        public override Task<ApplicantProfiles> GetApplicantProfiles(Empty request, ServerCallContext context)
        {
            List<ApplicantProfile> protos = new List<ApplicantProfile>();

            foreach (var item in _logic.GetAll())
            {
                protos.Add(translateToProto(item));
            }

            ApplicantProfiles AppProfs = new ApplicantProfiles();
            AppProfs.AppJob.AddRange(protos);

            return new Task<ApplicantProfiles>(() => AppProfs);
        }

        public override Task<Empty> AddApplicantProfiles(ApplicantProfiles request, ServerCallContext context)
        {
            List<ApplicantProfilePoco> pocos = new List<ApplicantProfilePoco>();

            foreach (var item in request.AppJob)
            {
                pocos.Add(translateToPoco(item));
            }
            _logic.Add(pocos.ToArray());
            return Task.FromResult<Empty>(null);
        }

        public override Task<Empty> UpdateApplicantProfiles(ApplicantProfiles request, ServerCallContext context)
        {
            List<ApplicantProfilePoco> pocos = new List<ApplicantProfilePoco>();

            foreach (var item in request.AppJob)
            {
                pocos.Add(translateToPoco(item));
            }
            _logic.Update(pocos.ToArray());
            return Task.FromResult<Empty>(null);
        }

        public override Task<Empty> DeleteApplicantProfiles(ApplicantProfiles request, ServerCallContext context)
        {
            return base.DeleteApplicantProfiles(request, context);
        }
        private ApplicantProfile translateToProto(ApplicantProfilePoco poco)
        {
            ApplicantProfile proto = new ApplicantProfile();
            proto.Id = poco.Id.ToString();
            proto.Login = poco.Login.ToString();
            proto.CurrentSalary = poco.CurrentSalary;
            proto.CurrentRate = poco.CurrentRate;
            proto.Currency = poco.Currency.ToString();
            proto.Country = poco.Country.ToString();
            proto.Province = poco.Province.ToString();
            proto.Street = poco.Street.ToString();
            proto.City = poco.City.ToString();
            proto.PostalCode = poco.PostalCode.ToString();
            return proto;
        }

        private ApplicantProfilePoco translateToPoco(ApplicantProfile proto)
        {
            ApplicantProfilePoco poco = new ApplicantProfilePoco();
            poco.Id = Guid.Parse(proto.Id);
            poco.Login = Guid.Parse(proto.Login);
            poco.CurrentSalary = proto.CurrentSalary;
            poco.CurrentRate = proto.CurrentRate;
            poco.Currency = proto.Currency;
            poco.Country = proto.Country;
            poco.Province = proto.Province;
            poco.Street = proto.Street;
            poco.City = proto.City;
            poco.PostalCode = proto.PostalCode;
            return poco;
        }
    }

}
