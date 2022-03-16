﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Entities.Models;
using MyDatabase;

namespace Travel_Agency.Controllers
{
    public class ReplyCommentController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ReplyComment
        public ActionResult Index()
        {
            var replyComments = db.ReplyComments.Include(r => r.Comment);
            return View(replyComments.ToList());
        }

        // GET: ReplyComment/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReplyComment replyComment = db.ReplyComments.Find(id);
            if (replyComment == null)
            {
                return HttpNotFound();
            }
            return View(replyComment);
        }

        // GET: ReplyComment/Create
        public ActionResult Create()
        {
            ViewBag.CommentId = new SelectList(db.Comments, "CommentId", "CommentContent");
            return View();
        }

        // POST: ReplyComment/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CommentReplyVM com)
        {
            ReplyComment rcom = new ReplyComment();
            rcom.ReplyContent = com.Reply;
            rcom.CommentId = com.ComId;
            rcom.ReplyPostTime = DateTime.Now;
            db.ReplyComments.Add(rcom);
            db.SaveChanges();

            return RedirectToAction("Index","Comment");

        }

        

        // GET: ReplyComment/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReplyComment replyComment = db.ReplyComments.Find(id);
            if (replyComment == null)
            {
                return HttpNotFound();
            }
            ViewBag.CommentId = new SelectList(db.Comments, "CommentId", "CommentContent", replyComment.CommentId);
            return View(replyComment);
        }

        // POST: ReplyComment/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ReplyCommentId,ReplyContent,ReplyPostTime,CommentId")] ReplyComment replyComment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(replyComment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CommentId = new SelectList(db.Comments, "CommentId", "CommentContent", replyComment.CommentId);
            return View(replyComment);
        }

        // GET: ReplyComment/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReplyComment replyComment = db.ReplyComments.Find(id);
            if (replyComment == null)
            {
                return HttpNotFound();
            }
            return View(replyComment);
        }

        // POST: ReplyComment/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ReplyComment replyComment = db.ReplyComments.Find(id);
            db.ReplyComments.Remove(replyComment);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
