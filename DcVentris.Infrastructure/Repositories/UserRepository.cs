using DcVentris.Domain.Entities;
using DcVentris.Domain.Interfaces.Repository;
using DcVentris.Infrastructure.Context;

namespace DcVentris.Infrastructure.Repositories
{
    public class UserRepository : Repository<User>, IUsuarioRepository
    {
        public UserRepository(DcVentrisContext context) : base(context)
        {
        }
    }
}
