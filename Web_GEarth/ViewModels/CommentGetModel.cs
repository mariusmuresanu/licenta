using System;
using Web_GEarth.Models;

namespace Web_GEarth.ViewModels
{
    public class CommentGetModel
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public bool Important { get; set; }
        public int? RouteId { get; set; }

        public static CommentGetModel FromComment(Comment c)
        {
            return new CommentGetModel
            {
                Id = c.Id,
                RouteId = c.Route?.Id,
                Important = c.Important,
                Text = c.Text
            };
        }
    }
}