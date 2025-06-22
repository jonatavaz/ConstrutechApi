using BLL;
using POJO;

namespace Construtech.Api.Routes
{
    public static class ConstrutechRoute
    {
        public static void ConstrutechRoutes(this WebApplication app)
        {
            var route = app.MapGroup("construtechApi");

            route.MapGet("/GetPessoa/{CPF, Senha}", async (string CPF, string Senha, PessoaBLL _pBll) =>
            {
                var pessoa = await _pBll.GetPessoa(CPF, Senha);
                return pessoa != null ? Results.Ok(pessoa) : Results.NotFound();
            });

            route.MapPost("/InsertPessoa", async (Pessoa pessoa, PessoaBLL _pBll) =>
            {
                if (pessoa is null || pessoa.Usuario is null || pessoa.Contato is null)                
                    return Results.BadRequest("Objeto Inválido");

                var sucesso = await _pBll.InsertPessoa(pessoa);
                return sucesso == -1 ? Results.Ok("Pessoa cadastrada com sucesso!") : Results.BadRequest("Erro ao criar pessoa.");
            });

            route.MapPost("/InsertObra", async (Obra obra, ObraBLL _oBll) =>
            {
                if (obra is null)
                    return Results.BadRequest("Objeto Inválido");


                var sucesso = await _oBll.InsertObra(obra);
                return sucesso == true ? Results.Ok("Obra cadastrada com sucesso!") : Results.BadRequest("Erro ao cadastra a obra.");
            });

            route.MapGet("/GetClientes", async (ClienteBLL _cBll) =>
            {
                var clientes = await _cBll.GetListClientes();
                return clientes != null ? Results.Ok(clientes) : Results.NotFound();
            });
        }
    }
}
