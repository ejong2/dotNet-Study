using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace dotNetStudy.TestClass
{
    [Table("테스트 테이블")]
    public class TestUser
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Column("테스트 네임")]
        public string Name { get; set; }
        [Column("테스트 이메일")]
        public string Email { get; set; }
    }
}

