using Catalogo.Domain.Validation;
using System.Collections.Generic;

namespace Catalogo.Domain.Entities
{
    public sealed class Produto : Entity
    {
        public Produto(string nome, string descricao, decimal preco,
            string imagemUrl, int estoque, DateTime dataCadastro)
        {
            ValidateDomain(nome, descricao, preco, imagemUrl, estoque, dataCadastro);
        }

        public string Nome { get; private set; }
        public string Descricao { get; private set; }
        public decimal Preco { get; private set; }
        public string ImagemUrl { get; private set; }
        public int Estoque { get; private set; }
        public DateTime DataCadastro { get; private set; }
        public int CategoriaId { get; private set; }

        public void Update(string nome, string descricao, decimal preco, string imagemUrl,
            int estoque, DateTime dataCadastro, int categoriaId)
        {
            ValidateDomain(nome, descricao, preco, imagemUrl, estoque, dataCadastro);
            CategoriaId = categoriaId;
        }

        private void ValidateDomain(string nome, string descricao, decimal preco, string imagemUrl,
             int estoque, DateTime dataCadastro)
        {
            DomainExceptionValidation.When(string.IsNullOrWhiteSpace(nome),
                "Nome inválido. O nome é obrigatório.");

            DomainExceptionValidation.When(string.IsNullOrWhiteSpace(imagemUrl),
                "Nome da imagem inválido. O nome é obrigatório.");

            DomainExceptionValidation.When(nome.Length < 3,
                "Nome inválido. O nome precisa ter no mínimo 3 caracteres.");

            DomainExceptionValidation.When(imagemUrl.Length < 5,
                "Nome da imagem inválido. O nome da imagem precisa ter no mínimo 5 caracteres.");

            DomainExceptionValidation.When(preco < 0,
                "Preço inválido. O preço não pode ser menor que zero.");

            DomainExceptionValidation.When(estoque < 0,
                "Estoque inválido. A quantidade de estoque não pode ser menor que zero.");

            Nome = nome;
            Descricao = descricao;
            Preco = preco;
            ImagemUrl = imagemUrl;
            Estoque = estoque;
            DataCadastro = dataCadastro;
        }

    }
}