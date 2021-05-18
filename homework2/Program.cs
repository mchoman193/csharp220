using System;
using System.Collections.Generic;
using System.Linq;

namespace homework2
{
    class Program
    {

        static void Main(string[] args)
        {
            var users = new List<Models.User>();

            users.Add(new Models.User { Name = "Dave", Password = "hello" });
            users.Add(new Models.User { Name = "Steve", Password = "steve" });
            users.Add(new Models.User { Name = "Lisa", Password = "hello" });
            ShowPasswordHello(users);
            DeletePasswordMatchingName(users);
            DeleteFirstUserWithSpecificPassword(users);
            ShowAllUsersPostProcessing(users);
        }

        // 1. Display to the console, the names of the users where the password is "hello" and you can
        //    use a foreach here only. 
        private static void ShowPasswordHello(List<Models.User> users)
        {
            Console.WriteLine("List of users (if any) with a password matching 'hello'...");
            Console.WriteLine("==========================================================");
            var userEvaluationResults = Enumerable.Where(users, u => u.Password.Equals("hello"));
            foreach (var userEvaluationResult in userEvaluationResults)
            {
                Console.WriteLine(userEvaluationResult.Name + " - " + userEvaluationResult.Password);
            }
            Console.WriteLine("");
        }

        // 2. Delete any passwords that are the lower-cased version of their Name. Do not just look for "steve".
        //    It has to be data-driven. Hint: Remove or RemoveAll
        private static void DeletePasswordMatchingName(List<Models.User> users)
        {
            Console.WriteLine("List of users (if any) after removing those with a password matching their name...");
            Console.WriteLine("==================================================================================");
            users.RemoveAll(u => u.Name.ToLower().Equals(u.Password));
            ShowAllUsers(users);
            Console.WriteLine("");
        }

        // 3. Delete the first User that has the password "hello".  Hint: First or FirstOrDefault
        private static void DeleteFirstUserWithSpecificPassword(List<Models.User> users)
        {
            Console.WriteLine("List of first user (if any) having 'hello' as their password...");
            Console.WriteLine("===============================================================");

            try
            {
                var userEvaluationResults = users.First(u => u.Password.Equals("hello"));
                Console.WriteLine(userEvaluationResults.Name + " - " + userEvaluationResults.Password);
            }
            catch (InvalidOperationException ioe)
            {
                Console.WriteLine("Error: " + ioe.Message);
                Console.WriteLine("Most likely, this is due to no first user with the 'hello' password.");
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
            Console.WriteLine("");
        }

        // 4. Display to the console the remaining users with their Name and Password.  Hint: ForEach
        private static void ShowAllUsersPostProcessing(List<Models.User> users)
        {
            Console.WriteLine("List of users (if any) after all previous tasks have completed...");
            Console.WriteLine("=================================================================");
            ShowAllUsers(users);
        }

        private static void ShowAllUsers(List<Models.User> users)
        {
            foreach (var user in users)
            {
                Console.WriteLine(user.Name + " - " + user.Password);
            }
            Console.WriteLine("");
        }

    }
}
