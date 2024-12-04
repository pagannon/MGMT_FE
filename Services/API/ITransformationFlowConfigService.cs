namespace OTD.MappingService.ConfigUI.Services.API
{
    using OTD.MappingService.Domain.Model.Models.DTOs;
    using Refit;

    public interface ITransformationFlowConfigService
    {
        [Get("/api/v1/config/appinstancetransformationflow")]
        Task<IEnumerable<TransformationFlow>> GetAll(CancellationToken cancellationToken = default);

        [Get("/api/v1/config/appinstancetransformationflow/{transformationFlowId}/")]
        Task<IEnumerable<TransformationFlow>> GetById(int transformationFlowId, CancellationToken cancellationToken = default);

        [Post("/api/v1/config/appinstancetransformationflow")]
        Task<IEnumerable<TransformationFlow>> Create([Body] TransformationFlow TtansformationFlow, CancellationToken cancellationToken = default);

        [Put("/api/v1/config/appinstancetransformationflow/{transformationFlowId}/")]
        Task<IEnumerable<TransformationFlow>> Update(int transformationFlowId, [Body] TransformationFlow transformationFlow, CancellationToken cancellationToken = default);

        [Delete("/api/v1/config/appinstancetransformationflow/{transformationFlowId}/")]
        Task<IEnumerable<TransformationFlow>> Delete(int transformationFlowId, CancellationToken cancellationToken = default);
    }
}
