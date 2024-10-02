﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Domain.Entities.BaseData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Infrastructure.Database.SqlServer.Efcore.Configuration
{
    internal class CityEntityConfiguration : IEntityTypeConfiguration<CityModel>
    {
        public void Configure(EntityTypeBuilder<CityModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.ToTable("Tbl_City");
            builder.HasMany(x => x.Provinces)
                .WithOne(x => x.City)
                .HasForeignKey(x => x.CitryId);
        }
    }
}
