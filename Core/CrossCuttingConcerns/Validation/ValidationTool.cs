using FluentValidation;

namespace Core.CrossCuttingConcerns.Validation;

public static class ValidationTool
{
    public static void Validate(IValidator validator, object entity)
    {
        var context = new ValidationContext<object>(entity);
        var result = validator.Validate(context);

        if (!result.IsValid)
        {
            var errorList = new List<string>();

            result.Errors.ForEach(x =>
            {
                errorList.Add(x.ErrorMessage.ToString());
                Console.WriteLine(x.ErrorMessage.ToString());
            });

            throw new ValidationException(String.Join("",errorList));
        }
    }
}