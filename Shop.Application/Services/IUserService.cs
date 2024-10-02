using Shop.Domain.Dtos;
using Shop.Domain.Dtos.User;
using Shop.Domain.Repositories.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using Common.Cryptography;

namespace Shop.Application.Services
{
    public interface IUserService
    {
        public OperationResult<UserInfoDto> Login(LoginDto login);
        public Task<OperationResult> SignupAsync(CreateUserDto createUser,CancellationToken cancellationToken);
    }
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public OperationResult<UserInfoDto> Login(LoginDto login)
        {
            try
            {
                var user = _userRepository.CheckUserValid(login.Username, login.Password);

                return user;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message,ex.InnerException);
            }
        }

        public async Task<OperationResult> SignupAsync(CreateUserDto createUser, CancellationToken cancellationToken)
        {
            try
            {
                createUser.Password = createUser.Password.ToSha256();
                var signup = await _userRepository.CreateUserAsync(createUser, cancellationToken);

                return signup;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message,ex.InnerException);
            }
        }
    }
}
