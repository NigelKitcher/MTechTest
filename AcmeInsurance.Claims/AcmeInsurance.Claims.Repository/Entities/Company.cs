using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AcmeInsurance.Claims.Repository.Entities
{
    public class Company
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        [Column(TypeName = "varchar(200)")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the address1.
        /// </summary>
        /// <value>
        /// The address1.
        /// </value>
        [Column(TypeName = "varchar(100)")]
        public string Address1 { get; set; }

        /// <summary>
        /// Gets or sets the address2.
        /// </summary>
        /// <value>
        /// The address2.
        /// </value>
        [Column(TypeName = "varchar(100)")]
        public string Address2 { get; set; }

        /// <summary>
        /// Gets or sets the address3.
        /// </summary>
        /// <value>
        /// The address3.
        /// </value>
        [Column(TypeName = "varchar(100)")]
        public string Address3 { get; set; }

        /// <summary>
        /// Gets or sets the postcode.
        /// </summary>
        /// <value>
        /// The postcode.
        /// </value>
        [Column(TypeName = "varchar(20)")]
        public string Postcode { get; set; }

        /// <summary>
        /// Gets or sets the country.
        /// </summary>
        /// <value>
        /// The country.
        /// </value>
        [Column(TypeName = "varchar(50)")]
        public string Country { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="Company"/> is active.
        /// </summary>
        /// <value>
        ///   <c>true</c> if active; otherwise, <c>false</c>.
        /// </value>
        public bool Active { get; set; }

        /// <summary>
        /// Gets or sets the insurance end date.
        /// </summary>
        /// <value>
        /// The insurance end date.
        /// </value>
        public DateTime InsuranceEndDate { get; set; }
    }
}
