namespace Symbio.Base.Model.Entities
{
    #region Enumerations

    public enum ImportBehavior
    {
        CreateOrUpdate,

        Update,

        /// <summary>
        /// The only existing
        /// </summary>
        OnlyExisting,

        /// <summary>
        /// The overwrite
        /// </summary>
        Overwrite,

        /// <summary>
        /// The create new version
        /// </summary>
        CreateNewVersion
    }

    #endregion Enumerations
}