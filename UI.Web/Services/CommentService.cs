using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UI.Web.Models;
using UI.Web.ViewModels;

namespace UI.Web.Services
{
    public class CommentService
    {
        public static IEnumerable<Comment> GetComments()
        {

            MongoDatabase db = DBConnection.Db();
            var comments = db.GetCollection<Comment>("comments");
            MongoDB.Driver.Builders.SortByBuilder sort = new MongoDB.Driver.Builders.SortByBuilder();
            sort.Descending("dateTime");
            return comments.FindAll().SetSortOrder(sort).ToList<Comment>();
        }

     

        public static void InsertComment(Comment comment)
        {
            MongoDatabase db = DBConnection.Db();
            if (!db.CollectionExists("comments"))
                db.CreateCollection("comments");
            var comments = db.GetCollection("comments");

            var commentObject = new BsonDocument();
            commentObject["email"] = comment.email;
            commentObject["comment"] = comment.comment;
            commentObject["dateTime"] = DateTime.Now;
            comments.Insert(commentObject);
        }
    }
}