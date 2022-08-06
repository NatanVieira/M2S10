using M2S10.DTOs;
using M2S10.Models;
using M2S10.Repositories;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace M2S10.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class MusicaController : ControllerBase {

        private readonly MusicaRepository _musicaRepository;
        private readonly AlbumRepository _albumRepository;
        private readonly ArtistaRepository _artistRepository;

        public MusicaController(MusicaRepository musicaRepository, AlbumRepository albumRepository, ArtistaRepository artistaRepository) {
            _musicaRepository = musicaRepository;
            _albumRepository = albumRepository;
            _artistRepository = artistaRepository;
        }

        [HttpGet]
        public List<Musica> Get() {
            return _musicaRepository.RetornaTodasAsMusicas();
        }

        [HttpGet("{nome}")]
        public List<Musica> Get(string nome) {
            return _musicaRepository.ObterListaPorNome(nome);
        }
        
        [HttpGet("/byName")]
        public List<Musica> Get(string nomeMusica, string nomeArtista, string nomeAlbum) {
            List<Musica> musicas = _musicaRepository.RetornaTodasAsMusicas();
            return musicas.Where(musica => musica.Nome == nomeMusica || musica.Compositor.Nome == nomeArtista || musica.Disco.Nome == nomeAlbum).ToList();
        }

        [HttpPost]
        public Musica Post([FromBody] MusicaDTO musicaDTO) {
            Artista artista = _artistRepository.ObterArtistaPorId(musicaDTO.IdArtista);
            if(artista != null) {
                Musica novaMusica = new();
                novaMusica.Nome = musicaDTO.Nome;
                novaMusica.Duracao = musicaDTO.Duracao;
                novaMusica.Compositor = artista;
                if(musicaDTO.IdAlbum != null && musicaDTO.IdAlbum != 0) {
                    Album album = _albumRepository.OberPorId(musicaDTO.IdAlbum);
                    if(album != null)
                        novaMusica.Disco = album;
                }
               _musicaRepository.IncluiMusica(novaMusica);
                return novaMusica;
            }
            return null;
        }

        [HttpPut("{id}")]
        public Musica Put(int id,[FromBody] MusicaDTO musicaDTO) {
            Musica musicaAlterada = _musicaRepository.AlteraMusica(id, musicaDTO);
            return musicaAlterada;
        }

        [HttpDelete("{id}")]
        public void Delete(int id) {
            _musicaRepository.EliminaMusica(id);
        }
    }
}
