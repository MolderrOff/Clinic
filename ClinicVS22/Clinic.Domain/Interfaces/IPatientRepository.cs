using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clinic.Domain.Entities;

namespace Clinic.Domain.Interfaces
{
    public interface IPatientRepository
    {
        public Task<IEnumerable<Patient>> GetAllPatientAsyncD();
        public Task AddPatientAsyncD(Patient patient);
        public void UpdatePatientAsyncD(Patient patient);
        public Task<IEnumerable<Patient>> GetAllAsync();
        public Task<Patient?> GetByIdAsync(Guid id);
        public Task UpdateAsync(Patient patient);


    }
}
