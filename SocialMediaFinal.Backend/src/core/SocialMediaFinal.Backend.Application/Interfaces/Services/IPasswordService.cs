namespace SocialMediaFinal.Backend.Application.Interfaces.Services;

public interface IPasswordService {
    public string Hash(string password);
    public bool Validate(string password, string hashedPassword);
}
