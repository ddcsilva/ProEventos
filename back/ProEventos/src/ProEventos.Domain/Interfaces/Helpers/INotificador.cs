using ProEventos.Domain.Helpers;

namespace ProEventos.Domain.Interfaces.Helpers;

/// <summary>
/// Interface que representa o notificador de erros
/// </summary>
public interface INotificador
{
    /// <summary>
    /// Verifica se existe alguma notificação de erro
    /// </summary>
    /// <returns>Retorna verdadeiro se existir alguma notificação de erro</returns>
    bool TemNotificacao();

    /// <summary>
    /// Obtém a lista de notificações de erro
    /// </summary>
    /// <returns>Retorna a lista de notificações de erro</returns>
    List<Notificacao> ObterNotificacoes();

    /// <summary>
    /// Adiciona uma notificação de erro
    /// </summary>
    /// <param name="notificacao">Notificação de erro</param>
    void Handle(Notificacao notificacao);
}