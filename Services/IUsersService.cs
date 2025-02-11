using DTO.UserDTOs;

namespace Services
{
    public interface IUsersService
    {
        IEnumerable<UserListDTO> GetAll();

        int? GetUserId(string identifier);

        int CreateUser(UserCreateDTO userCreateDTO);

        void DeleteUser(int id);

        void UpdateUser(UserUpdateDTO userUpdateDTO);
    }
}
