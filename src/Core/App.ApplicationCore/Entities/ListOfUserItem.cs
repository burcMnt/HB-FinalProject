using Application.ApplicationCore.Common;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Application.ApplicationCore.Entities
{
    public class ListOfUserItem :BaseEntity
    {
        public Guid ItemId { get; set; }

        [ForeignKey("ItemId")]

        public virtual Item Item { get; set; }

        public Guid ListOfUserId { get; set; }

        [ForeignKey("ListOfUserId")]
        public virtual ListOfUser ListOfUser { get; set; }
        public int ItemQuantity { get; set; }
    }
}
