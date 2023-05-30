using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace dotNetStudy.Models
{
    [Table("캐릭터")]
    public class Avatar
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("Id")]
        public long Id { get; set; }
        [Column("가슴 파트")]
        public int ChestIndexMale { get; set; }
        [Column("얼굴 파트")]
        public int FacesIndexMale { get; set; }
        [Column("머리 파트")]
        public int HairIndexMale { get; set; }
        [Column("다리 파트")]
        public int LegsIndexMale { get; set; }
        [Column("눈 파트")]
        public int EyebrowIndexMale { get; set; }
        [Column("손 파트")]
        public int HandsIndexMale { get; set; }
        [Column("수염 파트")]
        public int BeardIndexMale { get; set; }
        [Column("성별")]
        public bool IsMale { get; set; }
        [Column("캐릭터 소유 유저")]
        public int UserId { get; set; } // 유저 정보
    }
}
