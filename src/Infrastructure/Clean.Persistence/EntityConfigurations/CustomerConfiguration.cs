﻿using Clean.Domain.Customers;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Clean.Persistence.EntityConfigurations;

public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.HasKey(x => x.Id);
        builder.OwnsMany(x => x.Addresses);
    }
}
