namespace VirtualArtGallery.entity
{
    public class Artwork
    {

        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreationDate { get; set; }
        public string Medium { get; set; }
        public string ImageURL { get; set; }
        public int ArtistID { get; set; }
        public int GalleryID { get; set; }
        public Artwork() { }

        public Artwork(int artworkID, string title, string description, DateTime creationDate,
                       string medium, string imageURL, int artistID, int galleryID)
        {
            Title = title;
            Description = description;
            CreationDate = creationDate;
            Medium = medium;
            ImageURL = imageURL;
            ArtistID = artistID;
            GalleryID = galleryID;
        }
    }
}
