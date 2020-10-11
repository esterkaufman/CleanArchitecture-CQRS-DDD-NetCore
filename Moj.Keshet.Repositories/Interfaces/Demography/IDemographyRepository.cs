using System.Collections.Generic;
using System.Threading.Tasks;
using Moj.Demography.Rest.Proxy.Contracts;
using Moj.Keshet.Domain.ExampleModels.CodeTables;

namespace Moj.Keshet.Repositories.Interfaces.Demography
{
    public interface IDemographyRepository
    {
        List<Country> Countries { get; }

        List<Country> BirthCountries { get; }

        List<ExtendedCity> AllCities { get; }

        GetCodeTableResponse GetCityCodePairs { get; }

        List<ExtendedStreet> GetStreetsByCity(int cityId);

        Task<List<ExtendedStreet>> GetStreetsByCityAsync(int cityId);

        ExtendedStreet GetStreet(int cityId, int streetId);

        Task<ExtendedStreet> GetStreetAsync(int cityId, int streetId);

        ExtendedCity GetCity(int cityId);

        Task<ExtendedCity> GetCityAsync(int cityId);

        ExtendedCity GetCityBySemel(int citySemel);

        Task<ExtendedCity> GetCityBySemelAsync(int citySemel);

        Country GetCountry(int countryId);

        Task<Country> GetCountryAsync(int countryId);

        Country GetBirthCountry(int countryId);

        Task<Country> GetBirthCountryAsync(int countryId);

        int? GetZip(int cityId, int streetId, int houseNumber, string entrance);

        Task<int?> GetZipAsync(int cityId, int streetId, int houseNumber, string entrance);

        int? GetZip(int cityId, int poBox);

        Task<int?> GetZipAsync(int cityId, int poBox);
    }
}
