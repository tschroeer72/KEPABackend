using FluentValidation;
using KEPABackend.DTOs;

namespace KEPABackend.Validations;

public class MitgliederCreateValidator :AbstractValidator<MitgliedCreate>
{
    public MitgliederCreateValidator()
    {
        RuleFor(mitglied => mitglied.Vorname).NotEmpty().MaximumLength(50);
        RuleFor(mitglied => mitglied.Nachname).NotEmpty().MaximumLength(50);
        RuleFor(mitglied => mitglied.Anrede).MaximumLength(50);
        RuleFor(mitglied => mitglied.MitgliedSeit).NotNull().LessThanOrEqualTo(DateTime.Now);
    }
}
