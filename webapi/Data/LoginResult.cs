namespace GtUndergroundAPI.Data
{
    public class LoginResult
    {
        /// <summary>
        /// TRUE if login attempt is successful, FALSE otherwise.
        /// </summary>
        public bool Success { get; set; }

        /// <summary>
        /// Login attempt result message
        /// </summary>
        public string Message { get; set; } = null!;

        /// <summary>
        /// The JWT token if the login attempt is successful, NULL if it is not
        /// </summary>
        public string? Token { get; set; }

    }
}

