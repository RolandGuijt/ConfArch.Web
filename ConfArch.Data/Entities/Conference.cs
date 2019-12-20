using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using ConfArch.Data.Models;

namespace ConfArch.Data.Entities
{
    public class Conference
    {
        public Conference()
        {
            Start = DateTime.Now;
        }
        public int Id { get; set; }

        [StringLength(250)]
        public string Name { get; set; }

        public DateTime Start { get; set; }

        [StringLength(250)]
        public string Location { get; set; }

        public List<Attendee> Attendees { get; set; }

        public ConferenceModel ToModel()
        {
            return new ConferenceModel
            {
                Id = Id,
                Location = Location,
                Name = Name,
                Start = Start,
                AttendeeCount = Attendees == null ? 0 : Attendees.Count()
            };
        }

        public static Conference FromModel(ConferenceModel model)
        {
            return new Conference
            {
                Location = model.Location,
                Name = model.Name,
                Start = model.Start
            };
        }
    }
}
