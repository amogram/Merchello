﻿using System;
using Umbraco.Core.Persistence;
using Umbraco.Core.Persistence.DatabaseAnnotations;

namespace Merchello.Core.Models.Rdbms
{
    [TableName("merchCustomer")]
    [PrimaryKey("id")]
    [ExplicitColumns]
    internal class CustomerDto
    {
        [Column("id")]
        [PrimaryKeyColumn]
        public int Id { get; set; }

        [Column("memberId")]
        [NullSetting(NullSetting = NullSettings.Null)]
        public int? MemberId { get; set; }

        [Column("firstName")]
        public string FirstName { get; set; }

        [Column("lastName")]
        public string LastName { get; set; }

        [Column("email")]
        public string Email { get; set; }

        [Column("totalInvoiced")]
        public decimal TotalInvoiced { get; set; }

        [Column("totalPayments")]
        public decimal TotalPayments { get; set; }

        [Column("lastPaymentDate")]
        [NullSetting(NullSetting = NullSettings.Null)]
        public DateTime? LastPaymentDate { get; set; }

        [Column("lastActivityDate")]
        [Constraint(Default = "getdate()")]
        public DateTime LastActivityDate { get; set; }

        [Column("entityKey")]
        [Constraint(Default = "newid()")]
        public Guid EntityKey { get; set; }

        [Column("updateDate")]
        [Constraint(Default = "getdate()")]
        public DateTime UpdateDate { get; set; }

        [Column("createDate")]
        [Constraint(Default = "getdate()")]
        public DateTime CreateDate { get; set; }
        
    }
}