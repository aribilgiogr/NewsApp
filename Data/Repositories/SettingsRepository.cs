using Core.Abstracts.IRepositories;
using Core.Concretes.Entities;
using Data.Contexts;
using Utilities.Generics;

namespace Data.Repositories
{
    public class SettingsRepository : Repository<Setting>, ISettingsRepository
    {
        public SettingsRepository(NewsContext context) : base(context)
        {
        }
    }
}
