using FluentNHibernate.Mapping;
using Microsoft.AspNet.Identity.EntityFramework;
using FinancialSystem.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinancialSystem.Models.UserModels
{

    public class UserRoleModel : ILongIdentifiable
    {
        public virtual long Id { get; set; }
        public virtual string Name { get; set; }
        public virtual DateTime? Deleted { get; set; }
    }

    public class UserRoleModelMap : ClassMap<UserRoleModel>
    {
        public UserRoleModelMap()
        {
            Id(x => x.Id);
            Map(x => x.Name);
            Map(x => x.Deleted);
        }
    }
}