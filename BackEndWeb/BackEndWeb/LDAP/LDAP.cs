using System.DirectoryServices.Protocols;
using System.Net;

namespace BackEndWeb;

public class LDAP
{
    public void LDAPConn()
    {
        string userName = "i22s0659";
        string password = "kNpcqHrW";
        string ip = "ldap2.it-college.ru";
        int port = 389;
        string dn = $"uid={userName},ou=People";
        string basend = "dc=it-college,dc=ru";

        try
        {
            LdapConnection connection = new LdapConnection(new LdapDirectoryIdentifier($"LDAP://{ip}", port));
            
            NetworkCredential credential = new NetworkCredential(userName, password);
            connection.Credential = credential;
            
            connection.Bind();
            Console.WriteLine("Подключение успешно!");
            
            string searchBase = "ou=People,dc=it-college,dc=ru"; // Базовый DN для поиска
            string searchFilter = $"(uid={userName})"; // Фильтр для поиска пользователя
            
            SearchRequest searchRequest = new SearchRequest(searchBase, searchFilter, SearchScope.Subtree, null);
            SearchResponse searchResponse = (SearchResponse)connection.SendRequest(searchRequest);

            // Проверяем, есть ли результаты
            if (searchResponse.Entries.Count > 0)
            {
                Console.WriteLine($"Пользователь найден: {searchResponse.Entries[0].DistinguishedName}");
            }
            else
            {
                Console.WriteLine("Пользователь не найден.");
            }
        }
        catch (LdapException ldapEx)
        {
            Console.WriteLine($"LDAP ошибка: {ldapEx.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка: {ex.Message}");
        }
    }
}