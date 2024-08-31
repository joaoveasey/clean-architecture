using Catalogo.Domain.Validation;
using System.Collections.Generic;

namespace Catalogo.Domain.Entities
{
    public sealed class Categoria : Entity
    {
        public Categoria(string nome, string imagemUrl)
        {
            ValidateDomain(nome, imagemUrl);
        }

        public Categoria(int id, string nome, string imagemUrl)
        {
            DomainExceptionValidation.When(id < 0, "valor de Id inv�lido");
            Id = id;
            ValidateDomain(nome, imagemUrl);
        }

        public string Nome { get; private set; }
        public string ImagemUrl { get; private set; }
        public ICollection<Produto> Produtos { get; set; }

        private void ValidateDomain(string nome, string imagemUrl)
        {
            DomainExceptionValidation.When(string.IsNullOrWhiteSpace(nome),
                "Nome inv�lido. O nome � obrigat�rio.");

            DomainExceptionValidation.When(string.IsNullOrWhiteSpace(imagemUrl),
                "Nome da imagem inv�lido. O nome � obrigat�rio.");

            DomainExceptionValidation.When(nome.Length < 3,
                "Nome inv�lido. O nome precisa ter no m�nimo 3 caracteres.");

            DomainExceptionValidation.When(imagemUrl.Length < 5,
                "Nome da imagem inv�lido. O nome da imagem precisa ter no m�nimo 5 caracteres.");

            Nome = nome;
            ImagemUrl = imagemUrl;
        }
    }
}