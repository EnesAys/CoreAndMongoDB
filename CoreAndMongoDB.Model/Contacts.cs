using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CoreAndMongoDB.Model
{
    public class Contact
    {
        /// <summary>
        ///Contact ID- Mongo Db BSonId(Primary Key)
        /// </summary>
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string ID { get; set; }
        /// <summary>
        ///Contact Name 
        /// </summary>
        [Display(Name = "Ad")]
        [Required(ErrorMessage = "Ad Alanı zorunludur")]
        public string Name { get; set; }
        /// <summary>
        ///Contact Surname 
        /// </summary>
        [Display(Name = "Soyad")]
        public string Surname { get; set; }
        /// <summary>
        ///Contact Adress 
        /// </summary>
        [Display(Name = "Adres")]
        public string Adress { get; set; }
        /// <summary>
        ///Contact Mail 
        /// </summary>
        [EmailAddress]
        [Display(Name = "E-Mail")]
        [Required(ErrorMessage = "Mail Alanı zorunludur")]
        public string Mail { get; set; }
        /// <summary>
        ///Contact Phone 
        /// </summary>
        [MinLength(11, ErrorMessage = "Telefon Numarası 11 hane olmalıdır"),MaxLength(11, ErrorMessage = "Telefon Numarası 11 hane olmalıdır")]
        [Display(Name = "Telefon Numarası")]
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }
    }
}
