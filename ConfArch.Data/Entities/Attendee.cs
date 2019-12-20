using System.ComponentModel.DataAnnotations;
using ConfArch.Data.Models;

namespace ConfArch.Data.Entities
{
    public class Attendee
    {
        public int Id { get; set; }
        public int ConferenceId { get; set; }
        public Conference Conference { get; set;}

        [StringLength(250)]
        public string Name { get; set; }

        public static Attendee FromModel(AttendeeModel model)
        {
            return new Attendee
            {
                ConferenceId = model.ConferenceId,
                Name = model.Name
            };
        }
    }
}
