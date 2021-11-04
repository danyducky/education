using System;

namespace Auth.Api.Models.Shared
{
    public class UserModel
    {
        public UserModel(Guid id, string email, string firstname, string surname, string patronymic, DateTime birthDate)
        {
            Id = id;
            Email = email;
            Firstname = firstname;
            Surname = surname;
            Patronymic = patronymic;
            BirthDate = birthDate;
        }

        public Guid Id { get; }
        public string Email { get; }
        public string Firstname { get; }
        public string Surname { get; }
        public string Patronymic { get; }
        public DateTime BirthDate { get; }
    }
}
