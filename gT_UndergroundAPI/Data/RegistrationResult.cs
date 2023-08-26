namespace gT_UndergroundAPI.Data
{
    public class RegistrationResult
    {
        /// <summary>
        /// TRUE if the Registration attempt is successful, FALSE otherwise.
        /// </summary>
        public bool Success { get; set; }

        /// <summary>
        /// Registration attempt result message.
        /// </summary>
        public string Message { get; set; } = null!;

        public IEnumerable<string>? Errors { get; set; }
    }
}
