using Repository;
using Repository.Context;
using Web_24BM.Models;


namespace Web_24BM.Services
{


    public class CurriculumService : ICurriculum
    {
        private readonly CurriculumRepository _Repository;

        public CurriculumService(ApplicationDbContext context)
        {
            _Repository = new CurriculumRepository(context);
        }

        public async Task<ResponseHelper> Create(Curriculum model)
        {
            ResponseHelper response = new ResponseHelper();
            try
            {
                string filePath = "";
                string fileName = "";
                if (model.Foto != null && model.Foto.Length > 0)
                {
                    fileName = Path.GetFileName(model.Foto.FileName);
                    filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Archivos", fileName);

                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await model.Foto.CopyToAsync(fileStream);
                    }

                }
                model.NombreFoto = fileName;
                var result = await _Repository.Create(model);
                if (result > 0)
                {
                    response.Success = true;
                    response.Message = $"Se agrego la evidencia '{model.Nombre}' correctamente";
                }
            }
            catch (Exception e)
            {
                response.Message = e.Message;
            }
            return response;
        }

        public async Task<ResponseHelper> Delete(int IdCurriculum)
        {
            ResponseHelper response = new ResponseHelper();

            try
            {
                if (await _Repository.Delete(IdCurriculum) > 0)
                {
                    response.Success = true;
                    response.Message = "Se ha eliminado el registro con éxito.";
                }
            }
            catch (Exception e)
            {
                response.Message = e.Message;
            }

            return response;
        }

        public async Task<List<Curriculum>> GetAll()
        {
            List<Curriculum> list = new List<Curriculum>();
            try
            {
                list = await _Repository.GetAll();
            }
            catch (Exception e)
            {


            }
            return list;
        }

        public async Task<Curriculum> GetById(int IdCurriculum)
        {
            Curriculum curriculum = new Curriculum();
            try
            {
                curriculum = await _Repository.GetById(IdCurriculum);
            }
            catch (Exception e)
            {

            }
            return curriculum;
        }

        public async Task<ResponseHelper> Update(Curriculum model)
        {
            ResponseHelper response = new ResponseHelper();

            try
            {
                if (await _Repository.Update(model) > 0)
                {
                    response.Success = true;
                    response.Message = $"Se ha actualizado el dato {model.Nombre} con éxito.";
                }
            }
            catch (Exception e)
            {
                response.Message = e.Message;

            }

            return response;
        }
    }
}
