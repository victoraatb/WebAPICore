﻿namespace MyApp.ApplicationLogic;

public interface IAuthenticationUseCases
{
    Task<string> LoginAsync(string userName, string password);
    Task<string> GetUserInfoAsync(string token);
    Task Logout();
}