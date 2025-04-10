using VirtualArtGallery.entity;

public interface IVirtualArtGallery
{
    // Artwork
    bool AddArtwork(Artwork artwork);
    bool UpdateArtwork(int artworkID, Artwork artwork);
    bool RemoveArtwork(int artworkID);
    Artwork GetArtworkById(int artworkID);
    List<Artwork> SearchArtworks(string keyword);

    // User Favorites
    bool AddArtworkToFavorite(int userId, int artworkId);
    bool RemoveArtworkFromFavorite(int userId, int artworkId);
    List<Artwork> GetUserFavoriteArtworks(int userId);
}
