using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web_24BM.Models;


namespace Web_24BM.Services
{
    public interface ICurriculum
    {
        Task<List<Curriculum>> GetAll();
        Task<ResponseHelper> Create(Curriculum model);
        Task<ResponseHelper> Update(Curriculum model);
        Task<Curriculum> GetById(int IdCurriculum);
        Task<ResponseHelper> Delete(int IdCurriculum);
    }
}
