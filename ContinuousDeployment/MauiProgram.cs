using Microsoft.Extensions.Logging;

namespace ContinuousDeployment
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}



/* GithubActions: Deploy+AutoUpdate
 *  Create
 *      .github/workflows/deploy.yml
 *  Generate Cert
 *      New-SelfSignedCertificate -Type Custom -Subject "CN=Dev-Shaggy" -KeyUsage DigitalSignature -FriendlyName "Continous Deployment Demo" -CertStoreLocation "Cert:\CurrentUser\My" -TextExtension @("2.5.29.37={text}1.3.6.1.5.5.7.3.3", "2.5.29.19={text}")
 *  Export Cert
 *      Copy generated Thumbprint
 *      $password = ConvertTo-SecureString -String P@s$w0rD -Force -AsPlainText
 *      Export-PfxCertificate -cert Cert:\CurrentUser\My\7E29BBF2362476562C65027BC00C5D40E58C54AF -FilePath cert.pfx -Password $password
 *  Convert to ascii
 *      certutil -encode ./cert.pfx ./cert.asc
 *  Create Github Secrets
 *      Github->Project->Settings->Secrets and variales->Actions
 *          - cert ASCII
 *          - cert Password
 *          - cert thumbprint
 *  Publish      
 *          
 */
        