using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConfArch.Data;
using ConfArch.Data.Entities;
using ConfArch.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace ConfArch.Data.Repositories
{
    public class ProposalRepository : IProposalRepository
    {
        private readonly ConfArchDbContext dbContext;

        public ProposalRepository(ConfArchDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public Task<List<ProposalModel>> GetAllForConference(int conferenceId)
        {
            return dbContext.Proposals.Where(p => p.ConferenceId == conferenceId).Select(p => p.ToModel()).ToListAsync();
        }


        public Task<int> Add(ProposalModel model)
        {
            var entity = Proposal.FromModel(model);
            dbContext.Proposals.Add(entity);
            return dbContext.SaveChangesAsync();
        }

        public async Task<ProposalModel> Approve(int proposalId)
        {
            var proposal = await dbContext.Proposals.FirstAsync(p => p.Id == proposalId);
            proposal.Approved = true;
            await dbContext.SaveChangesAsync();
            return proposal.ToModel();
        }
    }
}
