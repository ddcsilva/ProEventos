namespace ProEventos.Domain.Helpers;

/// <summary>
/// Classe que representa uma notificação de erro.
/// </summary>
public class Notificacao
{
    /// <summary>
    /// Construtor padrão, inicializa a propriedade Mensagem com a mensagem da notificação.
    /// </summary>
    /// <param name="mensagem">Mensagem da notificação.</param>
    public Notificacao(string mensagem)
    {
        Mensagem = mensagem;
    }

    // Propriedade somente leitura que armazena a mensagem da notificação.
    public string Mensagem { get; }
}