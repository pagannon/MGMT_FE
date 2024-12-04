namespace OTD.MappingService.ConfigUI.Services.API
{
    using OTD.MappingService.Domain.Model.Models.DTOs;
    using Refit;

    public interface IMappingModelConfigService
    {
        [Get("/api/v1/config/MappingModel")]
        Task<IEnumerable<MappingModel>> GetAll(CancellationToken cancellationToken = default);

        [Get("/api/v1/config/MappingModel/{mappingModelId}/")]
        Task<IEnumerable<MappingModel>> GetById(int mappingModelId, CancellationToken cancellationToken = default);

        [Post("/api/v1/config/MappingModel")]
        Task<IEnumerable<MappingModel>> Create([Body] MappingModel mappingModel, CancellationToken cancellationToken = default);

        [Put("/api/v1/config/MappingModel/{mappingModelId}/")]
        Task<IEnumerable<MappingModel>> Update(int mappingModelId, [Body] MappingModel mappingModel, CancellationToken cancellationToken = default);

        [Delete("/api/v1/config/MappingModel/{mappingModelId}/")]
        Task<IEnumerable<MappingModel>> Delete(int mappingModelId, CancellationToken cancellationToken = default);

        [Get("/api/v1/config/MappingModel/{appInstanceConfigId}/export")]
        Task<IEnumerable<ImportModel>> Export(int appInstanceConfigId, CancellationToken cancellationToken = default);

        [Get("/api/v1/config/MappingModel/{appInstanceConfigId}/import")]
        Task<IEnumerable<ImportModel>> Import(int appInstanceConfigId, [Body] ImportModel importModel, CancellationToken cancellationToken = default);

    }
}
