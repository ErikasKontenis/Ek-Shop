namespace Ek.Shop.Core.Enums
{
    public static class CacheExpirationModes
    {
        /// <summary>
        /// Default value for the expircation mode enum. CacheManager will default to None.
        /// The Default entry in the enum is used as separation from the other values and
        /// to make it possible to explicitly set the expiration to None.
        /// </summary>
        public static int Default = 0;

        /// <summary>
        /// Defines no expiration.
        /// </summary>
        public static int None = 1;

        /// <summary>
        /// Defines sliding expiration. The expiration timeout will be refreshed on every access.
        /// </summary>
        public static int Sliding = 2;

        /// <summary>
        /// Defines absolute expiration. The item will expire after the expiration timeout.
        /// </summary>
        public static int Absolute = 3;
    }
}
