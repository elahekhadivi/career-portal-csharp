using CareerCloud.BusinessLogicLayer;
using CareerCloud.EntityFrameworkDataAccess;
using CareerCloud.Pocos;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using static CareerCloud.gRPC.ApplicantJobApplicationService;

namespace CareerCloud.gRPC.Services
{
    public class ApplicantJobApplicationController : ApplicantJobApplicationServiceBase
    {
        private readonly ApplicantJobApplicationLogic _logic;

        public ApplicantJobApplicationController()
        {
            _logic = new ApplicantJobApplicationLogic(new EFGenericRepository<ApplicantJobApplicationPoco>());
        }


        public override Task<ApplicantJobApplication> GetApplicantJobApplication(IdApplicantJobApplicationRequest request, ServerCallContext context)
        {
            Guid id = Guid.Parse(request.Id);
            return new Task<ApplicantJobApplication>(() => translateTo(_logic.Get(id)));
        }

        public override Task<ApplicantJobApplications> GetApplicantJobApplications(Empty request, ServerCallContext context)
        {
            List<ApplicantJobApplication> protos = new List<ApplicantJobApplication>();

            foreach (var item in _logic.GetAll())
            {
                protos.Add(translateTo(item));
            }

            ApplicantJobApplications AppJobs = new ApplicantJobApplications();
            AppJobs.AppJob.AddRange(protos);

            return new Task<ApplicantJobApplications>(() => AppJobs);
        }
        public override Task<Empty> AddApplicantJobApplications(ApplicantJobApplications request, ServerCallContext context)
        {
            List<ApplicantJobApplicationPoco> pocos = new List<ApplicantJobApplicationPoco>();

            foreach (var item in request.AppJob)
            {
                pocos.Add(translateFrom(item));
            }
            _logic.Add(pocos.ToArray());
            return Task.FromResult<Empty>(null);
        }

        public override Task<Empty> UpdateApplicantJobApplications(ApplicantJobApplications request, ServerCallContext context)
        {
            List<ApplicantJobApplicationPoco> pocos = new List<ApplicantJobApplicationPoco>();

            foreach (var item in request.AppJob)
            {
                pocos.Add(translateFrom(item));
            }
            _logic.Update(pocos.ToArray());
            return Task.FromResult<Empty>(null);
        }

        public override Task<Empty> DeleteApplicantJobApplications(ApplicantJobApplications request, ServerCallContext context)
        {
            List<ApplicantJobApplicationPoco> pocos = new List<ApplicantJobApplicationPoco>();

            foreach (var item in request.AppJob)
            {
                pocos.Add(translateFrom(item));
            }
            _logic.Delete(pocos.ToArray());
            return Task.FromResult<Empty>(null);
        }


        private ApplicantJobApplicationPoco translateFrom(ApplicantJobApplication proto)
        {
            ApplicantJobApplicationPoco poco = new ApplicantJobApplicationPoco();
            poco.Id = Guid.Parse(proto.Id);
            poco.Applicant = Guid.Parse(proto.Applicant);
            poco.Job = Guid.Parse(proto.Job);
            poco.ApplicationDate = proto.ApplicationDate.ToDateTime();
            return poco;
        }
        private ApplicantJobApplication translateTo(ApplicantJobApplicationPoco poco)
        {
            return new ApplicantJobApplication()
            {
                Id = poco.Id.ToString(),
                Applicant = poco.Applicant.ToString(),
                Job = poco.Job.ToString(),
                ApplicationDate = poco.ApplicationDate == null ? null : Timestamp.FromDateTime((DateTime)poco.ApplicationDate)

            };
        }
    }
}
