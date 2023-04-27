using FluentValidation;
using FluentValidation.Results;
using ProEventos.Domain.Helpers;
using ProEventos.Domain.Interfaces.Helpers;
using ProEventos.Domain.Models;

namespace ProEventos.Application.Services;

/// <summary>
/// Classe base para os serviços
/// </summary>
public abstract class BaseService
{
    private readonly INotificador _notificador;

    /// <summary>
    /// Construtor padrão que recebe o notificador de erros
    /// </summary>
    protected BaseService(INotificador notificador)
    {
        _notificador = notificador;
    }

    /// <summary>
    /// Método para notificar uma lista de erros
    /// </summary>
    /// <param name="validationResult">Lista de erros</param>
    protected void Notificar(ValidationResult validationResult)
    {
        foreach (var error in validationResult.Errors)
        {
            Notificar(error.ErrorMessage);
        }
    }

    /// <summary>
    /// Método para notificar uma mensagem de erro
    /// </summary>
    /// <param name="mensagem">Mensagem de erro</param>
    protected void Notificar(string mensagem)
    {
        _notificador.Handle(new Notificacao(mensagem));
    }

    /// <summary>
    /// Método para validar uma entidade
    /// </summary>
    /// <typeparam name="TV">Tipo da validação</typeparam>
    /// <typeparam name="TE">Tipo da entidade</typeparam>
    /// <param name="validacao">Validação</param>
    /// <param name="entidade">Entidade</param>
    /// <returns>Retorna se a validação é válida</returns>
    protected bool ExecutarValidacao<TV, TE>(TV validacao, TE entidade) where TV : AbstractValidator<TE> where TE : BaseEntity
    {
        var validator = validacao.Validate(entidade);

        if (validator.IsValid) return true;

        Notificar(validator);

        return false;
    }
}