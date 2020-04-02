using SQLite;

namespace MySpectrum.Models.Users
{
    [Table("User")]
    public class User
    {
        [PrimaryKey, AutoIncrement]
        public long Id { set; get; }
        public string UserName { set; get; }
        [MaxLength(17)]
        public string Password { set; get; }
        public string FullName { set; get; }
    }
}