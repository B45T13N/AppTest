using System.Security.Policy;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Supabase;

namespace CLAppTestSupabase.Data;

public class SupabaseConnexion
{
    public static Client GetConnexion(string url, string key)
    {
        var options = new Supabase.SupabaseOptions
        {
            AutoConnectRealtime = true
        };

        var supabase = new Supabase.Client(url, key, options);

        return supabase;
    }
}