using M2S10.DTOs;
using M2S10.Models;

namespace M2S10.Repositories {
    public class AlbumRepository {

        private static int _IdAlbum;
        private static List<Album> _albums = new();

        public Album ObterAlbumPorId(int id) {
            Album album = _albums.FirstOrDefault(album => album.Id == id);
            return album;
        }

        public List<Album> RetornaTodosOsAlbums() {
            return _albums;
        }

        public List<Album> ObterListaPorNome(string nome) {
            List<Album> albums = _albums.FindAll(album => album.Nome == nome);
            return albums;
        }

        public Album IncluiAlbum(Album album) {
            Album novoAlbum = new Album();
            novoAlbum.Nome = album.Nome;
            novoAlbum.Compositor = album.Compositor;
            novoAlbum.Id = _IdAlbum;
            _IdAlbum++;
            _albums.Add(novoAlbum);
            return novoAlbum;
        }

        public Album AlteraAlbum(int id,Album album) {
            Album? albumAlterado = _albums.FirstOrDefault(album => album.Id == id);
            if(albumAlterado != null) {
                albumAlterado.Nome = album.Nome;
                albumAlterado.Musicas = album.Musicas;
            }
            return albumAlterado;
        }

        public void EliminaAlbum(int id) {
            Album album = _albums.FirstOrDefault(album => album.Id == id);
            _albums.Remove(album);
        }
    }
}
