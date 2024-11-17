using Microsoft.EntityFrameworkCore.Update.Internal;

namespace appMusic.Entities
{
    public class Music
    {

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Genre { get; set; }
        public Guid ArtistId { get; set; }

        public void Update(string name, string genre)
        {
            Name = name;
            Genre = genre;
        }
    }
}
