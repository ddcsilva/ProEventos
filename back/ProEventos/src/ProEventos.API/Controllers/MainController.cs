using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using ProEventos.Domain.Helpers;
using ProEventos.Domain.Interfaces.Helpers;

namespace ProEventos.API.Controllers;

/// <summary>
/// Classe abstrata que representa a base de todos os controllers
/// </summary>
[ApiController]
public abstract class MainController : ControllerBase
{
    private readonly INotificador _notificador;

    /// <summary>
    /// Construtor padrão que recebe uma instância de notificador
    /// </summary>
    protected MainController(INotificador notificador)
    {
        _notificador = notificador;
    }

    /// <summary>
    /// Método que verifica se a operação foi válida (se não houver notificações de erro)
    /// </summary>
    /// <returns>Retorna se a operação é válida</returns>
    protected bool OperacaoValida()
    {
        return !_notificador.TemNotificacao();
    }

    /// <summary>
    /// Método que cria uma resposta personalizada com base no resultado da operação
    /// </summary>
    /// <param name="result">Resultado da operação</param>
    /// <returns>Retorna uma resposta personalizada</returns>
    protected ActionResult CustomResponse(object result = null, int? statusCode = null)
    {
        if (OperacaoValida())
        {
            return Ok(new
            {
                success = true,
                data = result
            });
        }

        var errorResponse = new
        {
            success = false,
            errors = _notificador.ObterNotificacoes().Select(n => n.Mensagem)
        };

        if (statusCode.HasValue && statusCode.Value >= 400 && statusCode.Value < 600)
        {
            return StatusCode(statusCode.Value, errorResponse);
        }

        return BadRequest(errorResponse);
    }

    /// <summary>
    /// Método que notifica um erro de modelo inválido
    /// </summary>
    /// <param name="modelState">Estado do modelo</param>
    /// <returns>Retorna uma resposta personalizada</returns>
    protected ActionResult CustomResponse(ModelStateDictionary modelState)
    {
        if (!modelState.IsValid)
        {
            NotificarErroModelInvalida(modelState);
        }

        return CustomResponse();
    }

    /// <summary>
    /// Método que notifica erros no ModelState
    /// </summary>
    /// <param name="mensagem">Mensagem de erro</param>
    protected void NotificarErroModelInvalida(ModelStateDictionary modelState)
    {
        var erros = modelState.Values.SelectMany(e => e.Errors);

        foreach (var erro in erros)
        {
            var errorMsg = erro.Exception == null ? erro.ErrorMessage : erro.Exception.Message;
            NotificarErro(errorMsg);
        }
    }

    /// <summary>
    /// Método que envia uma notificação de erro
    /// </summary>
    /// <param name="mensagem">Retorna uma mensagem de erro</param>
    protected void NotificarErro(string mensagem)
    {
        _notificador.Handle(new Notificacao(mensagem));
    }
}