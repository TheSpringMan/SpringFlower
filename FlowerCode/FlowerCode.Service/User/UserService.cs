using FlowerCode.Common;
using AutoMapper;
using FlowerCode.Model.Entity;

namespace FlowerCode.Service;

public class UserService : IUserService
{
    private readonly FlowerDbContext dbContext;
    private readonly IMapper mapper;
    public UserService(FlowerDbContext dbContext, IMapper mapper)
    {
        this.dbContext = dbContext;
        this.mapper = mapper;
    }

    public UserRes GetUser(UserReq req)
    {
        var user = this.dbContext.Users.FirstOrDefault(x => x.UserName == req.UserName && x.Password == req.Password);
        return user != null ? mapper.Map<UserRes>(user) : null;
    }

    public List<UserRes> GetAllUser()
    {
        var list = this.dbContext.Users.ToList();
        return list != null ? mapper.Map<List<UserRes>>(list) : null;
    }

    public UserRes Register(RegisterReq req, ref string msg)
    {
        var user = this.dbContext.Users.FirstOrDefault(x => x.UserName == req.UserName);
        if (user != null)
        {
            msg = "账号已存在！";
            return mapper.Map<UserRes>(user);
        }
        else
        {
            User user1 = mapper.Map<User>(req);
            user1.CreateTime = DateTime.Now;
            user1.UserType = (int)FlowerCode.Model.Enum.EnumUserType.普通用户;
            dbContext.Users.Add(user1);
            bool res = dbContext.SaveChanges() > 0;
            if (res)
            {
                msg = "注册成功";
                user = dbContext.Users.FirstOrDefault(x => x.UserName == req.UserName && x.Password == req.Password);
                return mapper.Map<UserRes>(user);
            }
            else
            {
                msg = "注册失败";
                return null;
            }
        }
    }
}