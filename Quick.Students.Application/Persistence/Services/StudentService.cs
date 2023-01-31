using Quick.Students.Application.Core.Services;
using Quick.Students.Domain.Entities;
using Quick.Students.Domain.Interfaces;

namespace Quick.Students.Application.Persistence.Services
{
public class StudentService : IStudentService
    {
        private readonly IUnitOfWork _unitOfWork;

        public StudentService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Student> Add(Student entity)
        {
            await _unitOfWork.StudentRepository.Add(entity);
            await _unitOfWork.Commit();
            return entity;
        }

        public async Task<Student> Delete(int id)
        {
            if (id > 0)
            {
                var family = await _unitOfWork.StudentRepository.GetFirst(x => x.Id == id);
                if (family == null) return new Student();
                await _unitOfWork.StudentRepository.Delete(family);
                await _unitOfWork.Commit();
            }
            return new Student();
        }

        public async Task<List<Student>> GetAll()
        {
            return await _unitOfWork.StudentRepository.GetAllList();
        }

        public async Task<Student?> GetFirst(int id)
        {
            return await _unitOfWork.StudentRepository.GetFirst(x => x.Id == id);
        }

        public async Task<Student> Update(Student entity)
        {
            var upEntity = await _unitOfWork.StudentRepository.Update(entity);
            await _unitOfWork.Commit();
            return upEntity;
        }

        public async Task<bool> IsAlreadyAdded(int id)
        {
            if (id == 0) return false;
            var element = await _unitOfWork.StudentRepository.Count(x => x.Id == id);
            if (element == 0) return false;
            else return true;
        }
    }
}