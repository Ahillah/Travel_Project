using DomainLayer.Models.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ServiceAbstraction;
using Shared.Dto_s.Review;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReviewController : ControllerBase
    {
        private readonly IReviewServices _reviewService;

        public ReviewController(IReviewServices reviewService)
        {
            _reviewService = reviewService;
        }

        // Add Review
        // ================================

        [HttpPost]
        public async Task<IActionResult> AddReview([FromBody] CreateReviewDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _reviewService.AddReviewAsync(dto);

            return Ok(new
            {
                success = true,
                message = "Review added successfully",
                data = result
            });
        }


        // Update Review
        // ================================

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateReview(int id, [FromBody] UpdateReviewDto dto)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var isAdmin = User.IsInRole("Admin");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);


            var result = await _reviewService.UpdateReview(id, dto, userId, isAdmin);

            if (result == null)
                return NotFound("Review not found");

            return Ok(new
            {
                success = true,
                message = "Review updated successfully",
                data = result
            });
        }

        // Delete Review
        // ================================
        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReview(int id)
        {
      
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var isAdmin = User.IsInRole("Admin");
            var result = await _reviewService.DeleteReview(id, userId, isAdmin);

            if (!result)
                return NotFound();

            return Ok("Review deleted");
        }

 
        // Get Reviews by (Hotel, Tour, Flight)
        // ================================

        [HttpGet("{targetType}")]
        public async Task<IActionResult> GetReviews(string targetType)
        {
            var reviews = await _reviewService.GetReviewsAsync(targetType);

            return Ok(new
            {
                count = reviews.Count(),
                data = reviews
            });
        }
    }

}
