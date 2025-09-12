using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace BinarySearchAPI
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            List<User> users = await FetchUsersFromAPI();
            users.Sort((a, b) => a.Username.CompareTo(b.Username));
            Console.WriteLine("\nFetched Users:");
            foreach(var user in users) {
                Console.WriteLine(user.Username);
            }
            #region BinarySearch
            Console.Write("\nEnter a username to search: ");
            string usernameToReach = Console.ReadLine();
            int successValue = BinarySearch(users, usernameToReach);
            if(successValue != 1) {
                Console.WriteLine("User found: " + users[successValue].Name);
            } else {
                Console.WriteLine("User not found;");
            }

            #endregion
        }
        static async Task<List<User>> FetchUsersFromAPI() {
            using HttpClient client = new HttpClient();
            string url = "https://randomuser.me/api/?results=10";

            var response = await client.GetFromJsonAsync<ApiResponse>(url);
            List<User> users = new List<User>();

            foreach(var result in response.Results) {
                users.Add(
                    new User {
                        Username = result.Login.Username,
                        Name = $"{ result.Name.First} { result.Name.Last}",
                    }
                );
            }
            return users;
        }
        static int BinarySearch(List<User> sortedUsers, string target) {
            int left = 0;
            int right = sortedUsers.Count - 1;
            while(left <= right) {
                int mid = left + (right - left) / 2;
                int comparison = sortedUsers[mid].Username.CompareTo(target);
                if(comparison == 0) {
                    return mid;
                }else if(comparison < 0) {
                    left = mid + 1;
                } else {
                    right = mid - 1;
                }
            }
            return -1;
        }
        public class ApiResponse {
            public List<Result> Results { get; set; }
        }

        public class Result {
            public Name Name { get; set; }
            public Login Login { get; set; }
        }

        public class Name {
            public string First { get; set; }
            public string Last { get; set; }
        }

        public class Login {
            public string Username { get; set; }
        }

        public class User {
            public string Username { get; set; }
            public string Name { get; set; }
        }
    }
}
