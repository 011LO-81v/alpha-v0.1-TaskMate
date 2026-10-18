using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskMate.Core.Entities;
using TaskMate.Data.Repositories;
using TaskMate.Services.Security;

namespace TaskMate.Services
{
    public class UsuarioService
    {
        private readonly UsuarioRepository _repository;

        public UsuarioService()
        {
            _repository = new UsuarioRepository();
        }

        // Este método será llamado por la pantalla de Login cuando el usuario haga clic en "Ingresar"
        public bool Authenticate(string correo, string password)
        {
            // 1. Buscamos al usuario en MySQL
            Usuario user = _repository.GetUsuarioByCorreo(correo);

            if (user != null)
            {
                // 2. Encriptamos lo que escribió en pantalla
                string hashedInput = SecurityHelper.HashPassword(password);

                // 3. Comparamos con la base de datos
                if (user.PasswordHash == hashedInput)
                {
                    // 4. Si coincide, le damos el pase VIP
                    SessionManager.Instance.Login(user);
                    return true;
                }
            }
            return false; // Si algo falla, lo rechazamos
        }
    }
}
