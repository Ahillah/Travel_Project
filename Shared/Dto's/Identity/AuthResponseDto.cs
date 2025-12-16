using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Dtos.Identity
{
    public class AuthResponseDto
    {
            public bool IsSuccess { get; set; }
            public string Token { get; set; } = default!;
            public string DisplayName { get; set; } = default!;
            public string Role { get; set; } = default!;
        

    }
}
