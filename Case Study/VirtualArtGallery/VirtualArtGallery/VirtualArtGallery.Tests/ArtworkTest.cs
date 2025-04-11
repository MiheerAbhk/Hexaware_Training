//using NUnit.Framework;
//using VirtualArtGallery.dao;
//using VirtualArtGallery.entity;
//using System;
//using System.Collections.Generic;

//namespace VirtualArtGallery.tests
//{
//    [TestFixture]
//    public class ArtworkTests
//    {
//        private IVirtualArtGallery _service;

//        [SetUp]
//        public void Setup()
//        {
//            _service = new VirtualArtGalleryImpl();
//        }

//        [Test]
//        public void AddArtwork_ShouldInsertArtworkWithGalleryIdAndArtistId()
//        {
//            var artwork = new Artwork
//            {
//                Title = "Starry Night",
//                Description = "A famous painting by Van Gogh.",
//                CreationDate = new DateTime(1889, 6, 1),
//                Medium = "Oil on canvas",
//                ImageURL = "https://sampleurl.com",
//                ArtistID = 1,      
//                GalleryID = 1     
//            };

//            bool result = _service.AddArtwork(artwork);
//            Assert.IsTrue(result, "Artwork should be added successfully");
//        }

//        [Test]
//        public void UpdateArtwork_ShouldModifyArtworkDetails()
//        {
//            int artworkID = 2;
//            var artwork = new Artwork
//            {
//                Title = "Starry Night (Edited)",
//                Description = "Updated description",
//                CreationDate = new DateTime(1889, 6, 2),
//                Medium = "Oil on canvas",
//                ImageURL = "https://example.com/updated.jpg",
//                ArtistID = 1,
//                GalleryID = 1
//            };

//            bool result = _service.UpdateArtwork(artworkID, artwork);
//            Assert.IsTrue(result, "Artwork should be updated");
//        }

//        [Test]
//        public void DeleteArtwork_ShouldRemoveArtwork()
//        {
//            int artworkId = 1;
//            bool result = _service.RemoveArtwork(artworkId);
//            Assert.IsTrue(result, "Artwork should be deleted");
//        }

//        [Test]
//        public void SearchArtwork_ShouldReturnMatchingResults()
//        {
//            List<Artwork> results = _service.SearchArtworks("sample");
//            Assert.IsNotNull(results);
//            Assert.IsTrue(results.Count > 0, "Search should return at least one artwork");
//        }
//    }
//}
