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

            route.MapPost("/InsertObra", async (Obra obra, ObraBLL _oBll, ClienteBLL _cBll) =>
            {
                var sucesso = false;

                if (obra is null)
                    return Results.BadRequest("Objeto Inválido");

                if (obra is not null)
                {
                    var result = await _cBll.GetNomeCliente(obra.NomeCliente);

                    if(result.Nome == obra.NomeCliente)
                    {
                        obra.CodCliente = result.CodCliente;
                        sucesso = await _oBll.InsertObra(obra);
                    }else
                        return Results.BadRequest("Cliente não encontrado no sistema.");
                }
                
                return sucesso == true ? Results.Ok("Obra cadastrada com sucesso!") : Results.BadRequest("Erro ao cadastra a obra.");
            });

            route.MapGet("/GetClientes", async (ClienteBLL _cBll) =>
            {
                var clientes = await _cBll.GetListClientes();
                return clientes != null ? Results.Ok(clientes) : Results.NotFound();
            });

            route.MapGet("/GetObras", async (ObraBLL _oBll) =>
            {
                var obras = await _oBll.GetObras();
                return obras != null ? Results.Ok(obras) : Results.NotFound();
            });

            route.MapPost("/UpInsertObraEquipamento", async (ObraEquipamento obraEquipamento, ObraEquipamentoBLL _oeBll) =>
            {
                var sucesso = false;

                if (obraEquipamento is null)
                    return Results.BadRequest("Objeto Inválido");

                if (obraEquipamento is not null)
                {
                    var result = await _oeBll.GetCodEquipamento(obraEquipamento.Equipamento.Nome);

                    if (result.Nome == obraEquipamento.Equipamento.Nome)
                    {
                        obraEquipamento.CodEquipamento = result.CodEquipamento;
                        sucesso = await _oeBll.UpInsertObraEquipamento(obraEquipamento);
                    }
                    else
                        return Results.BadRequest("Equipamento não encontrado no sistema.");
                }

                return sucesso == true ? Results.Ok("Equipamento cadastrado a obra com sucesso!") : Results.BadRequest("Erro ao cadastra o equipamento cadastrado a obra.");
            });
        }
    }
}
