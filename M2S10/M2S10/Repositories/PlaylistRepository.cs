using M2S10.DTOs;
using M2S10.Models;

namespace M2S10.Repositories {
    public class PlaylistRepository {

        private static int _IdPlaylist;
        private static List<Playlist> _playlists = new();

        public Playlist ObterPlaylistPorId(int id) {
            Playlist playlist = _playlists.FirstOrDefault(playlist => playlist.Id == id);
            return playlist;
        }

        public List<Playlist> RetornaTodasAsPlaylists() {
            return _playlists;
        }

        public List<Playlist> ObterListaPorNome(string nome) {
            List<Playlist> playlists = _playlists.FindAll(playlist => playlist.Nome == nome);
            return playlists;
        }

        public Playlist IncluiPlaylist(Playlist playlist) {
            Playlist novoPlaylist = new Playlist();
            novoPlaylist.Nome = playlist.Nome;
            novoPlaylist.Id = _IdPlaylist;
            _IdPlaylist++;
            _playlists.Add(novoPlaylist);
            return novoPlaylist;
        }

        public Playlist AlteraPlaylist(int id,Playlist playlist) {
            Playlist? playlistAlterado = _playlists.FirstOrDefault(playlist => playlist.Id == id);
            if(playlistAlterado != null) {
                playlistAlterado.Nome = playlist.Nome;
                playlistAlterado.Musicas = playlist.Musicas;
            }
            return playlistAlterado;
        }

        public void EliminaPlaylist(int id) {
            Playlist playlist = _playlists.FirstOrDefault(playlist => playlist.Id == id);
            _playlists.Remove(playlist);
        }
    }
}
