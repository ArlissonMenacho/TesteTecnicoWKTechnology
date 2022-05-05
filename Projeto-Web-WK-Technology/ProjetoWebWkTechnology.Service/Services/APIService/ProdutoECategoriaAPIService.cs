using Newtonsoft.Json;
using ProjetoWebWkTechnology.Domain.Entities;
using ProjetoWebWkTechnology.Service.Interfaces.APIService;
using ProjetoWebWkTechnology.Service.ViewModels.Categoria;
using ProjetoWebWkTechnology.Service.ViewModels.Produto;
using System.Net;
using System.Net.Http.Headers;
using System.Text;

namespace ProjetoWebWkTechnology.Service.Services.APIService
{
    public class ProdutoECategoriaAPIService : IProdutoECategoriaAPIService
    {
        const string baseAddress = "https://localhost:7221";

        private static HttpClient MontarClientHtpp()
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Add("Origin", "http://localhost");
            client.BaseAddress = new Uri(baseAddress);
            return client;
        }

        #region Requisições de Categorias
        public async Task<List<Categoria>> BuscarTodasCategorias(CancellationToken cancellationToken)
        {
            var client = MontarClientHtpp();
            var response = await client.GetAsync(baseAddress + $"/categoria/BuscarTodasCategoria", cancellationToken);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                string responseContent = await response.Content.ReadAsStringAsync();
                List<Categoria> dados = JsonConvert.DeserializeObject<List<Categoria>>(responseContent);
                return dados;
            }
            else
            {
                throw new Exception("Erro na requisição Buscar Todas Categorias!");
            }
        }
        public async Task<Categoria> BuscarCategoriaPorId(Guid id, CancellationToken cancellationToken)
        {
            var client = MontarClientHtpp();
            var response = await client.GetAsync(baseAddress + $"/categoria/BuscaPorId/{id}", cancellationToken);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                string responseContent = await response.Content.ReadAsStringAsync();
                Categoria dados = JsonConvert.DeserializeObject<Categoria>(responseContent);
                return dados;
            }
            else
            {
                throw new Exception("Erro na requisição Buscar Categoria Por ID!");
            }
        }
        public async Task CriarCategoria(Categoria categoria, CancellationToken cancellationToken)
        {
            var client = MontarClientHtpp();
            var requestData = new CreateCategoriaViewModel(categoria.Nome, categoria.Descricao);
            HttpContent content = new StringContent(JsonConvert.SerializeObject(requestData), Encoding.UTF8);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var response = await client.PostAsync(baseAddress + $"/categoria/CadastrarCategoria", content, cancellationToken);
            if (response.StatusCode != HttpStatusCode.OK)
            {
                throw new Exception("Erro na requisição Criar Categoria!");
            }
        }
        public async Task AtualizarCategoria(Categoria categoria, CancellationToken cancellationToken)
        {
            var client = MontarClientHtpp();
            var requestData = new UpdateCategoriaViewModel(categoria.Id, categoria.Nome, categoria.Descricao);
            HttpContent content = new StringContent(JsonConvert.SerializeObject(requestData), Encoding.UTF8);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var response = await client.PutAsync(baseAddress + $"/categoria/AtualizarCategoria", content);
            if (response.StatusCode != HttpStatusCode.OK)
            {
                throw new Exception("Erro na requisição Atualizar Categoria!");
            }
        }
        public async Task DeletarCategoria(Guid id, CancellationToken cancellationToken)
        {
            var client = MontarClientHtpp();
            var response = await client.DeleteAsync(baseAddress + $"/categoria/DeletarCategoria/{id}", cancellationToken);
            if (response.StatusCode != HttpStatusCode.OK)
            {
                throw new Exception("Erro na requisição Atualizar Categoria!");
            }
        }
        #endregion

        #region Requisições de Produtos
        public async Task<List<Produto>> BuscarTodosProdutos(CancellationToken cancellationToken)
        {
            var client = MontarClientHtpp();
            var response = await client.GetAsync(baseAddress + $"/Produto/BuscarTodosProdutos", cancellationToken);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                string responseContent = await response.Content.ReadAsStringAsync();
                List<Produto> dados = JsonConvert.DeserializeObject<List<Produto>>(responseContent);
                return dados;
            }
            else
            {
                throw new Exception("Erro na requisição Buscar Todos Produtos!");
            }
        }
        public async Task<Produto> BuscarProdutoPorId(Guid id, CancellationToken cancellationToken)
        {
            var client = MontarClientHtpp();
            var response = await client.GetAsync(baseAddress + $"/Produto/BuscaPorId/{id}", cancellationToken);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                string responseContent = await response.Content.ReadAsStringAsync();
                Produto dados = JsonConvert.DeserializeObject<Produto>(responseContent);
                dados.PrecoInformado = dados.Preco.ToString();
                dados.CategoriaSelecionada = dados.CategoriaId.ToString();
                return dados;
            }
            else
            {
                throw new Exception("Erro na requisição Buscar Produto por ID!");
            }
        }
        public async Task CriarProduto(Produto produto, CancellationToken cancellationToken)
        {
            if (produto.CategoriaSelecionada != null)
            {
                produto.CategoriaId = Guid.Parse(produto.CategoriaSelecionada);
            }
            if (!string.IsNullOrEmpty(produto.PrecoInformado))
            {
                produto.Preco = double.Parse(produto.PrecoInformado.Split(" ").LastOrDefault());
            }

            var client = MontarClientHtpp();
            var requestData = new CreateProdutoViewModel(produto.Nome, produto.Descricao, produto.Preco, produto.Marca, produto.CategoriaId);
            HttpContent content = new StringContent(JsonConvert.SerializeObject(requestData), Encoding.UTF8);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var response = await client.PostAsync(baseAddress + $"/Produto/CadastrarProduto", content);
            if (response.StatusCode != HttpStatusCode.OK)
            {
                throw new Exception("Erro na requisição Criar Produto!");
            }

        }
        public async Task AtualizarProduto(Produto produto, CancellationToken cancellationToken)
        {
            if (produto.CategoriaSelecionada != null)
            {
                produto.CategoriaId = Guid.Parse(produto.CategoriaSelecionada);
            }
            if (!string.IsNullOrEmpty(produto.PrecoInformado))
            {
                produto.Preco = double.Parse(produto.PrecoInformado.Split(" ").LastOrDefault());
            }
            var client = MontarClientHtpp();
            var requestData = new UpdateProdutoViewModel(produto.Id, produto.Nome, produto.Descricao, produto.Preco, produto.Marca, produto.CategoriaId);
            HttpContent content = new StringContent(JsonConvert.SerializeObject(requestData), Encoding.UTF8);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var response = await client.PutAsync(baseAddress + $"/Produto/AtualizarProduto", content);
            if (response.StatusCode != HttpStatusCode.OK)
            {
                throw new Exception("Erro na requisição Atualizar Produto!");
            }
        }
        public async Task DeletarProduto(Guid id, CancellationToken cancellationToken)
        {
            var client = MontarClientHtpp();
            var response = await client.DeleteAsync(baseAddress + $"/produto/DeletarProduto/{id}", cancellationToken);
            if (response.StatusCode != HttpStatusCode.OK)
            {
                throw new Exception("Erro na requisição Deletar Produto!");
            }
        }
        #endregion

    }
}
