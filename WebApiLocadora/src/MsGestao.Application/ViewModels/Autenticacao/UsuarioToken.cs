using System;
using System.Collections.Generic;

namespace Locadora.Application.ViewModels.Autenticacao
{
    public class UsuarioToken
    {
        public bool Authenticated { get; set; }
        public DateTime Expiration { get; set; }
        public string Token { get; set; }
        public string Message { get; set; }
        public string UserName { get; set; }
        //public PermissaoUsuario [] Claims { get; set; }
        public ICollection<PermissaoUsuario> Claims { get; set; }
    }
}
