using System;
using System.Threading.Tasks;
using Amazon.DynamoDBv2;
using Amazon.Lambda.Core;
using Amazon.Runtime;
using Microsoft.Extensions.DependencyInjection;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]

namespace UsersApi
{
    public class Function
    {
        #region Fields

        private string _tableName = "";
        private string _awsAccessKey = "";
        private string _awsSecretKey = "";
        private IAmazonDynamoDB _dynamoDb;
        private IServiceProvider _serviceProvider;

        #endregion

        #region Constructors

        public Function()
        {
            ConfigureServices();
        }

        #endregion

        #region LambdaFunction

        /// <summary>
        /// This lambda function takes an users email address, date of birth and userId
        /// and stores the data into a dynamoDb database table.
        /// </summary>
        /// <param name="input">The lambda function input. Format: {{"user_id": userId, "email": email, "date_of_birth": date} </param>
        /// <param name="context"></param>
        /// <returns></returns>
        public async Task<LambdaResponse> FunctionHandler(LambdaInput input, ILambdaContext context)
        {
            return new LambdaResponse();
        }

        #endregion

        #region Helper Functions

        private void ConfigureServices()
        {
            var credentials = new BasicAWSCredentials(_awsAccessKey, _awsSecretKey);
            var config = new AmazonDynamoDBConfig()
            {
                RegionEndpoint = Amazon.RegionEndpoint.USEast1
            };

            var client = new AmazonDynamoDBClient(credentials, config);
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddSingleton<IAmazonDynamoDB>(client);
            _serviceProvider = serviceCollection.BuildServiceProvider();
        }
        
        #endregion
    }
}


