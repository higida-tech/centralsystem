using SQLite;

namespace CentralSystem.Models
{
    public class BaseModel: ICloneable
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;

        public object Clone()
        {
            return MemberwiseClone();
        }
    }
}
