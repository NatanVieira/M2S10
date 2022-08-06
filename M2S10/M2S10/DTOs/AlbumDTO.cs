using System.ComponentModel.DataAnnotations;

namespace M2S10.DTOs {
    public class AlbumDTO {

        [Required]
        public string Nome { get; set; }

        [Required]
        public int IdArtista { get; set; }

        [Required]
        public List<int> IdsMusicas { get; set; }
    }
}
