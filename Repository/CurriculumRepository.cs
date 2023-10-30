using Microsoft.EntityFrameworkCore;
using Repository.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web_24BM.Models;

namespace Repository
{
    public class CurriculumRepository
    {
        private readonly ApplicationDbContext _context;

        public CurriculumRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Curriculum>> GetAll()
        {
            return await _context.Curriculums.ToListAsync();
        }

        public async Task<int> Create(Curriculum model)
        {
            _context.Curriculums.Add(model);
            return await _context.SaveChangesAsync();
        }
        public async Task<int> Update(Curriculum model)
        {
            _context.Curriculums.Update(model);
            return await _context.SaveChangesAsync();
        }
        public async Task<Curriculum> GetById(int IdEvidencia)
        {
            return _context.Curriculums.Find(IdEvidencia);
            //return _context.EvidenciaAprendizajes.FirstOrDefault(x => x.Id == IdEvidencia);
            //return _context.EvidenciaAprendizajes.Where( x => x.Id == IdEvidencia);

        }
        public async Task<int> Delete(int IdEvidencia)
        {
            var evidencia = _context.Curriculums.Find(IdEvidencia);
            _context.Curriculums.Remove(evidencia);
            return await _context.SaveChangesAsync();
        }
    }
}
