using M2S10.Models;

namespace M2S10.Repositories {
    public class AlbumRepository {

        private static int _IdAlbum = 1;
        private static List<Album> _albuns = new();

        public Album OberPorId(int id) {
            return _albuns.FirstOrDefault(album => album.Id == id);
        }
    }
}
