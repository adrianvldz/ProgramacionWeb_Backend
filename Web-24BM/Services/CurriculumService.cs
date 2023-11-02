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
                // Obtén el curriculum del repositorio
                Curriculum curriculum = await _Repository.GetById(IdCurriculum);

                // Verifica si la foto existe
                if (curriculum.NombreFoto != null)
                {
                    // Obtén la ruta de la foto
                    string filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Archivos", curriculum.NombreFoto);

                    // Elimina la foto
                    File.Delete(filePath);
                }

                // Elimina el curriculum del repositorio
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
                string filePath = "";
                string fileName = "";
                // Verifica si el usuario está enviando una nueva foto
                if (model.Foto != null && model.Foto.Length > 0)
                {
                    // Obtén el nombre del archivo de la foto
                    fileName = Path.GetFileName(model.Foto.FileName);

                    // Obtén la ruta de la foto
                    filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Archivos", fileName);

                    // Elimina la foto existente
                    File.Delete(filePath);

                    // Sobrescribe la foto existente con la nueva foto
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await model.Foto.CopyToAsync(fileStream);
                    }

                    // Actualiza la foto en la base de datos
                    model.NombreFoto = fileName;
                    if (await _Repository.Update(model) > 0)
                    {
                        response.Success = true;
                        response.Message = $"Se ha actualizado el Curriculum de '{model.Nombre}' con éxito.";
                    }
                }
                else
                {
                    // Si no se envía una nueva foto, no hay nada que hacer
                    if (await _Repository.Update(model) > 0)
                    {
                        response.Success = true;
                        response.Message = $"Se ha actualizado el Curriculum de '{model.Nombre}' con éxito.";
                    }
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
