﻿using Crops_Shop_Project.Data;
using Crops_Shop_Project.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Crops_Shop_Project.Controllers
{
    [Authorize(Roles ="Admin,Seller,Buyer")]
    public class CommentController : Controller
    {
        private CropsShopContext _context;
        public CommentController(CropsShopContext context)
        {
            _context = context;
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult addComment(int productId,string userName,string comment)
        {
            try
            {
                Comment newComment = new Comment
                {
                    productId = productId,
                    userName = userName,
                    comment = comment,
                };
                _context.comments.Add(newComment);
                _context.SaveChanges();
                return RedirectToAction("ProductDetails", "Product", new { productId = productId });
            }
            catch(Exception e) 
            {
                return NotFound();
            }
        }
    }
}
