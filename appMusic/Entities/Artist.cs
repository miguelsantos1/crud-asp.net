using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace appMusic.Entities
{
    public class Artist
    {
        public Artist()
        {
            Musics = new List<Music>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<Music> Musics { get; set; }

        public void Update(string name)
        {
            Name = name;
        }
    }


}
