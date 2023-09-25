using Microsoft.AspNetCore.Http.HttpResults;
using webapi.event_.manha.Contexts;
using webapi.event_.manha.Domains;
using webapi.event_.manha.Interfaces;
using webapi.event_.manha.Uteis;

namespace webapi.event_.manha.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
      
        private readonly EventContext ctx;
       
        public UsuarioRepository()
        {
            ctx = new EventContext();
        }

        public Usuario BuscarPorEmailESenha(string email, string senha)
        {
            try
            {
                Usuario usuarioBuscado = ctx.Usuario
                    .Select(u => new Usuario
                    {
                        IdUsuario = u.IdUsuario,
                        Nome = u.Nome,
                        Email = u.Email,
                        Senha = u.Senha,
                        TiposUsuario = new TiposUsuario
                        {
                            IdTipoUsuario = u.IdTipoUsuario,
                            Titulo = u.TiposUsuario!.Titulo
                        }
                    }).FirstOrDefault(u => u.Email == email)!;

                if (usuarioBuscado != null)
                {
                    bool confere = Criptografia.CompararHash(senha, usuarioBuscado.Senha!);

                    if (confere)
                    {
                        return usuarioBuscado;
                    }
                }
                return null!;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Usuario BuscarPorId(Guid id)
        {
            try
            {
                Usuario usuario = ctx.Usuario.Select(u => new Usuario
                {
                    IdUsuario = u.IdUsuario,
                    Nome = u.Nome,

                    TiposUsuario = new TiposUsuario
                    {
                        IdTipoUsuario = u.IdTipoUsuario,
                        Titulo = u.TiposUsuario!.Titulo
                    }
                }).FirstOrDefault(u => u.IdUsuario == id)!;

                if (usuario != null)
                {
                    return usuario;
                }
                return null!;
                
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Cadastrar(Usuario usuario)
        {
            try
            {
                usuario.Senha = Criptografia.GerarHash(usuario.Senha!);

                ctx.Usuario.Add(usuario);

                ctx.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
