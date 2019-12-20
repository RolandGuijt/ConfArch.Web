using System.Collections.Generic;
using System.Threading.Tasks;
using ConfArch.Data.Models;

namespace ConfArch.Data.Repositories
{
    public interface IConferenceRepository
    {
        Task<int> Add(ConferenceModel model);
        Task<List<ConferenceModel>> GetAll();
        Task<ConferenceModel> GetById(int id);
    }
}