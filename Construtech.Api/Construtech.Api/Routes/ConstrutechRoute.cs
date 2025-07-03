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

            route.MapGet("/GetObraEquipamentos/{CodObra}", async (int CodObra, ObraEquipamentoBLL _oeBll) =>
            {
                var obraEquipamentos = await _oeBll.GetListObraEquipamento(CodObra);
                return obraEquipamentos != null ? Results.Ok(obraEquipamentos) : Results.NotFound();
            });

            //route.MapPost("/UpInsertObraEquipamento", async (ObraEquipamento obraEquipamento, ObraEquipamentoBLL _oeBll) =>
            //{
            //    var sucesso = false;

            //    if (obraEquipamento is null)
            //        return Results.BadRequest("Objeto Inválido");

            //    if (obraEquipamento is not null)
            //    {
            //        var result = await _oeBll.GetCodEquipamento(obraEquipamento.Equipamento.NomeEquipamento);

            //        if (result.NomeEquipamento == obraEquipamento.Equipamento.NomeEquipamento)
            //        {
            //            obraEquipamento.CodEquipamento = result.CodEquipamento;
            //            sucesso = await _oeBll.UpInsertObraEquipamento(obraEquipamento);
            //        }
            //        else
            //            return Results.BadRequest("Equipamento não encontrado no sistema.");
            //    }

            //    return sucesso == true ? Results.Ok("Equipamento cadastrado a obra com sucesso!") : Results.BadRequest("Erro ao cadastra o equipamento cadastrado a obra.");
            //});

            route.MapGet("/GetListMateriais", async (MaterialBLL _mBll) =>
            {
                var materiais = await _mBll.GetListMateriais();
                return materiais != null ? Results.Ok(materiais) : Results.NotFound();
            });

            route.MapPost("/UpInsertPedidoMateriais", async (PedidoMaterial pedidoMaterial, PedidoMaterialBLL _pmBll, ObraBLL _oBll) =>
            {
                var sucesso = false;

                if (pedidoMaterial is null)
                    return Results.BadRequest("Objeto Inválido");

                if (pedidoMaterial is not null)
                {
                    var result = await _pmBll.GetNomeMatrial(pedidoMaterial.Material.Nome);

                    if (result.Nome == pedidoMaterial.Material.Nome)
                    {
                        pedidoMaterial.CodMaterial = result.CodMaterial;

                        var resultMaterial = await _oBll.GetObra(pedidoMaterial.Obra.NomeObra);

                        if(resultMaterial.NomeObra == pedidoMaterial.Obra.NomeObra)
                        {
                            pedidoMaterial.CodObra = resultMaterial.CodObra;
                            sucesso = await _pmBll.UpInsertPedidoMaterial(pedidoMaterial);
                        }
                        else
                            return Results.BadRequest("Obra não encontrada no sistema.");
                    }
                    else
                        return Results.BadRequest("Material não encontrado no sistema.");
                }

                return sucesso == true ? Results.Ok("Pedidos de Materiais cadastrado a obra com sucesso!") : Results.BadRequest("Erro ao solicitar materias.");
            });

            route.MapPost("/InsertPagamento", async (Pagamento pagamento, PagamentoBLL _pBll, FormaPagamentoBLL _fpBll, ObraBLL _oBll) =>
            {
                var sucesso = false;

                if (pagamento is null)
                    return Results.BadRequest("Objeto Inválido");

                if (pagamento is not null)
                {
                    var result = await _fpBll.GetFormaPagamento(pagamento.FormaPagamento.Nome);

                    if (result.Nome == pagamento.FormaPagamento.Nome)
                    {
                        pagamento.CodFormaPagamento = result.CodFormaPagamento;

                        var resultObra = await _oBll.GetObra(pagamento.Obra.NomeObra);

                        if(resultObra.NomeObra == pagamento.Obra.NomeObra)
                        {
                            pagamento.CodObra = resultObra.CodObra;
                            sucesso = await _pBll.InsertPagamento(pagamento);
                        }
                        else
                            return Results.BadRequest("Obra não encontrada no sistema.");
                    }
                    else
                        return Results.BadRequest("Forma de pagamento não encontrado no sistema.");
                }

                return sucesso == true ? Results.Ok("Pagamento realizado com sucesso!") : Results.BadRequest("Erro ao realizar pagamento.");
            });
        }
    }
}
