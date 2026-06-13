
//arquivo aonde o token é gerado e avaliado
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
namespace API_PIMV.Helpers
{
    public class JwtSecurityTokenHandlerWrapper
    {
        // criar a instancia do JwtSecurityTokenHandler
        private readonly JwtSecurityTokenHandler _jwtSecurityTokenHandler;

        public JwtSecurityTokenHandlerWrapper()
        {
            _jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
        }

        //gerar token
        public string GenerateJwtToken(int userId, string email)
        {
            var key = Encoding.UTF8.GetBytes(Environment.GetEnvironmentVariable("JWT_SECRET")!);

            // Create claims for user identity and role
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, userId.ToString()),
                new Claim(ClaimTypes.Email, email)
            };

            // Create an identity from the claims
            var identity = new ClaimsIdentity(claims);

            // Describe the token settings
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Issuer = Environment.GetEnvironmentVariable("JWT_ISSUER"),
                Audience = Environment.GetEnvironmentVariable("JWT_AUDIENCE"),
                Subject = identity,
                Expires = DateTime.UtcNow.AddMinutes(30),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            // Create a JWT security token
            var token = _jwtSecurityTokenHandler.CreateJwtSecurityToken(tokenDescriptor);

            // Write the token as a string and return it
            return _jwtSecurityTokenHandler.WriteToken(token);
        }

        // Validate a JWT token
        public ClaimsPrincipal ValidateJwtToken(string token)
        {
            // Retrieve the JWT secret from environment variables and encode it
            var key = Encoding.UTF8.GetBytes(Environment.GetEnvironmentVariable("JWT_SECRET")!);

            try
            {
                // Create a token handler and validate the token
                var tokenHandler = new JwtSecurityTokenHandler();
                var claimsPrincipal = tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = Environment.GetEnvironmentVariable("JWT_ISSUER"),
                    ValidAudience = Environment.GetEnvironmentVariable("JWT_AUDIENCE"),
                    IssuerSigningKey = new SymmetricSecurityKey(key)
                }, out SecurityToken validatedToken);

                // Return the claims principal
                return claimsPrincipal;
            }
            catch (SecurityTokenExpiredException)
            {
                // Handle token expiration
                throw new ApplicationException("Token has expired.");
            }
        }
    }
}
