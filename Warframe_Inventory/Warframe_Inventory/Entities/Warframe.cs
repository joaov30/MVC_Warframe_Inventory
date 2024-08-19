using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Warframe_Inventory.Entities
{
    public class Warframe
    {
        public int WarframeId { get; set; }

        [Required, MaxLength(100, ErrorMessage = "O nome não pode exceder 100 characters")]
        public string? Name { get; set; }

        [Required, Range(0, 99)]
        public int Blueprints { get; set; }

        [Required, Range(0, 99)]
        public int Neuroptics { get; set; }

        [Required, Range(0, 99)]
        public int Chassis { get; set; }

        [Required, Range(0, 99)]
        public int Systems { get; set; }

    }
}
