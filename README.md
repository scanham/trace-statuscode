# trace-statuscode

This .NET Core Web API application demonstrates error handling and reporting via dd-trace-dotnet 1.2.0

## Usage

Clone the respository and set the `DD_API_KEY` environment variable on the `datadog` container. Start the agent and application with the following command:

```
docker-compose up --build src
```

Once both containers have started trigger error handling traces with the following commands:

```
#for handling via middleware
curl -i http://localhost:8080/api/values/error-middleware/503

#for handling via filter
curl -i http://localhost:8080/api/values/error-filter/503
```