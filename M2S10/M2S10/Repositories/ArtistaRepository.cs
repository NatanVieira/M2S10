using M2S10.Models;

namespace M2S10.Repositories {
    public class ArtistaRepository {

        private static int _idArtista = 1;
        private static List<Artista> _artistas = new();

        public Artista ObterArtistaPorId(int id) {
            Artista artista = _artistas.FirstOrDefault(artista => artista.Id == id);
            return artista;
        }

        public List<Artista> RetornaTodosOsArtistas() {
            return _artistas;
        }

        public List<Artista> ObterListaPorNome(string nome) {
            List<Artista> artistas = _artistas.FindAll(artista => artista.Nome == nome);
            return artistas;
        }

        public Artista IncluiArtista(Artista artista) {
            artista.Id = _idArtista;
            _artistas.Add(artista);
            _idArtista++;
            return artista;
        }

        public Artista AlteraArtista(int id, Artista artista) {
            Artista? artistaAlterado = _artistas.FirstOrDefault(artista => artista.Id == id);
            if(artistaAlterado != null) {
                artistaAlterado.Nome = artista.Nome;
                artistaAlterado.AnosDeCarreira = artista.AnosDeCarreira;
            }
            return artistaAlterado;
        }

        public void EliminaArtista(int id) {
            Artista artista = _artistas.FirstOrDefault(artista => artista.Id == id);
            _artistas.Remove(artista);
        }
    }
}
