using SQLite;

namespace Emptoris.Model
{
    [Table("ShoppingList")]
    public class ShoppingList
    {
        [PrimaryKey]
        [AutoIncrement]
        [Column("id")]
        public int Id { get; set; }

        [Column("listName")]
        [NotNull]
        public string? ListName { get; set; }

        //[Column ("CreationDate")]
        //public DateTime? CreationDate { get; set; }



    }
}
