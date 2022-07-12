
namespace MongoAPI.Services.Seeding;

/// <summary>
/// Class to handle data seeding process
/// </summary>
public class DataSeedeer
{
    public void TrySeedData()
    {
        try
        {   
            seedEventTypes();  
        }
        catch (System.Exception)
        {
            //TODO: log and report!
            throw;
        }
    }

    /// <summary>
    /// TODO: create a seed of event data
    /// </summary>
    void seedEventTypes()
    {

    }
}