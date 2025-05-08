using Microsoft.EntityFrameworkCore;
using MvcNetCoreAWSPostgresEC2.Data;
using MvcNetCoreAWSPostgresEC2.Models;

namespace MvcNetCoreAWSPostgresEC2.Repositories
{
    public class RepositoryHospital
    {
        private HospitalContext context;
        public RepositoryHospital( HospitalContext context)
        {
            this.context = context;
        }
        public async Task<List<Departamento>> GetDepartamentosAsync()
        {
            return await this.context.Departamento.ToListAsync();
        }
        public async Task<Departamento> FindDepartamento(int id)
        {
            return await this.context.Departamento.FirstOrDefaultAsync(x=>x.Id == id);
        }
        public async Task AddDepartamento( int id, string nombre, string localidad)
        {
            Departamento departamento = new Departamento();
            departamento.Id = id;
            departamento.Nombre = nombre;
            departamento.Localidad = localidad;
            this.context.Departamento.Add(departamento);
            await this.context.SaveChangesAsync();
        }
    }
}
