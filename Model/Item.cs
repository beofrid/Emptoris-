using SQLite;

namespace Emptoris.Model
{
    [Table("Item")]
    public class Item
    {
        [PrimaryKey]
        [AutoIncrement]
        [Column("id")]
        public int Id { get; set; }

        [Column("item")]
        [NotNull]
        public string? ItemName { get; set; }

        [Column("category")]
        public string? Category { get; set; }


        //[Column("unit")]
        //public string? StandardUnit { get; set; }


        //[Column("isUnitChangeable")]
        //public bool? IsUnitChangeable { get; set; }




    }
}
