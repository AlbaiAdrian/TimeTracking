using AutoMapper;
using DTO.UserDTOs;
using Entity;
using Repository;

namespace Services
{
    public class UsersService : IUsersService
    {
        private readonly IRepository<User> _repository;
        private readonly IMapper _mapper;

        public UsersService(IRepository<User> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public int CreateUser(UserCreateDTO userCreateDTO)
        {
            User user = _mapper.Map<User>(userCreateDTO);
            return _repository.Add(user).Id;
        }

        public int? GetUserId(string identifier)
        {
            var user = _repository.GetFirstOrDefault(u => u.Identifier == identifier);
            if (user == null)
            {
                return null;
            }
            return user.Id;
        }

        public void DeleteUser(int id)
        {
            _repository.Delete(id);
        }

        public IEnumerable<UserListDTO> GetAll()
        {
            return _mapper.Map<IEnumerable<UserListDTO>>(_repository.GetAll());
        }

        public void UpdateUser(UserUpdateDTO userUpdateDTO)
        {
            _repository.Update(_mapper.Map<User>(userUpdateDTO));
        }
    }
}