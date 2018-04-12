﻿using System.Security;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace Qlik.Sense.RestClient
{
    public interface IRestClient
    {
        void AsDirectConnection(int port = 4242, bool certificateValidation = true, X509Certificate2Collection certificateCollection = null);
        void AsDirectConnection(string userDirectory, string userId, int port = 4242, bool certificateValidation = true, X509Certificate2Collection certificateCollection = null);
        void AsNtlmUserViaProxy(bool certificateValidation = true);
        void LoadCertificateFromDirectory(string path, SecureString certificatePassword = null);
        string Get(string endpoint);
        Task<string> GetAsync(string endpoint);
        string Post(string endpoint, string body);
        Task<string> PostAsync(string endpoint, string body);
        byte[] Post(string endpoint, byte[] body);
        void UploadApp(string appName, byte[] app);
        string Delete(string endpoint);
        Task<string> DeleteAsync(string endpoint);
    }
}