using WebCalendar.Common.Contracts;
using WebCalendar.DAL.EF.Context;

namespace WebCalendar.DAL.EF
{
    public class EFDataInitializer : IDataInitializer
    {
        private readonly ApplicationDbContext _context;

        public EFDataInitializer(ApplicationDbContext context)
        {
            _context = context;
        }
        
        public void Seed()
        {
            throw new System.NotImplementedException();
        }
    }
}