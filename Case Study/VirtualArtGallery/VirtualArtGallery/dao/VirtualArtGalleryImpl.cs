using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using VirtualArtGallery.entity;
using VirtualArtGallery.util;
using VirtualArtGallery.exceptions;

namespace VirtualArtGallery.dao
{
    public class VirtualArtGalleryImpl : IVirtualArtGallery
    {
        private static SqlConnection connection;

        public VirtualArtGalleryImpl()
        {
            connection = DBConnUtil.GetConnection("db.config");
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
        }

        // Artwork
        public bool AddArtwork(Artwork artwork)
        {
            try
            {
                string query = "INSERT INTO Artwork (Title, Description, CreationDate, Medium, ImageURL, ArtistID, GalleryID)" +
                    " VALUES (@Title, @Description, @CreationDate, @Medium, @ImageURL, @ArtistID, @GalleryID)";
                using SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@Title", artwork.Title);
                cmd.Parameters.AddWithValue("@Description", artwork.Description);
                cmd.Parameters.AddWithValue("@CreationDate", artwork.CreationDate);
                cmd.Parameters.AddWithValue("@Medium", artwork.Medium);
                cmd.Parameters.AddWithValue("@ImageURL", artwork.ImageURL);
                cmd.Parameters.AddWithValue("@ArtistID", artwork.ArtistID);
                cmd.Parameters.AddWithValue("@GalleryID", artwork.GalleryID);

                return cmd.ExecuteNonQuery() > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error while adding artwork: " + ex.Message);
                return false;
            }
        }

        public bool UpdateArtwork(int artworkID, Artwork artwork)
        {
            try
            {
                string query = "UPDATE Artwork SET Title = @Title, Description = @Description, CreationDate = @CreationDate, Medium = @Medium, ImageURL = @ImageURL, ArtistID = @ArtistID WHERE ArtworkID = @ArtworkID";
                using SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@Title", artwork.Title);
                cmd.Parameters.AddWithValue("@Description", artwork.Description);
                cmd.Parameters.AddWithValue("@CreationDate", artwork.CreationDate);
                cmd.Parameters.AddWithValue("@Medium", artwork.Medium);
                cmd.Parameters.AddWithValue("@ImageURL", artwork.ImageURL);
                cmd.Parameters.AddWithValue("@ArtistID", artwork.ArtistID);
                cmd.Parameters.AddWithValue("@ArtworkID", artworkID);

                return cmd.ExecuteNonQuery() > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error while updating artwork: " + ex.Message);
                return false;
            }
        }

        public bool RemoveArtwork(int artworkID)
        {
            try
            {
                string query = "DELETE FROM Artwork WHERE ArtworkID = @ArtworkID";
                using SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@ArtworkID", artworkID);

                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected == 0)
                {
                    throw new ArtWorkNotFoundException("Artwork with given ID not found.");
                }

                return true;
            }
            catch (ArtWorkNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error while removing artwork: " + ex.Message);
                return false;
            }
        }

        public Artwork GetArtworkById(int artworkID)
        {
            try
            {
                string query = "SELECT * FROM Artwork WHERE ArtworkID = @ArtworkID";
                using SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@ArtworkID", artworkID);
                using SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    return new Artwork
                    {
                        //ArtworkID = Convert.ToInt32(reader["ArtworkID"]),
                        Title = reader["Title"].ToString(),
                        Description = reader["Description"].ToString(),
                        CreationDate = Convert.ToDateTime(reader["CreationDate"]),
                        Medium = reader["Medium"].ToString(),
                        ImageURL = reader["ImageURL"].ToString(),
                        ArtistID = Convert.ToInt32(reader["ArtistID"])
                    };
                }
                else
                {
                    throw new ArtWorkNotFoundException("Artwork with given ID not found.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error while retrieving artwork: " + ex.Message);
                return null;
            }
        }

        public List<Artwork> SearchArtworks(string keyword)
        {
            List<Artwork> artworks = new();
            try
            {
                string query = "SELECT * FROM Artwork WHERE Title LIKE @Keyword OR Description LIKE @Keyword";
                using SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@Keyword", "%" + keyword + "%");
                using SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    artworks.Add(new Artwork
                    {
                        //ArtworkID = Convert.ToInt32(reader["ArtworkID"]),
                        Title = reader["Title"].ToString(),
                        Description = reader["Description"].ToString(),
                        CreationDate = Convert.ToDateTime(reader["CreationDate"]),
                        Medium = reader["Medium"].ToString(),
                        ImageURL = reader["ImageURL"].ToString(),
                        ArtistID = Convert.ToInt32(reader["ArtistID"])
                    });
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error while searching artworks: " + ex.Message);
            }
            return artworks;
        }

        // User Favorites
        public bool AddArtworkToFavorite(int userId, int artworkId)
        {
            try
            {
                string query = "INSERT INTO User_Favorite_Artwork (UserID, ArtworkID) VALUES (@UserID, @ArtworkID)";
                using SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@UserID", userId);
                cmd.Parameters.AddWithValue("@ArtworkID", artworkId);

                return cmd.ExecuteNonQuery() > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error while adding to favorites: " + ex.Message);
                return false;
            }
        }

        public bool RemoveArtworkFromFavorite(int userId, int artworkId)
        {
            try
            {
                string query = "DELETE FROM User_Favorite_Artwork WHERE UserID = @UserID AND ArtworkID = @ArtworkID";
                using SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@UserID", userId);
                cmd.Parameters.AddWithValue("@ArtworkID", artworkId);

                return cmd.ExecuteNonQuery() > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error while removing from favorites: " + ex.Message);
                return false;
            }
        }

        public List<Artwork> GetUserFavoriteArtworks(int userId)
        {
            List<Artwork> favorites = new();
            try
            {
                string query = @"
                    SELECT a.* 
                    FROM Artwork a
                    JOIN User_Favorite_Artwork ufa ON a.ArtworkID = ufa.ArtworkID
                    WHERE ufa.UserID = @UserID";

                using SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@UserID", userId);
                using SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    favorites.Add(new Artwork
                    {
                        //ArtworkID = Convert.ToInt32(reader["ArtworkID"]),
                        Title = reader["Title"].ToString(),
                        Description = reader["Description"].ToString(),
                        CreationDate = Convert.ToDateTime(reader["CreationDate"]),
                        Medium = reader["Medium"].ToString(),
                        ImageURL = reader["ImageURL"].ToString(),
                        ArtistID = Convert.ToInt32(reader["ArtistID"])
                    });
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error while retrieving favorite artworks: " + ex.Message);
            }
            return favorites;
        }
    }
}