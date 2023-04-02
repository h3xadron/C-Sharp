using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace INNZ0S_HFT_2022231.Models.Entities
{
    [Table("Clients")]
    public class Client
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [MaxLength(747)] 
        public string Name { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        [MaxLength(747)]
        public string MotherName { get; set; }
        [Required]
        public string State { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public DateTime BirthDate { get; set; }
        public long MobilNumber { get; set; }
        [JsonIgnore]
        public virtual IEnumerable<Account> Accounts { get; set; }

        public Client()
        {

        }

        public Client(int id, string name, string motherName, string state, string city, string address, DateTime birthDate, long mobilNumber)
        {
            Id = id;
            Name = name;
            MotherName = motherName;
            State = state;
            City = city;
            Address = address;
            BirthDate = birthDate;
            MobilNumber = mobilNumber;
        }
        public override string ToString()
        {
            return $"Id: {Id}; Name: {Name}; Address: {Address}; MotherName: {MotherName}; State: {State}; City: {City}; BirthDate: {BirthDate.ToString()}; MobilNumber: {MobilNumber};";
        }
    }
}
