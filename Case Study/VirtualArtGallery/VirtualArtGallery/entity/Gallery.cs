namespace VirtualArtGallery.entity
{
    public class Gallery
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public int CuratorID { get; set; } // Reference to ArtistID
        public string OpeningHours { get; set; }

        public Gallery() { }

        public Gallery(string name, string description, string location, int curatorID, string openingHours)
        {
            Name = name;
            Description = description;
            Location = location;
            CuratorID = curatorID;
            OpeningHours = openingHours;
        }
    }
}
