using BankingWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace BankingWebAPI.EntityFramework
{
    public class BankManagementConfiguration : EntityTypeConfiguration<Customer>
    {
        public BankManagementConfiguration()
        {
            this.ToTable("MyTable", "MyTableSchema");
        }
    }
}