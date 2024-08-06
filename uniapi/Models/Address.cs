using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace uniapi.Models
{
    [Index(nameof(UniversityId))]
    public class Address
    {
        public int Id { get; set; }

        [Required]
        public required string Street { get; set; }

        [Required]
        public required string City { get; set; }

        [Required]
        public required string Province { get; set; }

        [Required]
        public required int PostalCode { get; set; }

        [Required, DefaultValue("South Africa")]
        public required string Country { get; set; }

        [MaxLength(12), MinLength(10), RegularExpression("^(\\+27|0)([1-2][0-9]{8}|[6-8][0-9]{8})$\r\n")]
        public required string Phone { get; set; }
        public required int UniversityId { get; set; }
        public required University University { get; set; }

    }
}

