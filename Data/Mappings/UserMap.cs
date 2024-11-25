using Blog.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Blog.Data.Mappings
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("User");
            builder.HasKey(x=> x.Id); //Informar a chave-primaria da tabela Category.
            builder.Property(x=> x.Id)
                .ValueGeneratedOnAdd() //Retorna o Id para o programa.
                .UseIdentityColumn(); //Informa o programa que o banco de dados possui Identity.
            
            builder.Property(x=> x.Name)
                .IsRequired() //NOT null
                .HasColumnName("Name")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(80);

            builder.Property(x=> x.Slug)
                .IsRequired() //NOT null
                .HasColumnName("Slug")
                .HasColumnType("VARCHAR")
                .HasMaxLength(80);

            builder.HasIndex(x=> x.Slug, "IX_Category_Slug")// Cria um Index no bdd
                .IsUnique(); 
        }
    }
}