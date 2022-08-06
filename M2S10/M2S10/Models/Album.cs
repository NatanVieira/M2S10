namespace M2S10.Models {
    public class Album {

        public int Id { get; internal set; }
        public Artista Compositor { get; set; }
        public List<Musica> Musicas { get; set; }

        public string Nome { get; set; }
    }
}
