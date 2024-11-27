namespace OTD.MappingService.ConfigUI.Services.API
{
    using OTD.MappingService.Domain.Model.Models.DTOs;
    using Refit;

    public interface IAppInstanceConfigService
    {
        [Get("/api/v1/config/appinstance")]
        Task<IEnumerable<AppInstance>> GetAll(CancellationToken cancellationToken = default);

        [Get("/api/v1/config/appinstance/{appinstanceId}/")]
        Task<IEnumerable<AppInstance>> GetById(int appinstanceId, CancellationToken cancellationToken = default);

        [Post("/api/v1/config/appinstance")]
        Task<IEnumerable<AppInstance>> Create([Body] AppInstance appInstance, CancellationToken cancellationToken = default);

        [Put("/api/v1/config/appinstance/{appinstanceId}/")]
        Task<IEnumerable<AppInstance>> Update(int appinstanceId, [Body] AppInstance appInstance, CancellationToken cancellationToken = default);

        [Delete("/api/v1/config/appinstance/{appinstanceId}/")]
        Task<IEnumerable<AppInstance>> Delete(int appinstanceId, CancellationToken cancellationToken = default);
    }
}
