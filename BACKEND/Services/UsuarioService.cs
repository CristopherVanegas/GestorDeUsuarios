using BACKEND.DTOs;
using BACKEND.Models;
using BACKEND.Repositories;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Core.Types;

namespace BACKEND.Services
{
    public class UsuarioService
    {
        private readonly UsuarioRepository _repository;

        public UsuarioService(UsuarioRepository repository)
        {
            _repository = repository;
        }

        public async Task CreateUsuarioAsync(Usuario usuario)
        {
            try
            {
                await _repository.CreateAsync(usuario);
            }
            catch (DbUpdateException ex) when (ex.InnerException is SqlException sqlEx)
            {
                // CHECK CONSTRAINT violations suelen ser error 547
                if (sqlEx.Number == 547)
                {
                    var message = "Error de validación";

                    if (sqlEx.Message.Contains("CHK_PASSCODE"))
                        message = "La contraseña debe tener mínimo 8 caracteres, una mayúscula, un número y un símbolo.";

                    else if (sqlEx.Message.Contains("session_active"))
                        message = "Estado de sesión inválido.";

                    else if (sqlEx.Message.Contains("user_name"))
                        message = "El nombre de usuario no cumple las reglas.";

                    else if (sqlEx.Message.Contains("mail"))
                        message = "El correo electrónico no es válido.";

                    throw new ApplicationException(message);
                }

                throw;
            }
        }

        public async Task<UsuarioDetalleDto?> GetUsuarioDetalleAsync(int id)
        {
            var usuario = await _repository.GetByIdWithPersonaAsync(id);
            if (usuario == null) return null;

            return new UsuarioDetalleDto
            {
                IdUsuario = usuario.IdUsuario,
                UserName = usuario.UserName,
                Mail = usuario.Mail,
                SessionActive = usuario.SessionActive!,
                Status = usuario.Status!,
                PersonaId = usuario.PersonaIdPersona2,
                PersonaNombre = usuario.PersonaIdPersona2Navigation.Nombres,
                PersonaApellido = usuario.PersonaIdPersona2Navigation.Apellidos
            };
        }

        public async Task<bool> UpdateParcialAsync(int id, UsuarioUpdateDto dto)
        {
            var usuario = await _repository.GetByIdAsync(id);
            if (usuario == null)
                return false;

            if (!string.IsNullOrWhiteSpace(dto.UserName))
                usuario.UserName = dto.UserName;

            if (!string.IsNullOrWhiteSpace(dto.Passcode))
                usuario.Passcode = dto.Passcode;

            if (!string.IsNullOrWhiteSpace(dto.Mail))
                usuario.Mail = dto.Mail;

            if (!string.IsNullOrWhiteSpace(dto.SessionActive))
                usuario.SessionActive = dto.SessionActive;

            await _repository.UpdateAsync(usuario);
            return true;
        }

        public async Task DeleteUsuarioAsync(int id) =>
            await _repository.DeleteAsync(id);
    }

}
