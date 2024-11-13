using System.Security.Claims;
using Microsoft.EntityFrameworkCore;
using MVC_Blazor.Data;
using MVC_Blazor.Model;

public class AuthService
{
    private readonly BancoContext _context;

    public AuthService(BancoContext context)
    {
        _context = context;
    }

    public Usuario CurrentUser { get; private set; } 

    public bool IsUserLoggedIn => CurrentUser != null;

    public async Task<bool> LoginAsync(string email, string senha, string nomeUsuario)
    {
        var usuario = await _context.Usuarios1
            .FirstOrDefaultAsync(u => u.Email == email && u.Nome == nomeUsuario);

        if (usuario == null)
        {
            return false; 
        }

        if (BCrypt.Net.BCrypt.Verify(senha, usuario.Senha))
        {
            CurrentUser = usuario; 
            return true; 
        }

        return false;
    }

    public int GetUserId()
    {
        if (CurrentUser == null)
        {
            throw new UnauthorizedAccessException("Usuário não autenticado.");
        }
        return CurrentUser.ID_Usuario; 
    }

    public void Logout()
    {
        CurrentUser = null; 
    }
}
