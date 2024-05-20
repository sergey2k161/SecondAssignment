namespace SecondAssignment.UniqueUserName;
using System.ComponentModel.DataAnnotations;
using SecondAssignment.Servise;

public class UniqueUserName : ValidationAttribute
{
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        var userService = (IUserService)validationContext.GetService(typeof(IUserService));
        var userName = value as string;

        if (userService == null || userName == null)
        {
            return new ValidationResult("Не удалось проверить уникальность имени пользователя");
        }

        bool isUnique = userService.IsUserNameUnique(userName);

        if (!isUnique)
        {
            return new ValidationResult("Имя пользователя уже существует");
        }

        return ValidationResult.Success;
    }
}
