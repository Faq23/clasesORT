using Obligatorio.LogicaAplicacion.dtos.Usuarios;
using Obligatorio.LogicaAplicacion.Mapper;
using Obligatorio.LogicaNegocio.InterfacesDominio;
using Obligatorio.LogicaNegocio.InterfacesLogicaAplicacion;
using Obligatorio.LogicaNegocio.InterfacesRepositorio;
using System.Globalization;

namespace Obligatorio.LogicaAplicacion.CasosUso.Usuarios
{
    public class GenerateEmailUsuario : ICUEmailGenerator, INormalizar
    {
        private IRepositorioUsuario _repo;

        public GenerateEmailUsuario(IRepositorioUsuario repo)
        {
            _repo = repo;
        }

        public string Execute(string firstPart, string lastPart)
        {
            string emailBase = Normalizar(firstPart.Substring(0, 3)) + Normalizar(lastPart.Substring(0, 3));
            string emailDomain = "@laempresa.com";

            if (ValidarExistente(emailBase + emailDomain))
            {
                string number = GenerateRandomNumber();
                emailBase += number;
            }

            string completeEmail = emailBase + emailDomain;

            return completeEmail;
        }

        public bool ValidarExistente(string email)
        {
            IEnumerable<UsuarioDTOListado> usuarios = UsuarioMapper.ToListDTO(_repo.GetAll());

            foreach (UsuarioDTOListado item in usuarios)
            {
                if (item.Email.Equals(email))
                {
                    return item.Email.Equals(email);
                }
            }

            return false;
        }

        public string GenerateRandomNumber()
        {
            Random rand = new Random();

            int number = rand.Next(1, 9999);

            return number.ToString();
        }

        public string Normalizar(string str)
        {
            return new string(str
                .Normalize(System.Text.NormalizationForm.FormD)
                .Where(c => CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark)
                .ToArray());
        }

    }
}
