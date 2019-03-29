namespace Practice.Common
{
    /// <summary>
    ///     Скрытая реализация представления об имени человека.
    /// </summary>
    public struct Name : IName
    {
        /*
         * TODO #1: Реализуйте интерфейс IName для структуры Name
         */
        /// <summary>
        ///     Полная форма имени.
        /// </summary>
        public string FullName { get; }
        /// <summary>
        ///     Короткая форма имени.
        /// </summary>
        public string ShortName { get; }

        /// <summary>
        ///     Имя.
        /// </summary>
        public string FirstName { get; }

        /// <summary>
        ///     Фамилия.
        /// </summary>
        public string Surname { get; }

        /// <summary>
        ///     Отчество.
        /// </summary>
        public string Patronymic { get; }

        public Name(IName name)
        {
            FullName = name.FullName;
            ShortName = name.ShortName;
            
            int SurnameLength = FullName.IndexOf(' ');
            int FirstnameLength = FullName.Substring(SurnameLength + 1).IndexOf(' ');
            
            
            Surname = FullName.Substring(0, SurnameLength + 1);
            FirstName = FullName.Substring(SurnameLength + 1, FirstnameLength);
            Patronymic = FullName.Substring(FirstnameLength + 1);
        }

        public Name(string surname, string firstname, string patronymic)
        {
            Surname = surname;
            FirstName = firstname;
            Patronymic = patronymic;
            FullName = surname + ' ' + firstname + ' ' + patronymic;
            ShortName = surname + ' ' + firstname[0] + ". " + patronymic[0] + '.';
        }



    }
}