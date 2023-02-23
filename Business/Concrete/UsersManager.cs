using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class UsersManager : IUsersService
    {
        IUsersDal _users;

        public UsersManager(IUsersDal users)
        {
            _users = users;
        }
        public IResult Add(Users users)
        {
            _users.Add(users);
            return new SuccessResult(Messages.UsersAdded);
        }

        public IResult Delete(Users users)
        {
            _users.Delete(users);
            return new SuccessResult(Messages.UsersDeleted);
        }

        public IDataResult<List<Users>> GetAll()
        {
            throw new NotImplementedException();
        }

        public IDataResult<Users> GetById(int usersId)
        {
            throw new NotImplementedException();
        }

        public IResult Update(Users users)
        {
            _users.Update(users);
            return new SuccessResult(Messages.UsersUpdated);
        }
    }
}
