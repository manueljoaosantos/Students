using Quick.Students.Application.Core.Services;
using Quick.Students.Domain.Entities;
using Quick.Students.Domain.Interfaces;

namespace Quick.Students.Application.Persistence.Services
{
    public class GuradianTypeService : IGuradianTypeService
    {
        private readonly IUnitOfWork _unitOfWork;

        public GuradianTypeService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<GuardianType> Add(GuardianType entity)
        {
            await _unitOfWork.GuardianTypeRepository.Add(entity);
            await _unitOfWork.Commit();
            return entity;
        }

        public async Task<GuardianType> Delete(int id)
        {
            if (id > 0)
            {
                var family = await _unitOfWork.GuardianRepository.GetFirst(x => x.Id == id);
                if (family == null) return new GuardianType();
                await _unitOfWork.GuardianRepository.Delete(family);
                await _unitOfWork.Commit();
            }
            return new GuardianType();
        }

        public async Task<List<GuardianType>> GetAll()
        {
            return await _unitOfWork.GuardianTypeRepository.GetAllList();
        }

        public async Task<GuardianType?> GetFirst(int id)
        {
            return await _unitOfWork.GuardianTypeRepository.GetFirst(x => x.Id == id);
        }

        public async Task<GuardianType> Update(GuardianType entity)
        {
            var upEntity = await _unitOfWork.GuardianTypeRepository.Update(entity);
            await _unitOfWork.Commit();
            return upEntity;
        }

        public async Task<bool> IsAlreadyAdded(int id)
        {
            if (id == 0) return false;
            var element = await _unitOfWork.GuardianTypeRepository.Count(x => x.Id == id);
            if (element == 0) return false;
            else return true;
        }
    }
}