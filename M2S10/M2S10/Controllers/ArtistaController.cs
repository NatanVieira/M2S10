using M2S10.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace M2S10.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class ArtistaController : ControllerBase {

        private static int _idArtista = 1;
        private static List<Artista> _artistas = new ();
        // GET: api/<ArtistaController>
        [HttpGet]
        public List<Artista> Get() {
            return _artistas;
        }

        // GET api/<ArtistaController>/Elvis
        [HttpGet("{nome}")]
        public List<Artista> Get(string nome) {
            List<Artista> artistas = _artistas.FindAll(x => x.Nome == nome);
            return artistas;
        }

        // POST api/<ArtistaController>
        [HttpPost]
        public Artista Post([FromBody] Artista artista) {
            artista.Id = _idArtista;
            _idArtista++;
            _artistas.Add(artista);
            return artista;
        }

        // PUT api/<ArtistaController>/5
        [HttpPut("{id}")]
        public Artista Put(int id,[FromBody] Artista body) {
            var artista = _artistas.FirstOrDefault(x => x.Id == id);

            artista.Nome = body.Nome;
            artista.AnosDeCarreira = body.AnosDeCarreira;

            return artista;
        }

        // DELETE api/<ArtistaController>/5
        [HttpDelete("{id}")]
        public void Delete(int id) {
            var artista = _artistas.FirstOrDefault(x => x.Id == id);
            _artistas.Remove(artista);
        }
    }
}
