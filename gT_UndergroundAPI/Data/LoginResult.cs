﻿
namespace gT_UndergroundAPI.Data
{
    public class LoginResult
    {
        /// <summary>
        /// TRUE if the Login attempt is successful, FALSE otherwise.
        /// </summary>
        public bool Success { get; set; }

        /// <summary>
        /// Login attempt result message.
        /// </summary>
        public string Message { get; set; } = null!;

        /// <summary>
        /// The JWT token if the Login attempt is successful, or NULL if not.
        /// </summary>
        public string? Token { get; set; }
    }
}
