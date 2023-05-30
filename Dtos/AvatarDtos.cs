namespace dotNetStudy.Dtos
{
    public class AvatarDtos
    {
        public class AvatarCreateDto
        {
            public int ChestIndexMale { get; set; }
            public int FacesIndexMale { get; set; }
            public int HairIndexMale { get; set; }
            public int LegsIndexMale { get; set; }
            public int EyebrowIndexMale { get; set; }
            public int HandsIndexMale { get; set; }
            public int BeardIndexMale { get; set; }
            public bool IsMale { get; set; }
        }

        public class AvatarResponseDto
        {
            public long Id { get; set; }
            public int ChestIndexMale { get; set; }
            public int FacesIndexMale { get; set; }
            public int HairIndexMale { get; set; }
            public int LegsIndexMale { get; set; }
            public int EyebrowIndexMale { get; set; }
            public int HandsIndexMale { get; set; }
            public int BeardIndexMale { get; set; }
            public bool IsMale { get; set; }
        }
    }
}
