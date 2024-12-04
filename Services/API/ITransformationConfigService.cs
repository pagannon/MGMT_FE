namespace OTD.MappingService.ConfigUI.Services.API
{
    using OTD.MappingService.Domain.Model.Models.DTOs;
    using Refit;

    public interface ITransformationConfigService
    {
        [Get("/api/v1/config/transformation")]
        Task<IEnumerable<Transformation>> GetAll(CancellationToken cancellationToken = default);

        [Get("/api/v1/config/transformation/{transformationId}/")]
        Task<IEnumerable<Transformation>> GetById(int transformationId, CancellationToken cancellationToken = default);

        [Post("/api/v1/config/transformation")]
        Task<IEnumerable<Transformation>> Create([Body] Transformation transformation, CancellationToken cancellationToken = default);

        [Put("/api/v1/config/transformation/{transformationId}/")]
        Task<IEnumerable<Transformation>> Update(int transformationId, [Body] Transformation transformation, CancellationToken cancellationToken = default);

        [Delete("/api/v1/config/transformation/{transformationId}/")]
        Task<IEnumerable<Transformation>> Delete(int transformationId, CancellationToken cancellationToken = default);
    }
}
