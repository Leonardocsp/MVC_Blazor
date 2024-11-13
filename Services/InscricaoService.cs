using Microsoft.EntityFrameworkCore;
using MVC_Blazor.Data;
using MVC_Blazor.Model;
using BCrypt.Net;

namespace MVC_Blazor.Services
{
    public class InscricaoService
    {
        private readonly BancoContext _context;

        public InscricaoService(BancoContext context)
        {
            _context = context;
        }

        public async Task<List<Usuario>> ObterUsuariosAsync()
        {
            return await _context.Usuarios1.ToListAsync();
        }

        public async Task<List<Curso>> ObterCursosAsync()
        {
            return await _context.Cursos.ToListAsync();
        }

        public async Task<List<Inscricao>> ObterInscricoesAsync()
        {
            return await _context.Inscricoes.ToListAsync();
        }

        public async Task<List<Inscricao>> ObterInscricoesPorUsuarioAsync(int usuarioId)
        {
            return await _context.Inscricoes
                .Where(i => i.ID_Usuario == usuarioId)
                .ToListAsync();
        }

        public async Task CadastrarCursoAsync(Curso curso)
        {
            await _context.Cursos.AddAsync(curso);
            await _context.SaveChangesAsync();
        }

        public async Task AdicionarInscricaoAsync(Inscricao inscricao)
        {
            await _context.Inscricoes.AddAsync(inscricao);
            await _context.SaveChangesAsync();
        }

        public async Task CadastrarUsuarioAsync(Usuario usuario)
        {
            string senhaHash = BCrypt.Net.BCrypt.HashPassword(usuario.Senha);
            usuario.Senha = senhaHash;
            await _context.Usuarios1.AddAsync(usuario);
            await _context.SaveChangesAsync();
        }

        public async Task AtualizarSenhasAsync()
        {
            var usuarios = await _context.Usuarios1.ToListAsync();
            foreach (var usuario in usuarios)
            {
                string senhaHash = BCrypt.Net.BCrypt.HashPassword(usuario.Senha);
                usuario.Senha = senhaHash;
            }
            await _context.SaveChangesAsync();
        }

        public async Task<bool> UsuarioValidoAsync(int usuarioId)
        {
            return await _context.Usuarios1.AnyAsync(u => u.ID_Usuario == usuarioId);
        }

        public async Task<bool> CursoValidoAsync(int cursoId)
        {
            return await _context.Cursos.AnyAsync(c => c.ID_Curso == cursoId);
        }

        public async Task<Inscricao> ObterInscricaoPorIdAsync(int id)
        {
            return await _context.Inscricoes.FindAsync(id);
        }

        public async Task AtualizarInscricaoAsync(Inscricao inscricao)
        {
            var existingInscricao = await _context.Inscricoes.FindAsync(inscricao.ID_Inscricao);
            if (existingInscricao != null)
            {
                existingInscricao.ID_Usuario = inscricao.ID_Usuario;
                existingInscricao.ID_Curso = inscricao.ID_Curso;
                existingInscricao.Status_Inscricao = inscricao.Status_Inscricao;
                existingInscricao.Data_Inscricao = inscricao.Data_Inscricao; 

                await _context.SaveChangesAsync();
            }
            else
            {
                throw new Exception("Inscrição não encontrada."); 
            }
        }

        // Exclui uma inscrição
        public async Task ExcluirInscricaoAsync(int id)
        {
            var inscricao = await _context.Inscricoes.FindAsync(id);
            if (inscricao != null)
            {
                _context.Inscricoes.Remove(inscricao);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new Exception("Inscrição não encontrada."); 
            }
        }
        public async Task AtualizarCursoAsync(Curso curso, int usuarioId)
        {
            if (usuarioId != 1)
            {
                throw new UnauthorizedAccessException("Apenas o usuário de ID 1 pode editar cursos.");
            }

            var existingCurso = await _context.Cursos.FindAsync(curso.ID_Curso);
            if (existingCurso != null)
            {
                existingCurso.Nome_Curso = curso.Nome_Curso; 

                await _context.SaveChangesAsync(); 
            }
            else
            {
                throw new Exception("Curso não encontrado."); 
            }
        }
        public async Task ExcluirCursoAsync(int id, int usuarioId)
        {
            if (usuarioId != 1)
            {
                throw new UnauthorizedAccessException("Apenas o usuário de ID 1 pode excluir cursos.");
            }

            var curso = await _context.Cursos.FindAsync(id);
            if (curso != null)
            {
                _context.Cursos.Remove(curso);
                await _context.SaveChangesAsync(); 
            }
            else
            {
                throw new Exception("Curso não encontrado."); 
            }
        }
    }
}
