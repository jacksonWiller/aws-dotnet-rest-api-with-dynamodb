using Amazon.Lambda.APIGatewayEvents;
using Amazon.Lambda.Core;
using Newtonsoft.Json;

namespace DotNetServerless.Lambda.Functions
{
    public class UpdateItemFunction
  {
    private readonly IServiceProvider _serviceProvider;

    public UpdateItemFunction() : this(Startup
      .BuildContainer()
    .BuildServiceProvider())
    {
    }

    public UpdateItemFunction(IServiceProvider serviceProvider)
    {
      _serviceProvider = serviceProvider;
    }

    [LambdaSerializer(typeof(Amazon.Lambda.Serialization.Json.JsonSerializer))]
    public async Task<APIGatewayProxyResponse> Run(APIGatewayProxyRequest request)
    {
      var result = JsonConvert.DeserializeObject(request.Body);

      return new APIGatewayProxyResponse { StatusCode =  200,  Body = JsonConvert.SerializeObject(result)};
    }
  }
}
