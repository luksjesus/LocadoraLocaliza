namespace Locadora.Domain.Models
{
    public class Cliente : Entity
    {
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string Email { get; set; }

        public string Cep { get; set; }
        public string Logradouro { get; set; }
        public int Numero { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Complemento { get; set; }


    }
}
