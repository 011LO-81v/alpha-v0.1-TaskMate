using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskMate.Core.Entities;

namespace TaskMate.Services
{
    public class SessionManager
    {
        private static SessionManager _instance;

        // Esto asegura que toda la aplicación acceda al mismo usuario conectado
        public static SessionManager Instance => _instance ?? (_instance = new SessionManager());

        public Usuario CurrentUser { get; private set; }

        private SessionManager() { }

        public void Login(Usuario usuario)
        {
            CurrentUser = usuario;
        }

        public void Logout()
        {
            CurrentUser = null;
        }
    }
}