namespace MultiApi.Infrastructure
{
    /// <summary>
    /// This class represents the result of a service call without expecting data in the response.
    /// </summary>
    public class ServiceResponse
    {
        protected ServiceResponse(bool isSuccess, string errorMessage)
        {
            IsSuccess = isSuccess;
            ErrorMessage = errorMessage;
        }

        /// <summary>
        /// Creates a success response.
        /// </summary>
        /// <returns>A new instance of the successful response.</returns>
        public static ServiceResponse BuildSuccess() => new ServiceResponse(true, null);

        /// <summary>
        /// Creates a failure response.
        /// </summary>
        /// <param name="errorMessage">Error message.</param>
        /// <returns>A new instance of the unsuccessful response.</returns>
        public static ServiceResponse BuildFailure(string errorMessage) => new ServiceResponse(false, errorMessage);

        /// <summary>
        /// Gets a value indicating if the call was successful.
        /// </summary>
        public bool IsSuccess { get; }

        /// <summary>
        /// Gets an error message if the call was unsuccessful.
        /// </summary>
        /// <remarks>
        /// If the call was successful, this property will be <code>null</code>.
        /// </remarks>
        public string ErrorMessage { get; }
    }

    /// <summary>
    /// This class represents the result of a service call with data in the response.
    /// </summary>
    /// <typeparam name="TResponse">Returned value type.</typeparam>
    public class ServiceResponse<TResponse> : ServiceResponse
    {
        protected ServiceResponse(bool isSuccess, string errorMessage, TResponse data = default(TResponse))
            : base(isSuccess, errorMessage)
        {
            Data = data;
        }

        /// <summary>
        /// Creates a success response.
        /// </summary>
        /// <param name="data">Data returned by the service.</param>
        /// <returns>A new instance of the successful response with the returned data.</returns>
        public static ServiceResponse<TResponse> BuildSuccess(TResponse data) => new ServiceResponse<TResponse>(true, null, data);

        /// <summary>
        /// Data returned by the service.
        /// </summary>
        public TResponse Data { get; }
    }
}
