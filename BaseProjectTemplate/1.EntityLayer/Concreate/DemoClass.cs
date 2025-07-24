using BaseProjectTemplate._1.EntityLayer.Concreate.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BaseProjectTemplate._1.EntityLayer.Concreate
{
    public class DemoClass : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
