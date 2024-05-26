using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace API;

public class TokenService : ITokenService // Declaring the TokenService class which implements the ITokenService interface
{
    private readonly SymmetricSecurityKey _key; // Declaring a private, read-only field to hold the symmetric security key
    public TokenService(IConfiguration config) // Constructor for the TokenService class that takes an IConfiguration object
    {
        _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["TokenKey"])); // Initializing the symmetric security key using a key from the configuration settings, appsetting.dev
    }
    public string CreateToken(AppUser user) // Method to create a JWT for a given user
    {
        var claims = new List<Claim> // Creating a list of claims for the JWT payload
        {
            new Claim(JwtRegisteredClaimNames.NameId, user.UserName) // Adding a claim for the user's name
        };

        var creds = new SigningCredentials(_key, SecurityAlgorithms.HmacSha512); // Creating signing credentials using the symmetric key and HMAC-SHA512 algorithm

        var tokenDescriptor = new SecurityTokenDescriptor // Creating the token descriptor with details about the token
        {
            Subject = new ClaimsIdentity(claims), // Setting the subject with the claims identity
            Expires = DateTime.Now.AddYears(7), // Setting the token's expiration date to 7 years from now
            SigningCredentials = creds // Setting the signing credentials
        };

        var tokenHandler = new JwtSecurityTokenHandler(); // Creating a JWT security token handler

        var token = tokenHandler.CreateToken(tokenDescriptor); // Creating the token using the token handler and descriptor

        return tokenHandler.WriteToken(token); // Writing the token to a string and returning it
    }
}
