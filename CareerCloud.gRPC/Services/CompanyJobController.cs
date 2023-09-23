using CareerCloud.BusinessLogicLayer;
using CareerCloud.EntityFrameworkDataAccess;
using CareerCloud.Pocos;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using static CareerCloud.gRPC.CompanyJobService;

namespace CareerCloud.gRPC.Services
{
    public class CompanyJobController :CompanyJobServiceBase
    {
        private readonly CompanyJobLogic _logic;

        public CompanyJobController()
        {
            _logic = new CompanyJobLogic(new EFGenericRepository<CompanyJobPoco>());
        }

        public override Task<CompanyJob> GetCompanyJob(CompanyJobIdRequest request, ServerCallContext context)
        {
            Guid id = Guid.Parse(request.Id);
            return new Task<CompanyJob>(() => translateToProto(_logic.Get(id)));
        }

        public override Task<CompanyJobs> GetCompanyJobs(Empty request, ServerCallContext context)
        {
            List<CompanyJob> protos = new List<CompanyJob>();

            foreach (var item in _logic.GetAll())
            {
                protos.Add(translateToProto(item));
            }

            CompanyJobs COJs = new CompanyJobs();
            COJs.COJ.AddRange(protos);

            return new Task<CompanyJobs>(() => COJs); return base.GetCompanyJobs(request, context);
        }

        public override Task<Empty> AddCompanyJobs(CompanyJobs request, ServerCallContext context)
        {

            List<CompanyJobPoco> pocos = new List<CompanyJobPoco>();

            foreach (var item in request.COJ)
            {
                pocos.Add(translateToPoco(item));
            }
            _logic.Add(pocos.ToArray());
            return Task.FromResult<Empty>(null);
        }

        public override Task<Empty> UpdateCompanyJobs(CompanyJobs request, ServerCallContext context)
        {
            List<CompanyJobPoco> pocos = new List<CompanyJobPoco>();

            foreach (var item in request.COJ)
            {
                pocos.Add(translateToPoco(item));
            }
            _logic.Update(pocos.ToArray());
            return Task.FromResult<Empty>(null);
        }

        public override Task<Empty> DeleteCompanyJobs(CompanyJobs request, ServerCallContext context)
        {
            List<CompanyJobPoco> pocos = new List<CompanyJobPoco>();

            foreach (var item in request.COJ)
            {
                pocos.Add(translateToPoco(item));
            }
            _logic.Delete(pocos.ToArray());
            return Task.FromResult<Empty>(null);
        }

        private CompanyJob translateToProto(CompanyJobPoco poco)
        {
            return new CompanyJob()
            {
                Id = poco.Id.ToString(),
                Company = poco.Company.ToString(),
                ProfileCreated = poco.ProfileCreated == null ? null : Timestamp.FromDateTime((DateTime)poco.ProfileCreated),
                IsInactive = poco.IsInactive,   
                 IsCompanyHidden = poco.IsCompanyHidden,

            };
        }

        private CompanyJobPoco translateToPoco(CompanyJob proto)
        {
            return new CompanyJobPoco()
            {
                Id = Guid.Parse(proto.Id),
                Company = Guid.Parse(proto.Company),
                ProfileCreated = proto.ProfileCreated.ToDateTime(),
                IsInactive = proto.IsInactive,
                IsCompanyHidden = proto.IsCompanyHidden,

            };
        }
    }
}
