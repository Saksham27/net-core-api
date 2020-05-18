namespace CommonLayer.Model
{
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    public class UpdateModel
    {
        /// <summary>
        /// Gets or sets Employee Id
        /// </summary>
        [Required(ErrorMessage = "EmployeeId Is Required")]
        public int EmployeeId { get; set; }

        /// <summary>
        /// Gets or sets FirstName
        /// </summary>   
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets LastName
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets Email
        /// </summary>
        [EmailAddress]
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets UserName
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// Gets or sets Password
        /// </summary>
        [PasswordPropertyText]
        public string Password { get; set; }

        /// <summary>
        /// Gets or sets City
        /// </summary>
        public string City { get; set; }
    }
}
