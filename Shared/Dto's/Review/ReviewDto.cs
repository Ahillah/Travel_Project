using DomainLayer.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Dto_s.Review
{

    public class ReviewDto
    {
        public int Id { get; set; }
        public int TargetId { get; set; }
        public ReviewTargetType TargetType { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; }
        public DateTime ReviewDate { get; set; }
        public string UserId { get; set; }
        public string UserName { get; set; }
    }
}