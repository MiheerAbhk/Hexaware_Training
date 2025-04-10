using System;
using System.Collections.Generic;
using VirtualArtGallery.dao;
using VirtualArtGallery.entity;
using VirtualArtGallery.util;

namespace VirtualArtGallery.main
{
    class Program
    {
        static void Main(string[] args)
        {
            IVirtualArtGallery galleryService = new VirtualArtGalleryImpl();

            while (true)
            {
                Console.WriteLine("\n===== Virtual Art Gallery Menu =====");
                Console.WriteLine("1. Add Artwork");
                Console.WriteLine("2. Update Artwork");
                Console.WriteLine("3. Remove Artwork");
                Console.WriteLine("4. Get Artwork by ID");
                Console.WriteLine("5. Search Artworks");
                Console.WriteLine("6. Add to Favorites");
                Console.WriteLine("7. Remove from Favorites");
                Console.WriteLine("8. View Favorite Artworks");
                Console.WriteLine("9. Exit");
                Console.Write("Enter your choice: ");
                int choice = Convert.ToInt32(Console.ReadLine());

                try
                {
                    switch (choice)
                    {
                        case 1:
                            AddArtwork(galleryService);
                            break;

                        case 2:
                            UpdateArtwork(galleryService);
                            break;

                        case 3:
                            RemoveArtwork(galleryService);
                            break;

                        case 4:
                            GetArtworkById(galleryService);
                            break;

                        case 5:
                            SearchArtworks(galleryService);
                            break;

                        case 6:
                            AddToFavorites(galleryService);
                            break;

                        case 7:
                            RemoveFromFavorites(galleryService);
                            break;

                        case 8:
                            ViewFavoriteArtworks(galleryService);
                            break;

                        case 9:
                            Console.WriteLine("Exiting...");
                            DBConnUtil.CloseConnection();
                            return;

                        default:
                            Console.WriteLine("Invalid choice. Please try again.");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("An error occurred: " + ex.Message);
                }
            }
        }

        static void AddArtwork(IVirtualArtGallery service)
        {
            Artwork art = new Artwork();
            Console.Write("Title: ");
            art.Title = Console.ReadLine();
            Console.Write("Description: ");
            art.Description = Console.ReadLine();
            Console.Write("Creation Date (yyyy-mm-dd): ");
            art.CreationDate = DateTime.Parse(Console.ReadLine());
            Console.Write("Medium: ");
            art.Medium = Console.ReadLine();
            Console.Write("Image URL: ");
            art.ImageURL = Console.ReadLine();
            Console.Write("Artist ID: ");
            art.ArtistID = Convert.ToInt32(Console.ReadLine());
            Console.Write("Gallery ID: ");
            art.GalleryID = int.Parse(Console.ReadLine());

            if (service.AddArtwork(art))
                Console.WriteLine("Artwork added successfully.");
            else
                Console.WriteLine("Failed to add artwork.");
        }

        static void UpdateArtwork(IVirtualArtGallery service)
        {
            Console.Write("Enter Artwork ID to update: ");
            int artworkId = Convert.ToInt32(Console.ReadLine());

            Artwork art = new Artwork();
            Console.Write("New Title: ");
            art.Title = Console.ReadLine();
            Console.Write("New Description: ");
            art.Description = Console.ReadLine();
            Console.Write("New Creation Date (yyyy-mm-dd): ");
            art.CreationDate = DateTime.Parse(Console.ReadLine());
            Console.Write("New Medium: ");
            art.Medium = Console.ReadLine();
            Console.Write("New Image URL: ");
            art.ImageURL = Console.ReadLine();
            Console.Write("New Artist ID: ");
            art.ArtistID = Convert.ToInt32(Console.ReadLine());

            if (service.UpdateArtwork(artworkId, art))
                Console.WriteLine("Artwork updated successfully.");
            else
                Console.WriteLine("Failed to update artwork.");
        }

        static void RemoveArtwork(IVirtualArtGallery service)
        {
            Console.Write("Enter Artwork ID to remove: ");
            int id = Convert.ToInt32(Console.ReadLine());

            if (service.RemoveArtwork(id))
                Console.WriteLine("Artwork removed successfully.");
            else
                Console.WriteLine("Failed to remove artwork.");
        }

        static void GetArtworkById(IVirtualArtGallery service)
        {
            Console.Write("Enter Artwork ID: ");
            int id = Convert.ToInt32(Console.ReadLine());

            var artwork = service.GetArtworkById(id);
            if (artwork != null)
            {
                Console.WriteLine($"Title: {artwork.Title}\nDescription: {artwork.Description}\nDate: {artwork.CreationDate:d}\nMedium: {artwork.Medium}\nImage URL: {artwork.ImageURL}\nArtist ID: {artwork.ArtistID}");
            }
        }

        static void SearchArtworks(IVirtualArtGallery service)
        {
            Console.Write("Enter keyword to search: ");
            string keyword = Console.ReadLine();

            var results = service.SearchArtworks(keyword);
            if (results.Count == 0)
            {
                Console.WriteLine("No artworks found.");
            }
            else
            {
                Console.WriteLine("\nSearch Results:");
                foreach (var art in results)
                {
                    Console.WriteLine($"Title: {art.Title}, Medium: {art.Medium}, Artist ID: {art.ArtistID}");
                }
            }
        }

        static void AddToFavorites(IVirtualArtGallery service)
        {
            Console.Write("Enter User ID: ");
            int userId = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Artwork ID: ");
            int artworkId = Convert.ToInt32(Console.ReadLine());

            if (service.AddArtworkToFavorite(userId, artworkId))
                Console.WriteLine("Artwork added to favorites.");
            else
                Console.WriteLine("Failed to add to favorites.");
        }

        static void RemoveFromFavorites(IVirtualArtGallery service)
        {
            Console.Write("Enter User ID: ");
            int userId = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Artwork ID: ");
            int artworkId = Convert.ToInt32(Console.ReadLine());

            if (service.RemoveArtworkFromFavorite(userId, artworkId))
                Console.WriteLine("Artwork removed from favorites.");
            else
                Console.WriteLine("Failed to remove from favorites.");
        }

        static void ViewFavoriteArtworks(IVirtualArtGallery service)
        {
            Console.Write("Enter User ID: ");
            int userId = Convert.ToInt32(Console.ReadLine());

            var favorites = service.GetUserFavoriteArtworks(userId);
            if (favorites.Count == 0)
            {
                Console.WriteLine("No favorite artworks found.");
            }
            else
            {
                Console.WriteLine("\nFavorite Artworks:");
                foreach (var art in favorites)
                {
                    Console.WriteLine($"Title: {art.Title}, Medium: {art.Medium}, Artist ID: {art.ArtistID}");
                }
            }
        }
    }
}
