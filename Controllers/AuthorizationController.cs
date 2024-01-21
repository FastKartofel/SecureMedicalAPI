using AuthenticationAPI.DTOs;
using AuthenticationAPI.Models;
using AuthenticationAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("[controller]")]
public class AuthorizationController : ControllerBase
{
    private readonly IAuthenticationService _authService;
    private readonly MainDbContext _context;

    public AuthorizationController(IAuthenticationService authService, MainDbContext context)
    {
        _authService = authService;
        _context = context;
    }

    [HttpPost("register")]
    public async Task<ActionResult> Register(UserRegistrationDTO registrationDto)
    {
        // Create password hash
        _authService.CreatePasswordHash(registrationDto.Password, out byte[] passwordHash, out byte[] passwordSalt);

        // Create and save the new user
        var user = new User
        {
            Username = registrationDto.Username,
            PasswordHash = passwordHash,
            PasswordSalt = passwordSalt
        };

        _context.Users.Add(user);
        await _context.SaveChangesAsync();

        return Ok("User registered successfully");
    }

    [HttpPost("login")]
    public async Task<ActionResult<LoginResponseDTO>> Login(LoginDTO loginDto)
    {
        // Find user by username
        var user = await _context.Users.FirstOrDefaultAsync(u => u.Username == loginDto.Username);
        if (user == null || !_authService.VerifyPasswordHash(loginDto.Password, user.PasswordHash, user.PasswordSalt))
        {
            return Unauthorized("Username or password is incorrect.");
        }

        // Generate JWT token
        var token = _authService.GenerateJwtToken(user);
        // In your login method after successful authentication
        user.RefreshToken = _authService.GenerateRefreshToken();
        user.RefreshTokenExpiryTime = DateTime.UtcNow.AddDays(7); // Set the expiry time
        _context.SaveChanges();


        // Return the token in the response
        return Ok(new LoginResponseDTO { Token = token });
    }

    [HttpPost("refresh-token")]
    public async Task<ActionResult> RefreshToken([FromBody] RefreshTokenDTO refreshTokenDto)
    {
        var user = await _context.Users.FirstOrDefaultAsync(u => u.RefreshToken == refreshTokenDto.RefreshToken);
        if (user == null || user.RefreshTokenExpiryTime <= DateTime.UtcNow)
        {
            return Unauthorized();
        }

        var newJwtToken = _authService.GenerateJwtToken(user);
        var newRefreshToken = _authService.GenerateRefreshToken();
        user.RefreshToken = newRefreshToken;
        _context.SaveChanges();

        return Ok(new { Token = newJwtToken, RefreshToken = newRefreshToken });
    }


}
