namespace MessageDecode.Validations.Interfaces;

public interface IValidator<T> where T : class
{
    IValidator<T> SetNext(IValidator<T> next);
    void Validate(T request);
}
