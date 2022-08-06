using M2S10.Models;
using M2S10.Repositories;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace M2S10.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class ArtistaController : ControllerBase {

        private ArtistaRepository _artistaRepository;

        public ArtistaController(ArtistaRepository artistaRepository) {
            _artistaRepository = artistaRepository;
        }

        [HttpGet]
        public List<Artista> Get() {
            return _artistaRepository.RetornaTodosOsArtistas();
        }

        [HttpGet("{nome}")]
        public List<Artista> Get(string nome) {
            return _artistaRepository.ObterListaPorNome(nome);
        }

        [HttpPost]
        public Artista Post([FromBody] Artista artista) {
            Artista novoArtista = _artistaRepository.IncluiArtista(artista);
            return novoArtista;
        }

        [HttpPut("{id}")]
        public Artista Put(int id,[FromBody] Artista body) {
            Artista artistaAlterado = _artistaRepository.AlteraArtista(id, body);
            return artistaAlterado;
        }

        [HttpDelete("{id}")]
        public void Delete(int id) {
            _artistaRepository.EliminaArtista(id);
        }
    }
}
