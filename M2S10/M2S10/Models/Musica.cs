﻿namespace M2S10.Models {
    public class Musica {

        public string Nome { get; set; }
        public double Duracao { get; set; }
        public Artista Compositor { get; set; }
        public Album Disco { get; set; }
    }
}