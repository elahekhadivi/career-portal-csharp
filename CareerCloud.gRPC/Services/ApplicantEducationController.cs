using CareerCloud.BusinessLogicLayer;
using CareerCloud.EntityFrameworkDataAccess;
using CareerCloud.Pocos;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using static CareerCloud.gRPC.ApplicantEducationService;

namespace CareerCloud.gRPC.Services
{
    public class ApplicantEducationController : ApplicantEducationServiceBase
    {
        private readonly ApplicantEducationLogic _logic;

        public ApplicantEducationController()
        {
            _logic = new ApplicantEducationLogic(new EFGenericRepository<ApplicantEducationPoco>());
        }


        public override Task<ApplicantEducation> GetApplicantEducation(IdRequest request, ServerCallContext context)
        {
            Guid id = Guid.Parse(request.Id);
            return new Task<ApplicantEducation>(() => translateTo(_logic.Get(id)));
        }

        public override Task<ApplicantEducations> GetApplicantEducations(Empty request, ServerCallContext context)
        {
            List<ApplicantEducation> protos = new List<ApplicantEducation>();

            foreach (var item in _logic.GetAll())
            {
                protos.Add(translateTo(item));
            }

            ApplicantEducations appEdus = new ApplicantEducations();
            appEdus.AppEdu.AddRange(protos);

            return new Task<ApplicantEducations>(() => appEdus);
        }
        public override Task<Empty> AddApplicantEducation(ApplicantEducations request, ServerCallContext context)
        {
            List<ApplicantEducationPoco> pocos = new List<ApplicantEducationPoco>();

            foreach (var item in request.AppEdu)
            {
                pocos.Add(translateFrom(item));
            }
            _logic.Add(pocos.ToArray());
            return Task.FromResult<Empty>(null);
        }

        public override Task<Empty> UpdateApplicantEducations(ApplicantEducations request, ServerCallContext context)
        {
            List<ApplicantEducationPoco> pocos = new List<ApplicantEducationPoco>();

            foreach (var item in request.AppEdu)
            {
                pocos.Add(translateFrom(item));
            }
            _logic.Update(pocos.ToArray());
            return Task.FromResult<Empty>(null);
        }

        public override Task<Empty> DeleteApplicantEducations(ApplicantEducations request, ServerCallContext context)
        {
            List<ApplicantEducationPoco> pocos = new List<ApplicantEducationPoco>();

            foreach (var item in request.AppEdu)
            {
                pocos.Add(translateFrom(item));
            }
            _logic.Delete(pocos.ToArray());
            return Task.FromResult<Empty>(null);
        }


        private ApplicantEducationPoco translateFrom(ApplicantEducation proto)
        {
            ApplicantEducationPoco poco = new ApplicantEducationPoco();
            poco.Id = Guid.Parse(proto.Id);
            poco.Applicant = Guid.Parse(proto.Applicant);
            poco.Major = proto.Major;
            poco.CertificateDiploma = proto.CertificateDiploma;
            poco.StartDate = proto.StartDate.ToDateTime();
            poco.CompletionDate = proto.CompletionDate.ToDateTime();
            poco.CompletionPercent = (byte?)proto.CompletionPercent;

            return poco;
        }
        private ApplicantEducation translateTo(ApplicantEducationPoco poco)
        {
            return new ApplicantEducation()
            {
                Id = poco.Id.ToString(),
                Applicant = poco.Applicant.ToString(),
                Major = poco.Major,
                CertificateDiploma = poco.CertificateDiploma,
                StartDate = poco.StartDate == null ? null : Timestamp.FromDateTime((DateTime)poco.StartDate),
                CompletionDate = poco.CompletionDate == null ? null : Timestamp.FromDateTime((DateTime)poco.CompletionDate),
                CompletionPercent = poco.CompletionPercent,
            };
        }
    }
}
