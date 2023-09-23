using CareerCloud.BusinessLogicLayer;
using CareerCloud.EntityFrameworkDataAccess;
using CareerCloud.Pocos;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using static CareerCloud.gRPC.CompanyDescriptionService;

namespace CareerCloud.gRPC.Services
{
    public class CompanyDescriptionController : CompanyDescriptionServiceBase
    {
        private readonly CompanyDescriptionLogic _logic;

        public CompanyDescriptionController()
        {
            _logic = new CompanyDescriptionLogic(new EFGenericRepository<CompanyDescriptionPoco>());
        }
        public override Task<CompanyDescription> GetCompanyDescription(IdCompanyDescriptionRequest request, ServerCallContext context)
        {
            Guid id = Guid.Parse(request.Id);
            return new Task<CompanyDescription>(() => translateToProto(_logic.Get(id)));
        }

        public override Task<CompanyDescriptions> GetCompanyDescriptions(Empty request, ServerCallContext context)
        {
            List<CompanyDescription> protos = new List<CompanyDescription>();

            foreach (var item in _logic.GetAll())
            {
                protos.Add(translateToProto(item));
            }

            CompanyDescriptions CODescs = new CompanyDescriptions();
            CODescs.CODesc.AddRange(protos);

            return new Task<CompanyDescriptions>(() => CODescs);
        }

        public override Task<Empty> AddCompanyDescriptions(CompanyDescriptions request, ServerCallContext context)
        {
            List<CompanyDescriptionPoco> pocos = new List<CompanyDescriptionPoco>();

            foreach (var item in request.CODesc)
            {
                pocos.Add(translateToPoco(item));
            }
            _logic.Add(pocos.ToArray());
            return Task.FromResult<Empty>(null);
        }

        public override Task<Empty> UpdateCompanyDescriptions(CompanyDescriptions request, ServerCallContext context)
        {
            List<CompanyDescriptionPoco> pocos = new List<CompanyDescriptionPoco>();

            foreach (var item in request.CODesc)
            {
                pocos.Add(translateToPoco(item));
            }
            _logic.Update(pocos.ToArray());
            return Task.FromResult<Empty>(null);
        }

        public override Task<Empty> DeleteCompanyDescriptions(CompanyDescriptions request, ServerCallContext context)
        {
            List<CompanyDescriptionPoco> pocos = new List<CompanyDescriptionPoco>();

            foreach (var item in request.CODesc)
            {
                pocos.Add(translateToPoco(item));
            }
            _logic.Delete(pocos.ToArray());
            return Task.FromResult<Empty>(null);
        }

        private CompanyDescription translateToProto(CompanyDescriptionPoco poco)
        {
            return new CompanyDescription
            {

                Id = poco.Id.ToString(),
                Company = poco.Company.ToString(),
                LanguageId = poco.LanguageId.ToString(),
                CompanyName = poco.CompanyName.ToString(),
                CompanyDescription1 = poco.CompanyDescription.ToString(),

            };
        }

        private CompanyDescriptionPoco translateToPoco(CompanyDescription proto)
        {
            CompanyDescriptionPoco poco = new CompanyDescriptionPoco();
            poco.Id = Guid.Parse(proto.Id);
            poco.Company = Guid.Parse(proto.Company);
            poco.LanguageId = proto.LanguageId;
            poco.CompanyName = proto.CompanyName;
            poco.CompanyDescription = proto.CompanyDescription1;
            return poco;
        }
    }
}
