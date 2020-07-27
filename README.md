# Ecrypted Configuration Provider in ASP.NET Core

## This idea was derived from this article here [Medium Article](https://codeburst.io/create-a-custom-configuration-provider-in-asp-net-core-cdd6a32b8ecb)


## Usage 

- Install nugget


 Nuget install Iotec.EncryptedConfiguration


- Usage

  Add the following line to confuguration builder

  public static IHostBuilder CreateHostBuilder(string[] args) =>
        
                .ConfigureAppConfiguration((builderContext, config) =>
                {
                    // config.AddJsonFile("appsettings.json");
                    // Other config builders

                    config.AddEncryptedJson("enc.txt","secret");

                });
