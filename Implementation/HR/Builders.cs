using Practice.HR.Events;
using Practice.Common;
using Practice.Organization;
using System;

namespace Practice.HR
{
    /// <summary>
    ///     Класс-фабрика, позволяющий получать экземпляры типов,
    ///     инкапсулированных на уровне библиотеки.
    /// </summary>
    public static class Builders
    {
        /// <summary>
        ///     Возвращает экземпляр "Строителя" клиентов.
        /// </summary>
        /// <returns>
        ///     Экземпляр типа IClientBuilder.
        /// </returns>
        public static IClientBuilder ClientBuilder()
        {
            /*
             * TODO #6: Реализовать фабричный метод ClientBuilder класса Builders
             */
            return new ClientBuilderClass();
        }

        private class ClientBuilderClass : IClientBuilder
        {
            private IClient client = new Client();
            
            public IClient Build()
            {
                return client;
            }
            
            public IClientBuilder Name(IName name)
            {
                client.Name = new Name(name);
                client.NameChange += onNameChange;
                return this;
            }

            public IClientBuilder Name(string name, string surname, string patronymic)
            {
                client.Name = new Name(name, surname, patronymic);
                client.NameChange += onNameChange;
                return this;
            }

            public IClientBuilder Discount(float discount)
            {
                client.Discount = discount;
                return this;
            }

            private void onNameChange(object sender, ValueChangeEventArgs<IName> args)
            {
                Console.WriteLine("Клиент {0} изменил имя на {1}", args.OldValue.FullName, client.Name.FullName);
            }
         
        }

        /// <summary>
        ///     Возвращает экземпляр "Строителя" сотудников.
        /// </summary>
        /// <returns>
        ///     Возвращает экземпляр типа IEmployeeBuilder.
        /// </returns>
        public static IEmployeeBuilder EmployeeBuilder()
        {
            /*
             * TODO #7: Реализовать фабричный метод EmployeeBuilder класса Builders
             */
            return new EmployeeBuilderClass();
        }

        private class EmployeeBuilderClass : IEmployeeBuilder
        {
            private IEmployee employee = new Employee();
            
            public IEmployee Build()
            {
                return employee;
            }

            public IEmployeeBuilder Name(IName name)
            {
                employee.Name = new Name(name);
                employee.NameChange += onNameChange;
                return this;
            }

            public IEmployeeBuilder Name(string surname, string firstname, string patronymic)
            {
                employee.Name = new Name(surname, firstname, patronymic);
                employee.NameChange += onNameChange;
                return this;
            }

            public IEmployeeBuilder Department(IDepartment department)
            {
                employee.Department = new Department(department);
                return this;
            }

            public IEmployeeBuilder Department(string department)
            {
                employee.Department = new Department(department);
                employee.DepartmentChange += onDepartmentChange;
                return this;
            }

            private void onNameChange(object sender, ValueChangeEventArgs<IName> args)
            {
                Console.WriteLine("Сотрудник {0} изменил имя на {1}", args.OldValue.FullName, employee.Name.FullName);
            }

            private void onDepartmentChange(object sender, ValueChangeEventArgs<IDepartment> args)
            {
                Console.WriteLine("Сотрудник {0} был переведен из отдела '{1}' в отдел '{2}'", employee.Name.ShortName, args.OldValue.Name, employee.Department.Name);
            }

        }

    }
}