using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RolesDemo.Models
{
    public class ChatPrivateMessageMaster
    {
        public ChatPrivateMessageMaster()
        {

        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]

        public int ID { get; set; }

        [Column(TypeName = "nvarchar")]
        public string UserName { get; set; }

        [Column(TypeName = "nvarchar")]
        public string EmailID { get; set; }
    }
}