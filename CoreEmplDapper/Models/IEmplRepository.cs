using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace CoreEmplDapper.Models
{
    public interface IEmplRepository
    {
        void Create(Empl user);
        void Delete(int id);
        Empl Get(int id);
        List<Empl> GetEmpls();
        void Update(Empl user);
    }
}
