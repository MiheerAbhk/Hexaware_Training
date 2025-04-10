CREATE DATABASE VirtualArtGalleryDB;

USE VirtualArtGalleryDB

CREATE TABLE Artist (
    ArtistID INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(100) NOT NULL,
    Biography NVARCHAR(1000),
    Birthdate DATE,
    Nationality NVARCHAR(50),
    Website NVARCHAR(200),
    ContactInformation NVARCHAR(200)
);

CREATE TABLE Artwork (
    ArtworkID INT IDENTITY(1,1) PRIMARY KEY,
    Title NVARCHAR(200),
    Description NVARCHAR(1000),
    CreationDate DATE,
    Medium NVARCHAR(100),
    ImageURL NVARCHAR(200),
    ArtistID INT NOT NULL,
    GalleryID INT NOT NULL,
    FOREIGN KEY (ArtistID) REFERENCES Artist(ArtistID),
    FOREIGN KEY (GalleryID) REFERENCES Gallery(GalleryID)
);

CREATE TABLE [User] (
    UserID INT IDENTITY(1,1) PRIMARY KEY,
    Username NVARCHAR(50) NOT NULL,
    Password NVARCHAR(100) NOT NULL,
    Email NVARCHAR(100) UNIQUE NOT NULL,
    FirstName NVARCHAR(100),
    LastName NVARCHAR(100),
    DateOfBirth DATE,
    ProfilePicture NVARCHAR(300)
)

CREATE TABLE Gallery (
    GalleryID INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(100) NOT NULL,
    Description NVARCHAR(1000),
    Location NVARCHAR(200),
    Curator INT NOT NULL, 
    OpeningHours NVARCHAR(50),
    FOREIGN KEY (Curator) REFERENCES Artist(ArtistID)
);

CREATE TABLE User_Favorite_Artwork (
    UserID INT NOT NULL, 
    ArtworkID INT NOT NULL,
    PRIMARY KEY (UserID, ArtworkID),
    FOREIGN KEY (UserID) REFERENCES [User](UserID), 
    FOREIGN KEY (ArtworkID) REFERENCES Artwork(ArtworkID)
);

CREATE TABLE Artwork_Gallery (
    ArtworkID INT NOT NULL,
    GalleryID INT NOT NULL,
    PRIMARY KEY (ArtworkID, GalleryID),
    FOREIGN KEY (ArtworkID) REFERENCES Artwork(ArtworkID),
    FOREIGN KEY (GalleryID) REFERENCES Gallery(GalleryID)
)

INSERT INTO Artist (Name, Biography, BirthDate, Nationality, Website, ContactInformation) VALUES
('Sahil Gaikwad','14 year old passionate artist', '2011-05-05', 'Indian','sahilarts.com', 'sahil@example.com'),
('James Wright' , 'Famous Australian artist', '1982-04-11', 'Australian', 'wrightpaints.com', 'james@example.com'),
('Sandeep Patel' , 'Known for sand art', '1998-01-19', 'Indian', 'artistsandeep.net','sandeep@example.com'),
('Tyler Tones', 'Great canvas paint artist', '1992-10-10', 'American', 'tyleretones.org', 'tyler@example.com')

SELECT * FROM Artist
SELECT * FROM Artwork
SELECT * FROM[User]
SELECT * FROM Gallery
SELECT * FROM User_Favorite_Artwork


INSERT INTO [User] (Username, Password, Email, FirstName, LastName, DateOfBirth, ProfilePicture) 
VALUES
('satish','satish123','satish@example.com','satish','sharma','2000-01-01', 'PP1.png'),
('Artist12', 'StrongPassword', 'mukesh@example.com', 'mukesh', 'deo', '1997-05-01', 'profile.png'),
('Rahul102', 'Login@12345', 'rahul@example.com', 'rahul', 'venkat', '2001-03-19', 'photo.png')

INSERT INTO Gallery (Name, Description, Location, Curator, OpeningHours)
VALUES 
('Modern Art Gallery', 'A gallery showcasing contemporary art.', 'New York', 1, '10 AM - 8 PM'),
('Classic Art Gallery', 'A gallery dedicated to classical paintings.', 'Paris', 2, '9 AM - 6 PM'),
('Sculpture Gallery', 'A gallery for sculptures from various artists.', 'London', 3, '11 AM - 7 PM'),
('Abstract Art Gallery', 'A gallery with abstract art collections.', 'Berlin', 4, '10 AM - 6 PM')


INSERT INTO Artwork (Title, Description, CreationDate, Medium, ImageURL, ArtistID, GalleryID)
VALUES ('Sample Artwork', 'Description of artwork', '2025-01-01', 'Medium', 'imageurl.com', 4, 4);




SELECT 
    fk.name AS FK_constraint_name,
    tp.name AS parent_table,
    ref.name AS referenced_table
FROM 
    sys.foreign_keys AS fk
    INNER JOIN sys.tables AS tp ON fk.parent_object_id = tp.object_id
    INNER JOIN sys.tables AS ref ON fk.referenced_object_id = ref.object_id
WHERE 
    tp.name = 'Artist';  -- Replace 'Gallery' with your table name


ALTER TABLE Gallery  -- Replace 'Gallery' with your table name
DROP CONSTRAINT FK__Gallery__Curator__398D8EEE;  -- Replace 'FK_constraint_name' with the actual foreign key constraint name
