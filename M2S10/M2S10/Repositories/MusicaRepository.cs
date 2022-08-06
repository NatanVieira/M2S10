using M2S10.DTOs;
using M2S10.Models;

namespace M2S10.Repositories {
    public class MusicaRepository {

        private static int _IdMusica;
        private static List<Musica> _musicas = new();

        public Musica ObtermusicaPorId(int id) {
            Musica musica = _musicas.FirstOrDefault(musica => musica.Id == id);
            return musica;
        }

        public List<Musica> RetornaTodasAsMusicas() {
            return _musicas;
        }

        public List<Musica> ObterListaPorNome(string nome) {
            List<Musica> musicas = _musicas.FindAll(musica => musica.Nome == nome);
            return musicas;
        }

        public Musica IncluiMusica(Musica musica) {
            Musica novaMusica = new Musica();
            novaMusica.Nome = musica.Nome;
            novaMusica.Duracao = musica.Duracao;
            novaMusica.Compositor = musica.Compositor;
            novaMusica.Disco = musica.Disco;
            novaMusica.Id = _IdMusica;
            _IdMusica++;
            _musicas.Add(novaMusica);
            return novaMusica;
        }

        public Musica AlteraMusica(int id,MusicaDTO musica) {
            Musica? musicaAlterada = _musicas.FirstOrDefault(musica => musica.Id == id);
            if(musicaAlterada != null) {
                musicaAlterada.Nome = musica.Nome;
                musicaAlterada.Duracao = musica.Duracao;
            }
            return musicaAlterada;
        }

        public void EliminaMusica(int id) {
            Musica musica = _musicas.FirstOrDefault(musica => musica.Id == id);
            _musicas.Remove(musica);
        }
    }
}
