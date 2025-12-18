using DomainLayer.Models.Identity;
using DomainLayer.Models.User;
using Shared.Dto_s.Review;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceAbstraction
{
    public interface IReviewServices
    {
        Task<ReviewDto> AddReviewAsync(CreateReviewDto dto);
        Task<bool> UpdateReview(int reviewId, UpdateReviewDto dto, string currentUserId, bool isAdmin);
        Task<bool> DeleteReview(int reviewId, string currentUserId, bool isAdmin);
        Task<IEnumerable<ReviewDto>> GetReviewsAsync(string targetType);
    }
}
