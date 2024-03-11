using MessageDecode.Validations.Interfaces;

namespace MessageDecode.Validations.Validators;

public abstract class Validator<T> : IValidator<T> where T : class
{
    private IValidator<T>? NextValidator { get; set; }
    public virtual void Validate(T request)
    {
        NextValidator?.Validate(request);
    }

    public IValidator<T> SetNext(IValidator<T> nextValidator)
    {
        NextValidator = nextValidator;

        return NextValidator;
    }

}
