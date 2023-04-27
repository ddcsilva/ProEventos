using FluentValidation;
using ProEventos.Domain.Models;

namespace ProEventos.Domain.Validations;

public class EventoValidation : AbstractValidator<Evento>
{
    public EventoValidation()
    {
        RuleFor(e => e.Tema)
            .NotEmpty().WithMessage("O campo {PropertyName} é obrigatório.")
            .Length(2, 50).WithMessage("O campo {PropertyName} deve ter entre {MinLength} e {MaxLength} caracteres.");

        RuleFor(e => e.Local)
            .NotEmpty().WithMessage("O campo {PropertyName} é obrigatório.")
            .Length(2, 100).WithMessage("O campo {PropertyName} deve ter entre {MinLength} e {MaxLength} caracteres.");

        RuleFor(e => e.QuantidadePessoas)
            .NotEmpty().WithMessage("O campo {PropertyName} é obrigatório.")
            .GreaterThan(0).WithMessage("O campo {PropertyName} deve ser maior que {ComparisonValue}.");

        RuleFor(e => e.DataEvento)
            .NotEmpty().WithMessage("O campo {PropertyName} é obrigatório.")
            .GreaterThan(DateTime.Now).WithMessage("O campo {PropertyName} deve ser maior que {ComparisonValue}.");

        RuleFor(e => e.ImagemURL)
            .NotEmpty().WithMessage("O campo {PropertyName} é obrigatório.")
            .Matches(@"\.(png|jpg|jpeg)$").WithMessage("O campo {PropertyName} deve ser uma imagem válida.");

        RuleFor(e => e.Telefone)
            .NotEmpty().WithMessage("O campo {PropertyName} é obrigatório.")
            .Matches(@"^\d{4}-\d{4}$").WithMessage("O campo {PropertyName} deve ser um telefone válido.");  

        RuleFor(e => e.Email)
            .NotEmpty().WithMessage("O campo {PropertyName} é obrigatório.")
            .EmailAddress().WithMessage("O campo {PropertyName} deve ser um e-mail válido.");
    }
}