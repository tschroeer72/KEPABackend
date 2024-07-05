using FluentValidation;
using KEPABackend.DTOs;

namespace KEPABackend.Validations;

public class MitgliederCreateValidator :AbstractValidator<MitgliedCreate>
{
    public MitgliederCreateValidator()
    {
        RuleFor(mitglied => mitglied.Anrede).MaximumLength(50);
        RuleFor(mitglied => mitglied.Vorname).NotEmpty().MaximumLength(50);
        RuleFor(mitglied => mitglied.Nachname).NotEmpty().MaximumLength(50);
        RuleFor(mitglied => mitglied.Spitzname).MaximumLength(50);
        RuleFor(mitglied => mitglied.Straße).MaximumLength(50);
        RuleFor(mitglied => mitglied.Ort).MaximumLength(50);
        RuleFor(mitglied => mitglied.PLZ).MinimumLength(5).MaximumLength(5);
        RuleFor(mitglied => mitglied.Email).MaximumLength(100).EmailAddress();
        RuleFor(mitglied => mitglied.Fax).MaximumLength(50);
        RuleFor(mitglied => mitglied.TelefonFirma).MaximumLength(50);
        RuleFor(mitglied => mitglied.TelefonMobil).MaximumLength(50);
        RuleFor(mitglied => mitglied.TelefonPrivat).MaximumLength(50);
        RuleFor(mitglied => mitglied.Platz).MaximumLength(255);
        RuleFor(mitglied => mitglied.Punkte).GreaterThanOrEqualTo(0);
        RuleFor(mitglied => mitglied.SpAnz).GreaterThanOrEqualTo(0);
        RuleFor(mitglied => mitglied.SpGew).GreaterThanOrEqualTo(0);
        RuleFor(mitglied => mitglied.SpUn).GreaterThanOrEqualTo(0);
        RuleFor(mitglied => mitglied.SpVerl).GreaterThanOrEqualTo(0);
        RuleFor(mitglied => mitglied.HolzGes).GreaterThanOrEqualTo(0);
        RuleFor(mitglied => mitglied.HolzMax).GreaterThanOrEqualTo(0);
        RuleFor(mitglied => mitglied.HolzMin).GreaterThanOrEqualTo(0);

        RuleFor(mitglied => mitglied.Geburtsdatum).LessThan(lt => lt.MitgliedSeit);
        RuleFor(mitglied => mitglied.MitgliedSeit).NotNull().LessThanOrEqualTo(DateTime.Now);
        RuleFor(mitglied => mitglied.PassivSeit).GreaterThan(gt => gt.MitgliedSeit).GreaterThan(gt => gt.Geburtsdatum);
        RuleFor(mitglied => mitglied.AusgeschiedenAm).GreaterThan(gt => gt.MitgliedSeit).GreaterThan(gt => gt.Geburtsdatum);
    }
}
