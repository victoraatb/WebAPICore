namespace App.Repository.ApiClient;

public interface IWebApiExecuter
{
    Task<T> InvokeGet<T>(string uri);
    Task<T> InvokePost<T>(string uri, T obj);
    Task InvokePut<T>(string uri, T obj);
    Task InvokeDelete(string uri);
    Task<string> InvokePostReturnString<T>(string uri, T obj);
}