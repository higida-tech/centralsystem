using System.Text.RegularExpressions;

namespace CentralSystem.Models
{
    public class User : BaseModel
    {
        public string Name { get; set; }
        public string Email { get; set; }
        private string phone;
        public string Phone {
            get => phone;
            set {
                Regex rx1 = new Regex(@"(?!\d).");
                phone = rx1.Replace(value, string.Empty);
            }
        }
        //todo : add role logic
    }
}
