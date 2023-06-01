using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AcmeInsurance.Claims.Domain.Models
{
    public class Claim
    {
        /// <summary>
        /// Gets or sets the ucr.
        /// </summary>
        /// <value>
        /// The ucr.
        /// </value>
        /// <remarks>No idea what this - assuming it means "Unique Claim Reference" but really would not have a string as the primary key </remarks>
        [Key]
        [Column(TypeName = "varchar(20)")]
        public string UCR { get; set; }

        /// <summary>
        /// Gets or sets the company identifier.
        /// </summary>
        /// <value>
        /// The company identifier.
        /// </value>
        public int CompanyId { get; set; }

        /// <summary>
        /// Gets or sets the claim date.
        /// </summary>
        /// <value>
        /// The claim date.
        /// </value>
        public DateTime ClaimDate { get; set; }

        /// <summary>
        /// Gets or sets the loss date.
        /// </summary>
        /// <value>
        /// The loss date.
        /// </value>
        public DateTime LossDate { get; set; }

        /// <summary>
        /// Gets or sets the name of the assured.
        /// </summary>
        /// <value>
        /// The name of the assured.
        /// </value>
        [Column("Assured Name", TypeName = "varchar(20)")]
        public string AssuredName { get; set; }

        /// <summary>
        /// Gets or sets the incurred loss.
        /// </summary>
        /// <value>
        /// The incurred loss.
        /// </value>
        [Column("Incurred Loss", TypeName = "decimal(15,2)")]
        public decimal IncurredLoss { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="Claim"/> is closed.
        /// </summary>
        /// <value>
        ///   <c>true</c> if closed; otherwise, <c>false</c>.
        /// </value>
        public bool Closed { get; set; }
    }
}
