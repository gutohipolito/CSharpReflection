using System;
using HumanResource;
using System.ComponentModel.DataAnnotations;

// #2 Referência | Reference
using System.Reflection;


namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var person = new Person();

            // #3 Retornando o tipo | Return type

            var type = person.GetType();
            Console.WriteLine("Person class\n\n");
            Console.WriteLine("Type with namespace: " + type);

            // #4 Retornando o nome da classe | Return the class name

            Console.WriteLine("Type name: " + type.Name);

            // #5 Retornando o nome da namespace da classe | Return the namespace name

            Console.WriteLine("Namespace name: " + type.Namespace);
            Console.WriteLine("\n");

            // #6 Trabalhando com assembly | Working with assembly

            var assembly = typeof(Person).Assembly;

            Console.WriteLine("Assembly info: " + assembly);

            // #7 Retornando o tipo da classe | Return class type

            var personType = typeof(Person);
            Console.WriteLine("Type name: " + personType);
            Console.WriteLine("\n");
            // #8 Retornando o tipo da classe por string | Return class type per string

            //               Type.GetType("Namespace.ClassName ,     DLLName    ")
            var personTypeFromString = Type.GetType("HumanResource.Person,CSharpReflection");
            Console.WriteLine("Type name: " + personTypeFromString.Name);
            Console.WriteLine("Namespace name: " + personTypeFromString.Namespace);
            Console.WriteLine("\n");

            // #9 Acessar os métodos e propriedades com Activator | Access methods and properties with Activator
                // Equivale a um operador new | Equal at new operator
            var human = Activator.CreateInstance(personTypeFromString);

                // Propriedades | Properties
            var properties = personTypeFromString.GetProperties();

                // Listando propriedades | Properties list
            foreach (var prop in properties)
            {
                Console.WriteLine("Property: " + prop.Name);
            }

                // Retornar uma propriedade e seu valor | Get one property and your value
            var property = personTypeFromString.GetProperty("Steps");
            var propertyValue = property.GetValue(human, null);
            Console.WriteLine(property.Name + ": " + propertyValue);

                // Atribuindo valor às propriedades | Set value at property
            property.SetValue(human, 30, null);
            propertyValue = property.GetValue(human, null);
            Console.WriteLine(property.Name + ": " + propertyValue);
            Console.WriteLine("\n");

                // Invocar um método | Invoke a method
            Console.WriteLine("Invoke Walk()");
            personTypeFromString.InvokeMember("Walk", 
                                              BindingFlags.InvokeMethod | BindingFlags.Public | BindingFlags.Instance, 
                                              null, 
                                              human, 
                                              null);

            propertyValue = property.GetValue(human, null);
            Console.WriteLine(property.Name + ": " + propertyValue);

                // Invocar um método com parâmetros | Invoke a method with parameters
            Console.WriteLine("Invoke Walk(2)");
            personTypeFromString.InvokeMember("Walk",
                                              BindingFlags.InvokeMethod | BindingFlags.Public | BindingFlags.Instance,
                                              null,
                                              human,
                                              new object[] { 2 });
            propertyValue = property.GetValue(human, null);
            Console.WriteLine(property.Name + ": " + propertyValue);
            Console.WriteLine("\n");

            // #10 Usando DataAnnotations | Using DataAnnotations
            WithDataAnnotations();

            Console.ReadLine();
        }


        /// <summary>
        /// Exemplo com DataAnnotations | DataAnnotations Sample
        /// </summary>
        public static void WithDataAnnotations()
        {

            var customerType = Type.GetType("HumanResource.Customer,CSharpReflection");
            var nameProperty = customerType.GetProperty("TradingName");
            var keyProperty = customerType.GetProperty("CustomerId");

            // Key
            var keyAttribute = keyProperty.GetCustomAttribute<KeyAttribute>();
            if (keyAttribute != null)
                Console.WriteLine(keyProperty.Name + " (Key): true");

            // Display
            var displayAttribute = nameProperty.GetCustomAttribute<DisplayAttribute>();
            if (displayAttribute != null)
                Console.WriteLine(nameProperty.Name + " (Display): " + displayAttribute.Name);

            // Required
            var requiredAttribute = nameProperty.GetCustomAttribute<RequiredAttribute>();
            if (requiredAttribute != null)
                Console.WriteLine(nameProperty.Name + " (Required): " + requiredAttribute.FormatErrorMessage(nameProperty.Name));

            // MaxLength
            var maxLengthAttribute = nameProperty.GetCustomAttribute<MaxLengthAttribute>();
            if (maxLengthAttribute != null)
                Console.WriteLine(nameProperty.Name + " (MaxLength): " + maxLengthAttribute.FormatErrorMessage(nameProperty.Name));

            Console.WriteLine("\n");
        }
    }
}
