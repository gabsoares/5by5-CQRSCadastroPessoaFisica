using FluentValidation;

namespace _5by5.CQRS.Domain.Commands.v1.CreatePerson;

public class CreatePersonCommandValidator : AbstractValidator<CreatePersonCommand>
{
    public CreatePersonCommandValidator()
    {
        RuleFor(create => create.Name)
            .Cascade(CascadeMode.Stop)
            .NotEmpty().WithMessage("O campo {PropertyName} é obrigatório!!!")
            .MinimumLength(5).WithMessage("O campo {PropertyName} deve ter mais que 5 caracteres!!!");

        RuleFor(person => person.Document)
            .Cascade(CascadeMode.Stop)
            .NotEmpty().WithMessage("O campo { PropertyName} é obrigatório!!!")
            .Must(IsValidDocument).WithMessage("O CPF informado não é válido!!!");

        RuleFor(person => person.Birthday)
            .Cascade(CascadeMode.Stop)
            .NotEmpty().WithMessage("O campo {PropertyName} é obrigatório!!!")
            .Must(person => DateTime.Now.Year - person.Year >= 18).WithMessage("Idade deve ser maior que 18 anos");

        RuleFor(person => person.Email)
            .Cascade(CascadeMode.Stop)
            .NotEmpty().WithMessage("O campo {PropertyName} é obrigatório!!!")
            .EmailAddress().WithMessage("O e-mail não é válido!!!");
    }

    public static bool IsValidDocument(string document)
    {
        document = document.Replace(".", "").Replace("-", "");

        if (document.Length != 11)
            return false;

        bool AreAllDigitsSame = document.Distinct().Count() == 1;

        if (AreAllDigitsSame)
            return false;

        int[] documentDigits = new int[11];

        for (int i = 0; i < 11; i++)
        {
            documentDigits[i] = int.Parse(document[i].ToString());
        }

        int sum = 0;

        for (int i = 0; i < 9; i++)
        {
            sum += documentDigits[i] * (10 - i);
        }

        int firstDigit = 11 - (sum % 11);

        if (firstDigit >= 10)
        {
            firstDigit = 0;
        }

        sum = 0;

        for (int i = 0; i < 10; i++)
        {
            sum += documentDigits[i] * (11 - i);
        }

        int secondDigit = 11 - (sum % 11);
        if (secondDigit >= 10)
        {
            secondDigit = 0;
        }

        return documentDigits[9] == firstDigit && documentDigits[10] == secondDigit;
    }
}