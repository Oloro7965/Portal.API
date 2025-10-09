using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Application.ViewModels
{
    public class LoginViewModel
    {
        public LoginViewModel(string id, string nome, string email)
        {
            Id = id;
            Nome = nome;
            this.email = email;
        }

        public string Id { get; private set; }
        public string Nome { get; private set; }
        public string email { get; private set; }
    }
}
