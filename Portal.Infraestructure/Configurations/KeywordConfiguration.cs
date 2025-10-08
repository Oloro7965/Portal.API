using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Portal.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Infraestructure.Configurations
{
    public class KeywordConfiguration : IEntityTypeConfiguration<Keywords>
    {
        public void Configure(EntityTypeBuilder<Keywords> builder)
        {
            builder.HasKey(x => x.Id);
        }
    }
}
