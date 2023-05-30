using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace dotNetStudy.Models
{
    [Table("유저")]
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("Id")]
        public int Id { get; set; }

        [Column("로그인 아이디")]
        public string loginId { get; set; }

        [Column("패스워드")]
        public string password { get; set; }
    }
}