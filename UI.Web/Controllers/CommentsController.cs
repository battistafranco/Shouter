using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UI.Web.Models;
using UI.Web.Services;

namespace UI.Web.Controllers
{
    public class CommentsController : BaseController
    {
        public ActionResult Wall()
        {
            ActionResult actionResult = VerificarSesion();
            if (actionResult != null)
            {
                return RedirectToAction("LogOn", "Account");
            }
            else
            {
                return View(CommentService.GetComments());
            }

        }

        [HttpPost]
        public ActionResult Wall(string commentText)
        {
            Comment newComment = new Comment();
            newComment.email = Session["email"].ToString();
            newComment.comment = commentText;
            newComment.dateTime = DateTime.Now;
            CommentService.InsertComment(newComment);
            return RedirectToAction("Wall", "Comments");
        }




    }
}