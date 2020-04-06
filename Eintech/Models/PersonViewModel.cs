using Eintech.DAL.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Eintech.Models
{
    public class PersonViewModel
    {
        public PersonViewModel() { }

        public PersonViewModel(IEnumerable<Group> groups)
        {
            Groups = groups.Select(x =>
                        new SelectListItem
                        {
                            Value = x.Id.ToString(),
                            Text = x.Name
                        });
        }

        public int Id { get; set; }
        
        [Required]
        public string Name { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy/MM/dd}")]
        [Display(Name = "Date Added")]
        public DateTime DateAdded { get; set; }

        public virtual GroupViewModel Group { get; set; }

        [Required]
        [BindProperty]
        [Display(Name = "Person's Group")]
        public int GroupId { get; set; }
        public IEnumerable<SelectListItem> Groups { get; set; }
    }
}
