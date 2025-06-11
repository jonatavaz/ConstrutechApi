using BLL;
using POJO;

namespace Construtech.Api.Routes
{
    public static class ConstrutechRoute
    {
        public static void ConstrutechRoutes(this WebApplication app)
        {
            var route = app.MapGroup("contrutechApi");

            route.MapGet("/GetPessoa/{Email, Senha}", async (string Email, string Senha, PessoaBLL _pBll) =>
            {
                var pessoa = await _pBll.GetPessoa(Email, Senha);
                return pessoa != null ? Results.Ok(pessoa) : Results.NotFound();
            });

            route.MapPost("/InsertPessoa", async (Pessoa pessoa, PessoaBLL _pBll) =>
            {
                var sucesso = await _pBll.InsertPessoa(pessoa);
                return sucesso ? Results.Ok("Pessoa cadastrada com sucesso!") : Results.BadRequest("Erro ao criar pessoa.");
            });
        }
    }
}
