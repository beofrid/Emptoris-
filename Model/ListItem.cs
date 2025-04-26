using SQLite;
using System.Diagnostics.CodeAnalysis;



namespace Emptoris.Model
{

    [Table("ListItem")]
    public class ListItem
    {
        [PrimaryKey]
        [AutoIncrement]
        [Column("id")]
        public int Id { get; set; }

        [Column("itemId")]
        [Indexed]
        public int FK_ItemID { get; set; }

        [Column("listId")]
        [Indexed]
        public int FK_ListId { get; set; }

        [Column("quantity")]
        public int? Quantity { get; set; }

        [Column("isPurchased")]
        public bool IsPurchased { get; set; }

    }


}
