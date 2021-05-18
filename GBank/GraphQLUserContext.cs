using GraphQL.Authorization;
using Microsoft.Extensions.Primitives;
using Microsoft.IdentityModel.Tokens;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace GBank
{
    // <summary>
    /// Custom context class that implements <see cref="IProvideClaimsPrincipal"/>.
    /// </summary>
    public class GraphQLUserContext : Dictionary<string, object>, IProvideClaimsPrincipal
    {
        public GraphQLUserContext(StringValues authorizationHeader)
        {
            var token = authorizationHeader.FirstOrDefault()?.Split(" ").Last();
            if (token != null)
            {
                SetClaimPrincipalFromToken(token);
            }
        }

        private void SetClaimPrincipalFromToken(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            tokenHandler.ValidateToken(token, new TokenValidationParameters
            {
                ValidateLifetime = false,
                ValidateIssuer = false,
                ValidateAudience = false,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("5mhBHqs5_DTLdINd9p5m7ZJ6XDbit-secret"))
            }, out SecurityToken validatedToken);

            var jwtToken = (JwtSecurityToken)validatedToken;
            User = new ClaimsPrincipal(new ClaimsIdentity(jwtToken.Claims));
        }

        /// <inheritdoc />
        public ClaimsPrincipal User { get; set; }
    }
}
