using System.Threading.Tasks;
using ConfArch.Data;
using ConfArch.Data.Entities;
using ConfArch.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace ConfArch.Data.Repositories
{
    public class AttendeeRepository : IAttendeeRepository
    {
        private readonly ConfArchDbContext dbContext;

        public AttendeeRepository(ConfArchDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public Task<int> Add(AttendeeModel attendee)
        {
            var entity = Attendee.FromModel(attendee);
            dbContext.Attendees.Add(entity);
            return dbContext.SaveChangesAsync();
        }

        public Task<int> GetAttendeesTotal(int conferenceId)
        {
            return dbContext.Attendees.CountAsync(a => a.ConferenceId == conferenceId);
        }
    }
}
