using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RolesDemo.Models
{
    public class ChatPrivateMessageDetails
    {
        public ChatPrivateMessageDetails()
        {

        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]

        public int ID { get; set; }

        [Column(TypeName = "nvarchar(MAX)")]
        public string Message { get; set; }

        [Column(TypeName = "nvarchar")]
        public string MasterEmailID { get; set; }

        [Column(TypeName = "nvarchar")]
        public string ChatToEmailID { get; set; }
    }
}