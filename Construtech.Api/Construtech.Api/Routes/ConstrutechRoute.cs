using BLL;
using DTO;

namespace Construtech.Api.Routes
{
    public static class ConstrutechRoute
    {
        public static void ConstrutechRoutes(this WebApplication app)
        {
            var route = app.MapGroup("contrutechApi");

            route.MapGet("/pessoa/{CodPessoa}", async (short CodPessoa, PessoaBLL pBll) =>
            {
                var pessoa = await pBll.GetPessoa(CodPessoa);
                return pessoa != null ? Results.Ok(pessoa) : Results.NotFound();
            });

            route.MapPost("/pessoa", async (PessoaDTO pessoaDTO, PessoaBLL pBll) =>
            {
                var pessoa = await pBll.InsertPessoa(pessoaDTO);
                return pessoa ? Results.Ok("Pessoa cadastrada com sucesso!") : Results.BadRequest("Erro ao criar pessoa.");
            });
        }
    }
}
