namespace BackEnd.Settings;

public class Settings
{
    //LDAP 
    private string _ip;
    private int _port;
    private string _baseDn;


    public Settings(string ip, int port, string baseDn)
    {
        _ip = ip;
        _port = port;
        _baseDn = baseDn;
    }

    public string LdapIp => _ip;
    public int LdapPort => _port;
    public string LdapBaseDn => _baseDn;
}