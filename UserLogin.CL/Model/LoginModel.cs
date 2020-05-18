//-----------------------------------------------------------------------
// <copyright file="LoginModel.cs" company="BridgeLabz Solutions LLP">
//     Copyright (c) Company. All rights reserved.
// </copyright>
// <author> Saksham Singh </author>
//-----------------------------------------------------------------------
#region namespace CommonLayer.Model
namespace CommonLayer.Model
{
    using System.ComponentModel.DataAnnotations;

    #region LoginModel
    /// <summary>
    /// POCO class for Login
    /// </summary>
    public class LoginModel
    {
        /// <summary>
        /// Gets or sets UserName
        /// </summary>
        [Required(ErrorMessage = "Username is required")]
        public string UserName { get; set; }

        /// <summary>
        /// Gets or sets Password
        /// </summary>
        [Required(ErrorMessage = "Password Is Required")]
        public string Password { get; set; }
    }
    #endregion
}
#endregion