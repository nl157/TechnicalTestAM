namespace MessageDecode.Services.Interfaces;

public interface IValidator<T> where T : class
{
    IValidator<T> SetNext(IValidator<T> next);
    void Handle(T request);
}
