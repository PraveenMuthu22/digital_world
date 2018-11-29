using System;
using System.IdentityModel.Tokens;
using Autofac.Integration.WebApi;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Web.Http;
using Autofac;
using Microsoft.Owin;
using Microsoft.Owin.Security.Jwt;
using Owin;


[assembly: OwinStartup(typeof(WebApiProject.App_Start.Startup))]
namespace WebApiProject.App_Start
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var config = GlobalConfiguration.Configuration;

            var builder = new ContainerBuilder();
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
           // builder.RegisterModule<>();

            var container = builder.Build();

            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);

            var certificate = new X509Certificate2(Convert.FromBase64String(
                "MIIEBzCCAu+gAwIBAgIUbsqIEC+d1fRNE7vvC/INaqJ/9YcwDQYJKoZIhvcNAQELBQAwgZIxCzAJBgNVBAYTAlNMMRAwDgYDVQQIDAdDb2xvbWJvMRAwDgYDVQQHDAdDb2xvbWJvMREwDwYDVQQKDAhQZXJzb25hbDERMA8GA1UECwwIUGVyc29uYWwxEDAOBgNVBAMMB1ByYXZlZW4xJzAlBgkqhkiG9w0BCQEWGHByYXZlZW5tdXRodTIyQGdtYWlsLmNvbTAeFw0xODExMjgwNDM0MjFaFw0xOTExMjgwNDM0MjFaMIGSMQswCQYDVQQGEwJTTDEQMA4GA1UECAwHQ29sb21ibzEQMA4GA1UEBwwHQ29sb21ibzERMA8GA1UECgwIUGVyc29uYWwxETAPBgNVBAsMCFBlcnNvbmFsMRAwDgYDVQQDDAdQcmF2ZWVuMScwJQYJKoZIhvcNAQkBFhhwcmF2ZWVubXV0aHUyMkBnbWFpbC5jb20wggEiMA0GCSqGSIb3DQEBAQUAA4IBDwAwggEKAoIBAQDCs2EXJoP6Zyh+nGQgupTZwp2r13zre1SjWMpL+71TY26e/Ijm7Cm+RnqJC+MqWs5WG9imnfZPEB5eYsor9W+Gb3UHLaoZJ+NlehF/ZZHSTZdqw7xNza+y1MC9c97YP4MIvk4mvfB/1u4bljVpmbZupYix7SRVK5WpDKanD06230zsHr4l63iBjHiLjwbC7IgewIAyDmBdDWrBk1lce7Gz5FVeBvRFaUxelk9Eh9m9Ga+PR2ugs6b3zJ1RtkhPx47NfkVUASRtEDTYk/8O7PYBx3Qet6pyEvzkC5fX2FbL61HD+Nl3etRM0j/r/6buBPbIRjOrfUrjmy82Ld+v3OnvAgMBAAGjUzBRMB0GA1UdDgQWBBRN53UVEmRgQhRASlk6h6ZF9u60qzAfBgNVHSMEGDAWgBRN53UVEmRgQhRASlk6h6ZF9u60qzAPBgNVHRMBAf8EBTADAQH/MA0GCSqGSIb3DQEBCwUAA4IBAQBljmKolLxWxMUfea5DHtUW8OwWZjMQ1VI8t6ZKs0ZHUvGKwyte6GPXJTEXIDzDJwIF5jMFNJTbwtqMv50ZY8NdqhD/ArpGgwP381LwJPQASLnR/XT2H3ctOy27WxfpESIwV6Gakjlm6Gr15fGPADNuMIKCA6tSpxtfJBT8NAz7VumQ5kY4IDacGqdqhfnElClLf5DXedqQTCmaBBikIucACKPjam7BZG+4cs66oKkl6RoJCMnwgN3zltq+V8to2u2sPnxIifb8e/p/Syzzr/+OCyF19YYim+lgIznd3+GnN/wGnw4NWtwhpq5EUB3lVEwmnAlRe5SPothlJZomflQH"));

            app.UseJwtBearerAuthentication(new JwtBearerAuthenticationOptions
            {
                AllowedAudiences = new[] { "http://localhost:56511/resources" },
                TokenValidationParameters = new TokenValidationParameters
                {
                    //This is authentication server
                    ValidIssuer = "http://localhost:56511",
                    ValidAudience = "http://localhost:56511/resources",
                    //This is public key retrieved from authorization server
                    IssuerSigningKey = new X509SecurityKey(certificate),
                }
            });

            app.UseWebApi(config);
        }
    }
}
