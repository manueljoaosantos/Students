using Quick.Students.Domain.Entities;

namespace Quick.Students.Application.Core.Services
{
    public interface IFamiliesService : IBaseService<Family>
    {
        Task<bool> IsAlreadyAddedCode(string code);
    }
}