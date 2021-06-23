using HotelManagement.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotelManagement.Data.EntityConfigurations
{
    public class RoomModelConfiguration : IEntityTypeConfiguration<RoomModel>
    {
        public void Configure(EntityTypeBuilder<RoomModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Description).IsRequired();
            builder.Property(x => x.NumberOfBeds).IsRequired();
            builder.Property(x => x.RoomType).IsRequired();
        }
    }
}
