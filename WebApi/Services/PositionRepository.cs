using WebApi.Data;
using WebApi.Models;

namespace WebApi.Services
{
    public class PositionRepository : IRepository<PositionModel, PositionEntity>
    {
        private MyDbContext _context;
        public PositionRepository(MyDbContext context)
        {
            _context = context;
        }
        public PositionModel Add(PositionEntity e)
        {
            _context.Positions.Add(e);
            _context.SaveChanges();
            return new PositionModel
            {
                Id = e.PositionID,
                Name = e.Name,
            };
        }

        public void Delete(int id)
        {
            var e = _context.Positions.SingleOrDefault(e => e.PositionID == id);
            if (e != null)
            {
                _context.Positions.Remove(e);
                _context.SaveChanges();
            }
        }

        public PositionModel Get(int id)
        {
            var e = _context.Positions.SingleOrDefault(e => e.PositionID == id);
            if (e != null)
            {
                return new PositionModel
                {
                    Id = e.PositionID,
                    Name = e.Name,
                };
            }
            return null;
        }

        public List<PositionModel> GetAll()
        {
            return _context.Positions.Select(e => new PositionModel
            {
                Id = e.PositionID,
                Name = e.Name,
            }).OrderBy(e => e.Id).ToList();
        }

        public void Update(PositionModel t)
        {
            var e = _context.Positions.SingleOrDefault(e => e.PositionID == t.Id);
            if (e != null)
            {
                e.Name = t.Name;
                _context.SaveChanges();
            }
        }
    }
}
