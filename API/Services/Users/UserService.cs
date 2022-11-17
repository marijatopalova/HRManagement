using API.DTOs.Users;
using Domain.Interfaces;
using Domain.Users;

namespace API.Services.Users
{
    public class UserService : BaseService
    {
        public UserService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public async Task<AddUserResponse> AddNewAsync(AddUserRequest request)
        {
            var user = new User(request.UserName,
                request.FirstName,
                request.LastName,
                request.Address,
                request.DepartmentId,
                request.BirthDate);

            var repository = UnitOfWork.AsyncRepository<User>();
            await repository.AddAsync(user);
            await UnitOfWork.SaveChangesAsync();

            var response = new AddUserResponse()
            {
                Id = user.Id,
                UserName = user.UserName
            };

            return response;
        }

        public async Task<AddPayslipResponse> AddUserPayslipAsync(AddPayslipRequest request)
        {
            var repository = UnitOfWork.AsyncRepository<User>();
            var user = await repository.GetAsync(_ => _.Id == request.UserId);
            if (user != null)
            {
                var payslip = user.AddPayslip(request.Date.Value
                    , request.WorkingDays.Value
                    , request.Bonus
                    , request.IsPaid.Value);

                await repository.UpdateAsync(user);
                await UnitOfWork.SaveChangesAsync();

                return new AddPayslipResponse()
                {
                    UserId = user.Id,
                    TotalSalary = payslip.TotalSalary
                };
            }

            throw new Exception("User not found.");
        }

        public async Task<List<GetUserListResponse>> SearchAsync(GetUserListRequest request)
        {
            var repository = UnitOfWork.AsyncRepository<User>();
            var users = await repository
                .ListAsync(_ => _.UserName.Contains(request.Search));

            var userDTOs = users.Select(_ => new GetUserListResponse()
            {
                Address = _.Address,
                BirthDate = _.BirthDate,
                DepartmentId = _.DepartmentId,
                FirstName = _.FirstName,
                Id = _.Id,
                LastName = _.LastName,
                UserName = _.UserName
            })
            .ToList();

            return userDTOs;
        }
    }
}
