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
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string ID { get; set; }
        [Display(Name = "Ad")]
        [Required(ErrorMessage = "Ad Alanı zorunludur")]
        public string Name { get; set; }
        [Display(Name = "Soyad")]
        public string Surname { get; set; }
        [Display(Name = "Adres")]
        public string Adress { get; set; }
        [EmailAddress]
        [Display(Name = "E-Mail")]
        [Required(ErrorMessage = "Mail Alanı zorunludur")]
        public string Mail { get; set; }
        [MinLength(11, ErrorMessage = "Telefon Numarası 11 hane olmalıdır"),MaxLength(11, ErrorMessage = "Telefon Numarası 11 hane olmalıdır")]
        [Display(Name = "Telefon Numarası")]
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }
    }
}
