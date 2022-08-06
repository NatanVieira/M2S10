using M2S10.DTOs;
using M2S10.Models;
using M2S10.Repositories;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace M2S10.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class PlaylistController : ControllerBase {

        private readonly MusicaRepository _musicaRepository;
        private readonly PlaylistRepository _playlistRepository;

        public PlaylistController(PlaylistRepository playlistRepository,MusicaRepository musicaRepository,ArtistaRepository artistaRepository) {
            _musicaRepository = musicaRepository;
            _playlistRepository = playlistRepository;
        }

        [HttpGet]
        public List<Playlist> Get() {
            return _playlistRepository.RetornaTodasAsPlaylists();
        }

        [HttpGet("{nome}")]
        public List<Playlist> Get(string nome) {
            return _playlistRepository.ObterListaPorNome(nome);
        }

        [HttpPost]
        public Playlist Post([FromBody] PlaylistDTO playlistDTO) {
            if(playlistDTO.IdsMusicas.Count > 0) {
                List<Musica> musicas = retornaListaDeMusicas(playlistDTO.IdsMusicas);
                if(musicas.Count > 0) {
                    Playlist novoPlaylist = new();
                    novoPlaylist.Nome = playlistDTO.Nome;
                    novoPlaylist.Musicas = musicas;
                    _playlistRepository.IncluiPlaylist(novoPlaylist);
                    return null;
                }
            }
            return null;
        }

        [HttpPut("{id}")]
        public Playlist Put(int id,[FromBody] PlaylistDTO playlistDTO) {
            if(playlistDTO.IdsMusicas.Count > 0) {
                List<Musica> musicas = retornaListaDeMusicas(playlistDTO.IdsMusicas);
                if(musicas.Count > 0) {
                    Playlist playlist = new Playlist();
                    playlist.Nome = playlistDTO.Nome;
                    playlist.Musicas = musicas;
                    return _playlistRepository.AlteraPlaylist(id,playlist);
                }
            }
            return null;
        }

        [HttpDelete("{id}")]
        public void Delete(int id) {
            _playlistRepository.EliminaPlaylist(id);
        }

        private List<Musica> retornaListaDeMusicas(List<int> IdMusicas) {
            List<Musica> musicas = new();
            for(int i = 0;i < IdMusicas.Count;i++) {
                Musica musica = _musicaRepository.ObtermusicaPorId(IdMusicas[i]);
                if(musica != null)
                    musicas.Add(musica);
            }
            return musicas;
        }
    }
}