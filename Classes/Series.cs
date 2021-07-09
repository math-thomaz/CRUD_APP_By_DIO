using System;

namespace DIO.Series
{
    public class Series : BaseEntity
    {
        private Genre Genre { get; set; }
        private string Title { get; set; }
        private string Description { get; set; }
        private int ReleaseYear { get; set; }

        private bool Removed { get; set; }

        public Series(int id, Genre genre, string title, string description, int releaseYear)
        {
            this.Id = id;
            this.Genre = genre;
            this.Title = title;
            this.Description = description;
            this.ReleaseYear = releaseYear;
            this.Removed = false;
        }

        public override string ToString()
        {
            string returnData = "";
            returnData += "Genre: " + this.Genre + Environment.NewLine;
            returnData += "Title: " + this.Title + Environment.NewLine;
            returnData += "Description: " + this.Description + Environment.NewLine;
            returnData += "ReleaseYear: " + this.ReleaseYear + Environment.NewLine;
            returnData += "Removed: " + this.Removed;
            return returnData;
        }

        public int returnId()
        {
            return this.Id;
        }


        public string returnTitle()
        {
            return this.Title;
        } 

        public bool returnRemovedItem()
        {
            return this.Removed;
        }

        public void RemoveItem()
        {
            this.Removed = true;
        }
    }
}