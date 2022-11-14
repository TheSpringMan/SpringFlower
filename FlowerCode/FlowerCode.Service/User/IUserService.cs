using FlowerCode.Model.Entity;

namespace FlowerCode.Service;

public interface IUserService
{
    UserRes GetUser(UserReq req);

    List<UserRes> GetAllUser();

    UserRes Register(RegisterReq req, ref string msg);
}