using cleanarchitecture.Domain.Host.ValueObjects;
using cleanarchitecture.Domain.MenuAggregate;
using cleanarchitecture.Domain.MenuAggregate.Entities;
using cleanarchitecture.Domain.MenuAggregate.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace cleanarchitecture.Infrastructure.Persistence.Configurations;


public class MenuConfigurations : IEntityTypeConfiguration<MenU>
{
    public void Configure(EntityTypeBuilder<MenU> builder)
    {
        ConfigureMenusTable(builder);
        ConfigureMenuSectionTable(builder);
        ConfigureMenuDinnerIdsTable(builder);
        ConfigureMenuReviewIdsTable(builder);
    }
    private void ConfigureMenuDinnerIdsTable(EntityTypeBuilder<Menu> builder)
    {
        builder.OwnsMany(m  =>m.DinnerIds, dib =>
        {
            dib.ToTable("MenuDinnerIds");
            dib.WithOwner().HasForeignKey("MenuId");
            dib.HasKey("Id");
            dib.Property(d => d.Value)
                .HasColumnName("DinnerId")
                .ValueGeneratedNever();
        });

        builder.Metadata.FindNavigation(nameof(Menu.DinnerIds))!
        .SetPropertyAccessMode(PropertyAccessMode.Field);
    }

        private void ConfigureMenuReviewIdsTable(EntityTypeBuilder<Menu> builder)
    {
        builder.OwnsMany(m  =>m.MenuReviewIds, dib =>
        {
            dib.ToTable("MenuReviewIds");
            dib.WithOwner().HasForeignKey("MenuId");
            dib.HasKey("Id");
            dib.Property(d => d.Value)
                .HasColumnName("ReviewId")
                .ValueGeneratedNever();
        });

        builder.Metadata.FindNavigation(nameof(Menu.MenuReviewIds))!
        .SetPropertyAccessMode(PropertyAccessMode.Field);
    }

    private void ConfigureMenusTable(EntityTypeBuilder<MenU> builder)
    {
        builder.ToTable("Menus");
        builder.HasKey(m => m.Id);
        builder.Property(m => m.Id)
        .ValueGeneratedNever()
        .HasConversion(
            id => id.Value,
            value => MenuId.Create(value));
        
        builder.Property(m => m.Name)
        .HasMaxLength(100);

        builder.Property(m => m.Description)
        .HasMaxLength(100);

        builder.OwnsOne(m => m.AverageRating);

        builder.Property(m => m.HostId)
        .HasConversion(
            id => id.Value,
            value => HostId.Create(value));


    }

    private void ConfigureMenuSectionTable(EntityTypeBuilder<MenU> builder)
    {
        builder.OwnsMany(m => m.sections,
        Sb => {
            Sb.ToTable("MenuSections ");
            Sb.WithOwner().HasForeignKey("MenuId");
            Sb.HasKey("Id","MenuId");
            Sb.Property(s => s.Id)
            .HasColumnName("MenuSectionId")
            .ValueGeneratedNever()
            .HasConversion(
                id => id.Value,
                value => MenuSectionId.Create(value));
        
        
        Sb.Property(s => s.Name)
            .HasMaxLength(100);
              Sb.Property(s => s.Description)
            .HasMaxLength(100);

        Sb.OwnsMany(s => s.Items,ib =>
        {
             ib.ToTable("MenuItems");
             ib.WithOwner().HasForeignKey("MenuSectionId","MenuId");
                ib.HasKey(nameof(MenuItem.Id)"MenuSectionId","MenuId")
            ib.Property(i => i.Id)
            .HasColumnName("MenuItemId")
            .ValueGeneratedNever()
            .HasConversion(
                id => id.Value,
                value => MenuItemId.Create(value)
            );
         ib.Property(s => s.Name)
            .HasMaxLength(100);
              ib.Property(s => s.Description)
            .HasMaxLength(100);
        });
        sb.Navigation(s => s.Items).Metadata.SetField("_items");
        sb.Navigation(s => s.Items).UsePropertyAccessMode(PropertyAccessMode.Field);
        });
        builder.Metadata.FindNavigation(nameof(Menu.Sections))!
        .SetPropertyAccessMode(PropertyAccessMode.Field);
    }
}