using M2S10.DTOs;
using M2S10.Models;
using M2S10.Repositories;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace M2S10.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class AlbumController : ControllerBase {

        private readonly MusicaRepository _musicaRepository;
        private readonly AlbumRepository _albumRepository;
        private readonly ArtistaRepository _artistRepository;

        public AlbumController(AlbumRepository albumRepository,MusicaRepository musicaRepository,ArtistaRepository artistaRepository) {
            _musicaRepository = musicaRepository;
            _albumRepository = albumRepository;
            _artistRepository = artistaRepository;
        }

        [HttpGet]
        public List<Album> Get() {
            return _albumRepository.RetornaTodosOsAlbums();
        }

        [HttpGet("{nome}")]
        public List<Album> Get(string nome) {
            return _albumRepository.ObterListaPorNome(nome);
        }

        [HttpPost]
        public Album Post([FromBody] AlbumDTO albumDTO) {
            Artista artista = _artistRepository.ObterArtistaPorId(albumDTO.IdArtista);
            if(artista != null && albumDTO.IdsMusicas.Count > 0) {
                List<Musica> musicas = retornaListaDeMusicas(albumDTO.IdsMusicas);
                if(musicas.Count > 0) {
                    Album novoAlbum = new();
                    novoAlbum.Nome = albumDTO.Nome;
                    novoAlbum.Compositor = artista;
                    novoAlbum.Musicas = musicas;
                    _albumRepository.IncluiAlbum(novoAlbum);
                    return null;
                }
            }
            return null;
        }

        [HttpPut("{id}")]
        public Album Put(int id,[FromBody] AlbumDTO albumDTO) {
            if(albumDTO.IdsMusicas.Count > 0) {
                List<Musica> musicas = retornaListaDeMusicas(albumDTO.IdsMusicas);
                if(musicas.Count > 0) {
                    Album album = new Album();
                    album.Nome = albumDTO.Nome;
                    album.Musicas = musicas;
                    return _albumRepository.AlteraAlbum(id, album);
                }
            }
            return null;
        }

        [HttpDelete("{id}")]
        public void Delete(int id) {
            _albumRepository.EliminaAlbum(id);
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