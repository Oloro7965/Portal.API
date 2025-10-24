using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Application.ViewModels
{
    public class LoginViewModel
    {
        public LoginViewModel(string id, string nome, string email, string tipoUsuario)
        {
            Id = id;
            Nome = nome;
            this.email = email;
            this.TipoUsuario = tipoUsuario;
        }

        public string Id { get; private set; }
        public string Nome { get; private set; }
        public string email { get; private set; }
        public string TipoUsuario { get; private set; }
    }
}
