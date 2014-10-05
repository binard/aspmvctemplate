using Fr.Binard.Net.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fr.Binard.Net.Infrastructure.EF
{
    public class TestMapping : EntityTypeConfiguration<Test>
    {
        public TestMapping()
        {
            this.HasKey(t => t.ID);
            LabelProperty();
            DescriptionProperty();
        }

        private void LabelProperty()
        {
            Property(p => p.Label)
                .IsRequired()
                .HasMaxLength(50);
        }

        private void DescriptionProperty()
        {
            Property(p => p.Description)
                .HasMaxLength(255);
        }
    }
}
