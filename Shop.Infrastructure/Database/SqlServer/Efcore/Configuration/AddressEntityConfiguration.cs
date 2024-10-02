﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Domain.Entities.Profile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Infrastructure.Database.SqlServer.Efcore.Configuration
{
    internal class AddressEntityConfiguration : IEntityTypeConfiguration<UserAddressModel>
    {
        public void Configure(EntityTypeBuilder<UserAddressModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.ToTable("Tbl_Address");
            builder.HasOne(x => x.UserInformation)
                .WithMany(x => x.UserAddresses)
                .HasForeignKey(x => x.UserInformationId);
        }
    }
}
