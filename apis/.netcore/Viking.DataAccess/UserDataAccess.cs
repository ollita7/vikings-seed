using System;
using System.Linq;
using AutoMapper;
using Viking.Sdk;

namespace Viking.DataAccess
{
    public class UserDataAccess
    {
        private readonly IMapper _mapper;
        private readonly VikingContext _context;
        private readonly Security _security;


        public UserDataAccess(IMapper mapper)
        {
            _context = new VikingContext();
            _security = new Security();
            _mapper = mapper;
        }

        public RetornoDataOut Register(RegisterDataIn data)
        {
            try
            {
                if (_context.Users.Any(x => x.username == data.UserName || x.email == data.Email))
                    return new RetornoDataOut { Result = Retorno.Error, Msg = "Username or Email already exists" };

                data.Password = _security.CreatePasswordHash(data.Password);

                _context.Add(_mapper.Map<Users>(data));
                _context.SaveChanges();

                return new RetornoDataOut { Result = Retorno.Ok };
            }
            catch (Exception ex)
            {
                return new RetornoDataOut { Result = Retorno.Error, Msg = ex.Message };
            }
        }








    }
}