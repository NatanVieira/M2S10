using System.ComponentModel.DataAnnotations;

namespace M2S10.Models {
    public class Musica {

        public int Id { get; internal set; }
        public string Nome { get; set; }
        public double Duracao { get; set; }
        public Artista Compositor { get; set; }
        public Album Disco { get; set; }

        public Musica() { }
    }
}
