using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;

namespace DesignPatternsPlayground.Models
{
    [Table("Users")]
    public class User
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [Column("username")]
        public string Username { get; set; } = "";
        [Column("email")]
        public string Email { get; set; } = "";
        [Column("locationString")]
        public string Location { get; set; } = "";
        [Column("loginTime")]
        public DateTime LoginTime { get; set; }
    }
}
