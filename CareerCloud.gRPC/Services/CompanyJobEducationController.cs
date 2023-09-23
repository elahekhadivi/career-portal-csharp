using CareerCloud.BusinessLogicLayer;
using CareerCloud.EntityFrameworkDataAccess;
using CareerCloud.Pocos;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using static CareerCloud.gRPC.CompanyJobEducationService;

namespace CareerCloud.gRPC.Services
{
    public class CompanyJobEducationController: CompanyJobEducationServiceBase
    {
        private readonly CompanyJobEducationLogic _logic;

        public CompanyJobEducationController()
        {
            _logic = new CompanyJobEducationLogic(new EFGenericRepository<CompanyJobEducationPoco>());
        }

        public override Task<CompanyJobEducation> GetCompanyJobEducation(IdCompanyJobEducationRequest request, ServerCallContext context)
        {
            Guid id = Guid.Parse(request.Id);
            return new Task<CompanyJobEducation>(() => translateToProto(_logic.Get(id)));
        }

        public override Task<CompanyJobEducations> GetCompanyJobEducations(Empty request, ServerCallContext context)
        {
            List<CompanyJobEducation> protos = new List<CompanyJobEducation>();

            foreach (var item in _logic.GetAll())
            {
                protos.Add(translateToProto(item));
            }

            CompanyJobEducations COJEdus = new CompanyJobEducations();
            COJEdus.COJEdu.AddRange(protos);

            return new Task<CompanyJobEducations>(() => COJEdus);
        }

        public override Task<Empty> AddCompanyJobEducation(CompanyJobEducations request, ServerCallContext context)
        {
            List<CompanyJobEducationPoco> pocos = new List<CompanyJobEducationPoco>();

            foreach (var item in request.COJEdu)
            {
                pocos.Add(translateToPoco(item));
            }
            _logic.Add(pocos.ToArray());
            return Task.FromResult<Empty>(null);
        }

        public override Task<Empty> UpdateCompanyJobEducations(CompanyJobEducations request, ServerCallContext context)
        {
            List<CompanyJobEducationPoco> pocos = new List<CompanyJobEducationPoco>();

            foreach (var item in request.COJEdu)
            {
                pocos.Add(translateToPoco(item));
            }
            _logic.Update(pocos.ToArray());
            return Task.FromResult<Empty>(null);
        }

        public override Task<Empty> DeleteCompanyJobEducations(CompanyJobEducations request, ServerCallContext context)
        {
            List<CompanyJobEducationPoco> pocos = new List<CompanyJobEducationPoco>();

            foreach (var item in request.COJEdu)
            {
                pocos.Add(translateToPoco(item));
            }
            _logic.Delete(pocos.ToArray());
            return Task.FromResult<Empty>(null);
        }
        private CompanyJobEducationPoco translateToPoco(CompanyJobEducation proto)
        {
            return new CompanyJobEducationPoco()
            {
                Id = Guid.Parse(proto.Id),
                Job = Guid.Parse(proto.Job),
                Major = proto.Major,
                Importance = (Int16)(proto.Importance),

            };
        }

        private CompanyJobEducation translateToProto(CompanyJobEducationPoco poco)
        {
            return new CompanyJobEducation()
            {
                Id = poco.Id.ToString(),
                Job = poco.Job.ToString(),
                Major = poco.Major.ToString(),
                Importance = poco.Importance,
            };
        }


    }
}
