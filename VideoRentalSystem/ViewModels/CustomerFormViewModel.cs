using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VideoRentalSystem.Models;
using System.Data.Entity;

namespace VideoRentalSystem.ViewModels
{
    public class CustomerFormViewModel
    {
        public List<MembershipType> MembershipTypes { get; set; }
        public Customer Customer { get; set; }
        public bool New { get; set; }
    }
}