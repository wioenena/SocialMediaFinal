namespace SocialMediaFinal.Backend.Application.Interfaces.Services;

public interface IJWTService {
    public string GenerateAccessToken(string accountId);
}
