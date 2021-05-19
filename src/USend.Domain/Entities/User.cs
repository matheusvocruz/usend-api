using System;

namespace USend.Domain.Entities
{
    public class User : BaseEntity
    {
        protected User()
        {
        }

        public User(
            string email,
            string name,
            string password,
            DateTime birthDate,
            string cpf,
            string phone
        )
        {
            Email = email;
            Name = name;
            Password = password;
            BirthDate = birthDate;
            Cpf = cpf;
            Phone = phone;
            Active = true;
        }

        public string Email { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public DateTime BirthDate { get; set; }
        public string Cpf { get; set; }
        public string Phone { get; set; }
        public bool Active { get; set; }

        public void Update(
            string email,
            string name,
            string password,
            DateTime birthDate,
            string cpf,
            string phone
        )
        {
            Email = email;
            Name = name;
            Password = password;
            BirthDate = birthDate;
            Cpf = cpf;
            Phone = phone;
        }

        public void ActiveUser(bool active)
        {
            Active = active;
        }
    }
}
