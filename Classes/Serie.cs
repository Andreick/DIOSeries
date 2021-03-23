using System;
using Enums;

namespace Classes
{
    public class Serie : BaseEntity
    {
        public Serie(int id, Genre genre, string title, string description, int year)
        {
            Id = id;
            Genre = genre;
            Title = title;
            Description = description;
            Year = year;
            IsDeleted = false;
        }
        public Genre Genre { get; private set; }

        public string Title { get; private set; }

        public string Description { get; private set; }

        public int Year { get; private set; }

        public bool IsDeleted { get; private set; }

        public void Delete()
        {
            IsDeleted = true;
        }

        public override string ToString()
        {
            string str = "";
            str += $"Genre: {Genre}{Environment.NewLine}";
            str += $"Title: {Title}{Environment.NewLine}";
            str += $"Description: {Description}{Environment.NewLine}";
            str += $"Release Year: {Year}{Environment.NewLine}";
            str += $"Deleted: {IsDeleted}";
            return str;
        }
    }
}