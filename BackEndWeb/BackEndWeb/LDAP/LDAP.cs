using System.DirectoryServices.Protocols;

namespace BackEndWeb;

public class LDAP
{
    public bool LDAPConn(string userName, string password)
    {
        string host = "ldap2.it-college.ru:389";
        string dn = $"uid={userName},ou=People,dc=it-college,dc=ru"; // DN пользователя для подключения

        try
        {
            LdapConnection connection = new LdapConnection(new LdapDirectoryIdentifier(host, 389)); //10.3.0.33
            connection.Credential = new System.Net.NetworkCredential(dn, password);
            connection.AuthType = AuthType.Basic;
            connection.SessionOptions.ProtocolVersion = 3;
            connection.Bind();

            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Провал: {ex.Message}");
        }

        return false;
    }
}