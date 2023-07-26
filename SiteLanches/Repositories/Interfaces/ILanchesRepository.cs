using SiteLanches.Models;
using Microsoft.Data.SqlClient.DataClassification;

namespace SiteLanches.Repositories.Interfaces
{
    public interface ILanchesRepository
    {

        IEnumerable<Lanche> Lanches { get; }
        IEnumerable<Lanche> LanchesPreferidos { get; }
        Lanche GetLancheById(int lancheId); 
    }
}
